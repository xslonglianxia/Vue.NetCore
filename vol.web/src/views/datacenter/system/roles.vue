<template>
  <div class="vol-container">
    <div class="btn-group">
      <el-button type="primary" @click="add">新增</el-button>
      <el-button type="danger" @click="del">删除</el-button>
    </div>
    <vol-table ref="table" :url="url" :columns="columns" :pagination="pagination" @loadBefore="loadBefore" @loadAfter="loadAfter"></vol-table>
    <vol-box v-model="model" :height="450" :width="550" :title="boxTitle">
      <vol-form ref="form" :formRules="formRules" :formFields="formFields"></vol-form>
      <template #footer>
        <el-button type="primary" @click="save">保存</el-button>
        <el-button @click="model = false">关闭</el-button>
      </template>
    </vol-box>
    <vol-box v-model="resourceModel" :height="500" :width="400" title="资源分配">
      <el-tree ref="resourceTree" :data="resourceData" show-checkbox node-key="key" :default-checked-keys="checkedKeys" :props="{ label: 'label' }"></el-tree>
      <template #footer>
        <el-button type="primary" @click="saveResource">保存</el-button>
        <el-button @click="resourceModel = false">关闭</el-button>
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
const url = '/api/DC/DC_SysRole/'
const model = ref(false)
const resourceModel = ref(false)
const boxType = ref('Add')
const boxTitle = ref('新增')
const table = ref(null)
const form = ref(null)
const resourceTree = ref(null)
const currentRow = ref(null)
const resourceData = ref([])
const checkedKeys = ref([])

const formFields = reactive({
  name: '',
  code: '',
  kind: null,
  builtin: 0,
  resourceCode: '',
  remark: ''
})

const formRules = reactive([
  [
    { field: 'name', title: '名称', type: 'string', require: true },
    { field: 'code', title: '编码', type: 'string', require: true }
  ],
  [
    { field: 'kind', title: '类型', type: 'select', data: [{ key: 0, value: '系统角色' }, { key: 1, value: '业务角色' }] },
    { field: 'builtin', title: '内置', type: 'switch' }
  ],
  [
    { field: 'resourceCode', title: '资源编码', type: 'string' },
    { field: 'remark', title: '备注', type: 'textarea' }
  ]
])

const columns = reactive([
  { field: 'name', title: '名称', type: 'string', width: 150 },
  { field: 'code', title: '编码', type: 'string', width: 150 },
  { field: 'kind', title: '类型', type: 'string', width: 100, bind: { key: 'kind', data: [{ key: 0, value: '系统角色' }, { key: 1, value: '业务角色' }] } },
  { field: 'builtin', title: '内置', type: 'switch', width: 80, bind: { key: 'builtin', data: [{ key: 0, value: '否' }, { key: 1, value: '是' }] } },
  { field: 'resourceCode', title: '资源编码', type: 'string', width: 150 },
  { field: 'remark', title: '备注', type: 'string', width: 200 },
  { field: 'createDate', title: '创建时间', type: 'datetime', width: 150 },
  { title: '操作', width: 200, fixed: 'right', align: 'center', render: (h, { row }) => {
    return h('div', [
      h('el-button', { type: 'primary', link: true, onClick: () => edit(row) }, '编辑'),
      h('el-button', { type: 'warning', link: true, onClick: () => assignResource(row) }, '资源'),
      h('el-button', { type: 'danger', link: true, onClick: () => delRow(row) }, '删除')
    ])
  }}
])

const pagination = reactive({ total: 0, size: 30, sortName: '' })

const loadBefore = (param) => { return true }
const loadAfter = (data) => {}

const resetForm = () => {
  Object.assign(formFields, { name: '', code: '', kind: null, builtin: 0, resourceCode: '', remark: '' })
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

const assignResource = async (row) => {
  currentRow.value = row
  let result = await http.post(url + 'getResourceTree', { roleId: row.id }, false)
  resourceData.value = result.data || []
  let checkedResult = await http.post(url + 'getCheckedResources', { roleId: row.id }, false)
  checkedKeys.value = checkedResult.data || []
  resourceModel.value = true
}

const saveResource = async () => {
  let checkedNodes = resourceTree.value.getCheckedKeys()
  let halfChecked = resourceTree.value.getHalfCheckedKeys()
  let allKeys = [...checkedNodes, ...halfChecked]
  let result = await http.post(url + 'saveResource', { roleId: currentRow.value.id, resourceKeys: allKeys }, true)
  if (result.status) {
    proxy.$message.success('资源分配成功')
    resourceModel.value = false
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
.btn-group {
  padding: 0 0 10px 0;
}
</style>
