<template>
  <div class="dc-mkt-bulletins">
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
    <vol-box v-model="editBoxVisible" title="公告编辑" :width="800" :height="550">
      <vol-form
        ref="editForm"
        :formFields="editFormFields"
        :formRules="editFormRules"
        :labelWidth="90"
      />
      <div class="editor-wrap">
        <vol-wang-editor ref="editor" :editorContent="editFormFields.content" @contentChange="onContentChange" />
      </div>
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
import VolWangEditor from '@/components/editor/VolWangEditor.vue'
import { ref, reactive, getCurrentInstance } from 'vue'
const { proxy } = getCurrentInstance()
const url = '/api/DC/DC_MktBulletin/'
const searchFormFields = reactive({ title: '', enabled: '' })
const searchFormRules = [
  [
    { title: '标题', field: 'title', type: 'like' },
    { title: '启用', field: 'enabled', type: 'select', data: [{ key: 1, value: '是' }, { key: 0, value: '否' }] }
  ]
]
const editFormFields = reactive({ title: '', content: '', seq: 0, enabled: 1 })
const editFormRules = [
  [{ title: '标题', field: 'title', required: true }, { title: '排序', field: 'seq', type: 'number' }],
  [{ title: '启用', field: 'enabled', type: 'select', data: [{ key: 1, value: '是' }, { key: 0, value: '否' }] }]
]
const columns = reactive([
  { field: 'title', title: '标题', type: 'string', width: 200, sort: true },
  { field: 'content', title: '内容', type: 'string', width: 250 },
  { field: 'seq', title: '排序', type: 'int', width: 70 },
  { field: 'enabled', title: '启用', type: 'byte', width: 70, bind: { key: 'enable', data: [] } },
  { field: 'createDate', title: '创建时间', type: 'datetime', width: 140, sort: true }
])
const pagination = reactive({ total: 0, size: 30, sortName: 'Seq' })
const editBoxVisible = ref(false)
const currentRow = ref(null)
const table = ref(null)
const searchForm = ref(null)
const editForm = ref(null)
const editor = ref(null)
const onContentChange = (html) => {
  editFormFields.content = html
}
const search = () => {
  let wheres = []
  if (searchFormFields.title) wheres.push({ name: 'title', value: searchFormFields.title, displayType: 'like' })
  if (searchFormFields.enabled !== '') wheres.push({ name: 'enabled', value: searchFormFields.enabled })
  table.value.load(wheres)
}
const resetSearch = () => {
  Object.keys(searchFormFields).forEach(k => { searchFormFields[k] = '' })
  table.value.load([])
}
const add = () => {
  editFormFields.title = ''
  editFormFields.content = ''
  editFormFields.seq = 0
  editFormFields.enabled = 1
  currentRow.value = null
  editBoxVisible.value = true
}
const edit = () => {
  let rows = table.value.getSelected()
  if (!rows || rows.length === 0) return proxy.$message.warning('请选择要编辑的行')
  if (rows.length > 1) return proxy.$message.warning('只能选择一行进行编辑')
  currentRow.value = rows[0]
  editFormFields.title = rows[0].title || ''
  editFormFields.content = rows[0].content || ''
  editFormFields.seq = rows[0].seq ?? 0
  editFormFields.enabled = rows[0].enabled ?? 1
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
.dc-mkt-bulletins { padding: 10px; }
.btn-group { padding: 6px 0; display: flex; gap: 6px; }
.editor-wrap { padding: 0 10px; }
</style>
