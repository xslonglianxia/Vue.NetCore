<template>
  <div class="dc-mkt-spus">
    <vol-form
      ref="searchForm"
      :formFields="searchFormFields"
      :formRules="searchFormRules"
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
    <vol-box v-model="editBoxVisible" title="商品编辑" :width="700" :height="450">
      <vol-form
        ref="editForm"
        :formFields="editFormFields"
        :formRules="editFormRules"
        :labelWidth="90"
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
const url = '/api/DC/DC_MktSpu/'
const searchFormFields = reactive({ categoryId: '', title: '', enabled: '' })
const searchFormRules = [
  [
    { title: '分类', field: 'categoryId', type: 'select', data: [] },
    { title: '商品名称', field: 'title', type: 'like' },
    { title: '启用', field: 'enabled', type: 'select', data: [{ key: 1, value: '是' }, { key: 0, value: '否' }] }
  ]
]
const editFormFields = reactive({ categoryId: '', title: '', name: '', pic: '', price: 0, value: 0, seq: 0, enabled: 1, remark: '' })
const editFormRules = [
  [{ title: '分类', field: 'categoryId', required: true, type: 'select', data: [] }, { title: '商品标题', field: 'title', required: true }],
  [{ title: '商品名称', field: 'name' }, { title: '图片', field: 'pic', type: 'img' }],
  [{ title: '价格', field: 'price', type: 'number' }, { title: '价值', field: 'value', type: 'number' }],
  [{ title: '排序', field: 'seq', type: 'number' }, { title: '启用', field: 'enabled', type: 'select', data: [{ key: 1, value: '是' }, { key: 0, value: '否' }] }],
  [{ title: '备注', field: 'remark', type: 'textarea', colSize: 24 }]
]
const columns = reactive([
  { field: 'categoryId', title: '分类', type: 'int', width: 100, bind: { key: 'dc_mkt_category', data: [] } },
  { field: 'title', title: '商品标题', type: 'string', width: 150, sort: true },
  { field: 'name', title: '商品名称', type: 'string', width: 120 },
  { field: 'pic', title: '图片', type: 'img', width: 80 },
  { field: 'price', title: '价格', type: 'decimal', width: 90 },
  { field: 'value', title: '价值', type: 'decimal', width: 90 },
  { field: 'seq', title: '排序', type: 'int', width: 70 },
  { field: 'enabled', title: '启用', type: 'byte', width: 70, bind: { key: 'enable', data: [] } },
  { field: 'remark', title: '备注', type: 'string', width: 120 },
  { field: 'createDate', title: '创建时间', type: 'datetime', width: 140, sort: true }
])
const pagination = reactive({ total: 0, size: 30, sortName: 'Seq' })
const editBoxVisible = ref(false)
const currentRow = ref(null)
const table = ref(null)
const searchForm = ref(null)
const editForm = ref(null)
const search = () => {
  let wheres = []
  if (searchFormFields.categoryId) wheres.push({ name: 'categoryId', value: searchFormFields.categoryId })
  if (searchFormFields.title) wheres.push({ name: 'title', value: searchFormFields.title, displayType: 'like' })
  if (searchFormFields.enabled !== '') wheres.push({ name: 'enabled', value: searchFormFields.enabled })
  table.value.load(wheres)
}
const resetSearch = () => {
  Object.keys(searchFormFields).forEach(k => { searchFormFields[k] = '' })
  table.value.load([])
}
const add = () => {
  Object.keys(editFormFields).forEach(k => {
    if (typeof editFormFields[k] === 'number') editFormFields[k] = 0
    else editFormFields[k] = ''
  })
  editFormFields.enabled = 1
  currentRow.value = null
  editBoxVisible.value = true
}
const edit = () => {
  let rows = table.value.getSelected()
  if (!rows || rows.length === 0) return proxy.$message.warning('请选择要编辑的行')
  if (rows.length > 1) return proxy.$message.warning('只能选择一行进行编辑')
  currentRow.value = rows[0]
  Object.keys(editFormFields).forEach(k => { editFormFields[k] = rows[0][k] ?? editFormFields[k] })
  editBoxVisible.value = true
}
const del = () => {
  let rows = table.value.getSelected()
  if (!rows || rows.length === 0) return proxy.$message.warning('请选择要删除的行')
  proxy.$confirm('确认要删除选中的数据吗?', '提示', { type: 'warning' }).then(() => {
    let ids = rows.map(r => r.id || r.Id)
    proxy.http.post(url + 'del', ids, true).then(result => {
      if (result.status) { proxy.$message.success('删除成功'); table.value.load() }
      else proxy.$message.error(result.message)
    })
  })
}
const save = () => {
  let params = { ...editFormFields }
  if (currentRow.value) {
    params.id = currentRow.value.id || currentRow.value.Id
    proxy.http.post(url + 'update', params, true).then(result => {
      if (result.status) { proxy.$message.success('保存成功'); editBoxVisible.value = false; table.value.load() }
      else proxy.$message.error(result.message)
    })
  } else {
    proxy.http.post(url + 'add', params, true).then(result => {
      if (result.status) { proxy.$message.success('新建成功'); editBoxVisible.value = false; table.value.load() }
      else proxy.$message.error(result.message)
    })
  }
}
</script>
<style lang="less" scoped>
.dc-mkt-spus { padding: 10px; }
.btn-group { padding: 6px 0; display: flex; gap: 6px; }
</style>
