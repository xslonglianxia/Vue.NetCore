<template>
  <div class="vol-container">
    <div class="search-form">
      <el-form :inline="true" :model="searchFields">
        <el-form-item label="用户名">
          <el-input v-model="searchFields.username" clearable placeholder="用户名"></el-input>
        </el-form-item>
        <el-form-item label="姓名">
          <el-input v-model="searchFields.name" clearable placeholder="姓名"></el-input>
        </el-form-item>
        <el-form-item label="手机号">
          <el-input v-model="searchFields.phone" clearable placeholder="手机号"></el-input>
        </el-form-item>
        <el-form-item label="启用">
          <el-select v-model="searchFields.enabled" clearable placeholder="请选择">
            <el-option :value="1" label="启用"></el-option>
            <el-option :value="0" label="禁用"></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="锁定">
          <el-select v-model="searchFields.lockedStatus" clearable placeholder="请选择">
            <el-option :value="1" label="已锁定"></el-option>
            <el-option :value="0" label="未锁定"></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="创建时间">
          <el-date-picker v-model="searchFields.createDateRange" type="daterange" range-separator="-" start-placeholder="开始时间" end-placeholder="结束时间" value-format="YYYY-MM-DD"></el-date-picker>
        </el-form-item>
        <el-form-item>
          <el-button type="primary" @click="search">查询</el-button>
          <el-button @click="resetSearch">重置</el-button>
        </el-form-item>
      </el-form>
    </div>
    <div class="btn-group">
      <el-button type="primary" @click="add">新增</el-button>
      <el-button type="danger" @click="del">删除</el-button>
    </div>
    <vol-table ref="table" :url="url" :columns="columns" :pagination="pagination" @loadBefore="loadBefore" @loadAfter="loadAfter"></vol-table>
    <vol-box v-model="model" :height="500" :width="600" :title="boxTitle">
      <vol-form ref="form" :formRules="formRules" :formFields="formFields"></vol-form>
      <template #footer>
        <el-button type="primary" @click="save">保存</el-button>
        <el-button @click="model = false">关闭</el-button>
      </template>
    </vol-box>
  </div>
</template>

<script setup>
import { ref, reactive, getCurrentInstance } from 'vue'
import VolTable from '@/components/basic/VolTable.vue'
import VolForm from '@/components/basic/VolForm.vue'
import VolBox from '@/components/basic/VolBox.vue'
import http from '@/api/http.js'

const { proxy } = getCurrentInstance()
const url = '/api/DC/DC_SysUser/'
const model = ref(false)
const boxType = ref('Add')
const boxTitle = ref('新增')
const table = ref(null)
const form = ref(null)
const currentRow = ref(null)

const searchFields = reactive({
  username: '',
  name: '',
  phone: '',
  enabled: null,
  lockedStatus: null,
  createDateRange: null
})

const formFields = reactive({
  username: '',
  password: '',
  name: '',
  email: '',
  phone: '',
  gender: 0,
  orgId: null,
  enabled: 1
})

const formRules = reactive([
  [
    { field: 'username', title: '用户名', type: 'string', require: true },
    { field: 'password', title: '密码', type: 'password', require: true }
  ],
  [
    { field: 'name', title: '姓名', type: 'string', require: true },
    { field: 'email', title: '邮箱', type: 'string' }
  ],
  [
    { field: 'phone', title: '手机号', type: 'string' },
    { field: 'gender', title: '性别', type: 'select', data: [{ key: 0, value: '未知' }, { key: 1, value: '男' }, { key: 2, value: '女' }] }
  ],
  [
    { field: 'orgId', title: '组织', type: 'treeSelect', data: [] },
    { field: 'enabled', title: '启用', type: 'switch' }
  ]
])

const columns = reactive([
  { field: 'username', title: '用户名', type: 'string', width: 120 },
  { field: 'name', title: '姓名', type: 'string', width: 100 },
  { field: 'avatar', title: '头像', type: 'img', width: 80 },
  { field: 'email', title: '邮箱', type: 'string', width: 160 },
  { field: 'phone', title: '手机号', type: 'string', width: 120 },
  { field: 'gender', title: '性别', type: 'string', width: 70, bind: { key: 'gender', data: [{ key: 0, value: '未知' }, { key: 1, value: '男' }, { key: 2, value: '女' }] } },
  { field: 'orgId', title: '组织', type: 'string', width: 120 },
  { field: 'enabled', title: '启用', type: 'switch', width: 80, bind: { key: 'enable', data: [{ key: 0, value: '禁用' }, { key: 1, value: '启用' }] } },
  { field: 'lockedStatus', title: '锁定', type: 'string', width: 80, bind: { key: 'locked', data: [{ key: 0, value: '未锁定' }, { key: 1, value: '已锁定' }] } },
  { field: 'onlineStatus', title: '在线', type: 'string', width: 80, bind: { key: 'online', data: [{ key: 0, value: '离线' }, { key: 1, value: '在线' }] } },
  { field: 'lastLoginIp', title: '最后登录IP', type: 'string', width: 130 },
  { field: 'lastLoginDate', title: '最后登录时间', type: 'datetime', width: 150 },
  { field: 'createDate', title: '创建时间', type: 'datetime', width: 150 },
  { title: '操作', width: 150, fixed: 'right', align: 'center', render: (h, { row }) => {
    return h('div', [
      h('el-button', { type: 'primary', link: true, onClick: () => edit(row) }, '编辑'),
      row.lockedStatus === 1 ? h('el-button', { type: 'warning', link: true, onClick: () => unfreeze(row) }, '解冻') : null,
      h('el-button', { type: 'danger', link: true, onClick: () => delRow(row) }, '删除')
    ])
  }}
])

const pagination = reactive({ total: 0, size: 30, sortName: '' })

const loadBefore = (param) => {
  if (searchFields.username) param.wheres.push({ name: 'username', value: searchFields.username })
  if (searchFields.name) param.wheres.push({ name: 'name', value: searchFields.name })
  if (searchFields.phone) param.wheres.push({ name: 'phone', value: searchFields.phone })
  if (searchFields.enabled !== null && searchFields.enabled !== '') param.wheres.push({ name: 'enabled', value: searchFields.enabled })
  if (searchFields.lockedStatus !== null && searchFields.lockedStatus !== '') param.wheres.push({ name: 'lockedStatus', value: searchFields.lockedStatus })
  if (searchFields.createDateRange && searchFields.createDateRange.length === 2) {
    param.wheres.push({ name: 'createDate', value: searchFields.createDateRange[0], displayType: 'thanorequal' })
    param.wheres.push({ name: 'createDate', value: searchFields.createDateRange[1], displayType: 'lessorequal' })
  }
  return true
}

const loadAfter = (data) => {}

const search = () => {
  table.value.load(null, true)
}

const resetSearch = () => {
  Object.assign(searchFields, { username: '', name: '', phone: '', enabled: null, lockedStatus: null, createDateRange: null })
  table.value.load(null, true)
}

const resetForm = () => {
  Object.assign(formFields, { username: '', password: '', name: '', email: '', phone: '', gender: 0, orgId: null, enabled: 1 })
}

const add = () => {
  boxType.value = 'Add'
  boxTitle.value = '新增'
  resetForm()
  model.value = true
}

const edit = (row) => {
  boxType.value = 'Edit'
  boxTitle.value = '编辑'
  currentRow.value = row
  Object.assign(formFields, { ...row })
  formFields.password = ''
  model.value = true
}

const save = async () => {
  let valid = await form.value.validate()
  if (!valid) return
  let params = { ...formFields }
  if (boxType.value === 'Add') {
    let result = await http.post(url + 'add', params, true)
    if (result.status) {
      proxy.$message.success('新增成功')
      model.value = false
      table.value.load()
    } else {
      proxy.$message.error(result.message)
    }
  } else {
    let result = await http.post(url + 'update', params, true)
    if (result.status) {
      proxy.$message.success('编辑成功')
      model.value = false
      table.value.load()
    } else {
      proxy.$message.error(result.message)
    }
  }
}

const del = () => {
  let rows = table.value.getSelected()
  if (!rows.length) return proxy.$message.warning('请选择要删除的行')
  proxy.$confirm('确定要删除选中的数据吗?', '提示', { type: 'warning' }).then(async () => {
    let result = await http.post(url + 'del', rows.map(x => x.id), true)
    if (result.status) {
      proxy.$message.success('删除成功')
      table.value.load()
    } else {
      proxy.$message.error(result.message)
    }
  })
}

const delRow = (row) => {
  proxy.$confirm('确定要删除该条数据吗?', '提示', { type: 'warning' }).then(async () => {
    let result = await http.post(url + 'del', [row.id], true)
    if (result.status) {
      proxy.$message.success('删除成功')
      table.value.load()
    } else {
      proxy.$message.error(result.message)
    }
  })
}

const unfreeze = async (row) => {
  let result = await http.post(url + 'unfreeze', { id: row.id }, true)
  if (result.status) {
    proxy.$message.success('解冻成功')
    table.value.load()
  } else {
    proxy.$message.error(result.message)
  }
}
</script>

<style scoped>
.vol-container {
  padding: 10px;
}
.search-form {
  padding: 10px 0 0 0;
}
.btn-group {
  padding: 0 0 10px 0;
}
</style>
