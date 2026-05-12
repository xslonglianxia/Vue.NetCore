<template>
  <div class="vol-container">
    <div class="btn-group">
      <el-button type="primary" @click="add">新增</el-button>
      <el-button type="danger" @click="del">删除</el-button>
    </div>
    <vol-table ref="table" :url="url" :columns="columns" :pagination="pagination" @loadBefore="loadBefore" @loadAfter="loadAfter"></vol-table>
    <vol-box v-model="model" :height="400" :width="500" :title="boxTitle">
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
const url = '/api/DC/DC_SysFile/'
const model = ref(false)
const boxType = ref('Add')
const boxTitle = ref('新增')
const table = ref(null)
const form = ref(null)
const currentRow = ref(null)

const formFields = reactive({
  name: '',
  size: 0,
  contentType: '',
  path: ''
})

const formRules = reactive([
  [
    { field: 'name', title: '文件名', type: 'string', require: true },
    { field: 'path', title: '文件', type: 'file' }
  ],
  [
    { field: 'contentType', title: '内容类型', type: 'string' },
    { field: 'size', title: '大小', type: 'number', readonly: true }
  ]
])

const columns = reactive([
  { field: 'name', title: '文件名', type: 'string', width: 200 },
  { field: 'size', title: '大小', type: 'string', width: 100, formatter: (row) => {
    let size = row.size
    if (!size) return '--'
    if (size < 1024) return size + 'B'
    if (size < 1024 * 1024) return (size / 1024).toFixed(1) + 'KB'
    return (size / (1024 * 1024)).toFixed(1) + 'MB'
  }},
  { field: 'contentType', title: '内容类型', type: 'string', width: 150 },
  { field: 'path', title: '路径', type: 'string', width: 250 },
  { field: 'createDate', title: '创建时间', type: 'datetime', width: 150 },
  { title: '操作', width: 180, fixed: 'right', align: 'center', render: (h, { row }) => {
    return h('div', [
      h('el-button', { type: 'primary', link: true, onClick: () => edit(row) }, '编辑'),
      h('el-button', { type: 'success', link: true, onClick: () => download(row) }, '下载'),
      h('el-button', { type: 'danger', link: true, onClick: () => delRow(row) }, '删除')
    ])
  }}
])

const pagination = reactive({ total: 0, size: 30, sortName: '' })

const loadBefore = (param) => { return true }
const loadAfter = (data) => {}

const resetForm = () => {
  Object.assign(formFields, { name: '', size: 0, contentType: '', path: '' })
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

const download = (row) => {
  if (!row.path) return proxy.$message.warning('文件路径为空')
  http.download(url + 'download', { id: row.id }, row.name, true)
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
