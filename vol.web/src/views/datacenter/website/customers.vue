<template>
  <div class="dc-web-customers">
    <vol-form
      ref="searchForm"
      :formFields="searchFields"
      :formRules="searchRules"
      :labelWidth="90"
    >
      <template #footer>
        <el-button type="primary" @click="search">查 询</el-button>
        <el-button @click="resetSearch">重 置</el-button>
      </template>
    </vol-form>
    <div class="btn-group">
      <el-button type="success" @click="add">新 建</el-button>
      <el-button type="primary" @click="edit">编 辑</el-button>
      <el-button type="danger" @click="del">删 除</el-button>
    </div>
    <vol-table
      ref="table"
      :columns="columns"
      :url="url"
      :pagination="pagination"
      :ck="true"
      :index="true"
    />
    <vol-box v-model="editBoxVisible" title="客户编辑" :width="700" :height="500">
      <vol-form
        ref="editForm"
        :formFields="editFields"
        :formRules="editRules"
        :labelWidth="100"
      />
      <template #footer>
        <el-button type="primary" @click="save">保 存</el-button>
        <el-button @click="editBoxVisible = false">关 闭</el-button>
      </template>
    </vol-box>
  </div>
</template>
<script setup>
import VolTable from '@/components/basic/VolTable.vue'
import VolForm from '@/components/basic/VolForm.vue'
import VolBox from '@/components/basic/VolBox.vue'
import { ref, reactive, getCurrentInstance } from 'vue'
const { proxy } = getCurrentInstance()
const url = '/api/DC/DC_WebCustomer/'
const searchFields = reactive({
  firstName: '',
  lastName: '',
  email: '',
  company: '',
  country: '',
  createDateRange: ''
})
const searchRules = [
  [
    { title: '名', field: 'firstName', type: 'like' },
    { title: '姓', field: 'lastName', type: 'like' },
    { title: '邮箱', field: 'email' }
  ],
  [
    { title: '公司', field: 'company', type: 'like' },
    { title: '国家', field: 'country' },
    { title: '创建时间', field: 'createDateRange', type: 'datetime', range: true }
  ]
]
const editFields = reactive({
  firstName: '',
  lastName: '',
  email: '',
  company: '',
  country: '',
  content: ''
})
const editRules = [
  [
    { title: '名', field: 'firstName', required: true },
    { title: '姓', field: 'lastName', required: true }
  ],
  [
    { title: '邮箱', field: 'email' },
    { title: '公司', field: 'company' }
  ],
  [
    { title: '国家', field: 'country' },
    { title: '内容', field: 'content', type: 'textarea' }
  ]
]
const columns = reactive([
  { field: 'firstName', title: '名', type: 'string', width: 100 },
  { field: 'lastName', title: '姓', type: 'string', width: 100 },
  { field: 'email', title: '邮箱', type: 'string', width: 180 },
  { field: 'company', title: '公司', type: 'string', width: 150 },
  { field: 'country', title: '国家', type: 'string', width: 100 },
  { field: 'content', title: '内容', type: 'string', width: 200 },
  { field: 'createDate', title: '创建时间', type: 'datetime', width: 140, sort: true }
])
const pagination = reactive({ total: 0, size: 30, sortName: 'CreateDate' })
const editBoxVisible = ref(false)
const currentRow = ref(null)
const table = ref(null)
const searchForm = ref(null)
const editForm = ref(null)
const search = () => {
  let wheres = []
  if (searchFields.firstName) wheres.push({ name: 'firstName', value: searchFields.firstName, displayType: 'like' })
  if (searchFields.lastName) wheres.push({ name: 'lastName', value: searchFields.lastName, displayType: 'like' })
  if (searchFields.email) wheres.push({ name: 'email', value: searchFields.email })
  if (searchFields.company) wheres.push({ name: 'company', value: searchFields.company, displayType: 'like' })
  if (searchFields.country) wheres.push({ name: 'country', value: searchFields.country })
  if (searchFields.createDateRange) wheres.push({ name: 'createDate', value: searchFields.createDateRange, displayType: 'range' })
  table.value.load(wheres)
}
const resetSearch = () => {
  searchFields.firstName = ''
  searchFields.lastName = ''
  searchFields.email = ''
  searchFields.company = ''
  searchFields.country = ''
  searchFields.createDateRange = ''
  table.value.load([])
}
const add = () => {
  Object.keys(editFields).forEach(k => { editFields[k] = '' })
  currentRow.value = null
  editBoxVisible.value = true
}
const edit = () => {
  let rows = table.value.getSelected()
  if (!rows || rows.length === 0) return proxy.$message.warning('请选择要编辑的行')
  if (rows.length > 1) return proxy.$message.warning('只能选择一行进行编辑')
  currentRow.value = rows[0]
  Object.keys(editFields).forEach(k => { editFields[k] = rows[0][k] ?? editFields[k] })
  editBoxVisible.value = true
}
const del = () => {
  let rows = table.value.getSelected()
  if (!rows || rows.length === 0) return proxy.$message.warning('请选择要删除的行')
  proxy.$confirm('确认要删除选中的数据吗?', '提示', { type: 'warning' }).then(() => {
    let ids = rows.map(r => r.id || r.Id)
    proxy.http.post(url + 'del', ids, true).then(result => {
      if (result.status) {
        proxy.$message.success('删除成功')
        table.value.load()
      } else {
        proxy.$message.error(result.message)
      }
    })
  })
}
const save = () => {
  let params = { ...editFields }
  if (currentRow.value) {
    params.id = currentRow.value.id || currentRow.value.Id
    proxy.http.post(url + 'update', params, true).then(result => {
      if (result.status) {
        proxy.$message.success('保存成功')
        editBoxVisible.value = false
        table.value.load()
      } else {
        proxy.$message.error(result.message)
      }
    })
  } else {
    proxy.http.post(url + 'add', params, true).then(result => {
      if (result.status) {
        proxy.$message.success('新建成功')
        editBoxVisible.value = false
        table.value.load()
      } else {
        proxy.$message.error(result.message)
      }
    })
  }
}
</script>
<style lang="less" scoped>
.dc-web-customers {
  padding: 10px;
}
.btn-group {
  padding: 6px 0;
  display: flex;
  gap: 6px;
}
</style>
