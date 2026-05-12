<template>
  <div class="vol-container">
    <div class="btn-group">
      <el-button type="primary" @click="add(null)">新增</el-button>
    </div>
    <vol-table ref="table" :url="url" :columns="columns" :pagination="pagination" :paginationHide="true" rowKey="id" :loadTreeChildren="loadTreeChildren" @loadBefore="loadBefore" @loadAfter="loadAfter"></vol-table>
    <vol-box v-model="model" :height="350" :width="450" :title="boxTitle">
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
const url = '/api/DC/DC_SysOrg/'
const model = ref(false)
const boxType = ref('Add')
const boxTitle = ref('新增')
const table = ref(null)
const form = ref(null)
const currentRow = ref(null)
const parentRow = ref(null)

const formFields = reactive({
  name: '',
  parentId: null,
  seq: 0,
  remark: ''
})

const formRules = reactive([
  [
    { field: 'name', title: '名称', type: 'string', require: true },
    { field: 'parentId', title: '上级', type: 'treeSelect', data: [] }
  ],
  [
    { field: 'seq', title: '排序', type: 'number' },
    { field: 'remark', title: '备注', type: 'textarea' }
  ]
])

const columns = reactive([
  { field: 'name', title: '名称', type: 'string', width: 200 },
  { field: 'parentId', title: '上级', type: 'string', width: 150 },
  { field: 'seq', title: '排序', type: 'int', width: 80 },
  { field: 'remark', title: '备注', type: 'string', width: 200 },
  { title: '操作', width: 200, fixed: 'right', align: 'center', render: (h, { row }) => {
    return h('div', [
      h('el-button', { type: 'primary', link: true, onClick: () => add(row) }, '新增子级'),
      h('el-button', { type: 'success', link: true, onClick: () => edit(row) }, '编辑'),
      h('el-button', { type: 'danger', link: true, onClick: () => delRow(row) }, '删除')
    ])
  }}
])

const pagination = reactive({ total: 0, size: 30, sortName: '' })

const loadTreeChildren = (tree, treeNode, resolve) => {
  http.post(url + 'getTreeChildren?id=' + tree.id, {}).then(result => {
    resolve(result.rows || result.data || [])
  })
}

const loadBefore = (param) => {
  if (!param.wheres || !param.wheres.length) {
    param.value = 1
  }
  return true
}

const loadAfter = (data) => {}

const resetForm = () => {
  Object.assign(formFields, { name: '', parentId: null, seq: 0, remark: '' })
}

const add = (row) => {
  boxType.value = 'Add'
  boxTitle.value = '新增'
  parentRow.value = row
  resetForm()
  if (row) {
    formFields.parentId = row.id
  }
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
</script>

<style scoped>
.vol-container {
  padding: 10px;
}
.btn-group {
  padding: 0 0 10px 0;
}
</style>
