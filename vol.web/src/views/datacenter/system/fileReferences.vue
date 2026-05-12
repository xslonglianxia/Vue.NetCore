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
    <vol-box v-model="previewModel" :height="600" :width="800" title="文件预览">
      <div class="preview-container">
        <img v-if="previewType === 'img'" :src="previewUrl" style="max-width: 100%; max-height: 100%" />
        <iframe v-else-if="previewType === 'pdf'" :src="previewUrl" style="width: 100%; height: 500px; border: none"></iframe>
        <div v-else class="no-preview">该文件类型不支持在线预览</div>
      </div>
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
const url = '/api/DC/DC_SysFileReference/'
const model = ref(false)
const previewModel = ref(false)
const boxType = ref('Add')
const boxTitle = ref('新增')
const table = ref(null)
const form = ref(null)
const currentRow = ref(null)
const previewUrl = ref('')
const previewType = ref('')

const formFields = reactive({
  name: '',
  fileId: null,
  relatedKind: '',
  relatedId: null,
  presignedUrl: '',
  remark: ''
})

const formRules = reactive([
  [
    { field: 'name', title: '名称', type: 'string', require: true },
    { field: 'fileId', title: '文件', type: 'file' }
  ],
  [
    { field: 'relatedKind', title: '关联类型', type: 'string' },
    { field: 'relatedId', title: '关联ID', type: 'number' }
  ],
  [
    { field: 'presignedUrl', title: '预签名URL', type: 'string' },
    { field: 'remark', title: '备注', type: 'textarea' }
  ]
])

const columns = reactive([
  { field: 'name', title: '名称', type: 'string', width: 150 },
  { field: 'fileId', title: '文件ID', type: 'string', width: 120 },
  { field: 'relatedKind', title: '关联类型', type: 'string', width: 100 },
  { field: 'relatedId', title: '关联ID', type: 'string', width: 100 },
  { field: 'presignedUrl', title: '预签名URL', type: 'string', width: 200 },
  { field: 'remark', title: '备注', type: 'string', width: 150 },
  { field: 'createDate', title: '创建时间', type: 'datetime', width: 150 },
  { title: '操作', width: 180, fixed: 'right', align: 'center', render: (h, { row }) => {
    return h('div', [
      h('el-button', { type: 'primary', link: true, onClick: () => edit(row) }, '编辑'),
      h('el-button', { type: 'success', link: true, onClick: () => preview(row) }, '预览'),
      h('el-button', { type: 'danger', link: true, onClick: () => delRow(row) }, '删除')
    ])
  }}
])

const pagination = reactive({ total: 0, size: 30, sortName: '' })

const loadBefore = (param) => { return true }
const loadAfter = (data) => {}

const resetForm = () => {
  Object.assign(formFields, { name: '', fileId: null, relatedKind: '', relatedId: null, presignedUrl: '', remark: '' })
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

const preview = (row) => {
  if (!row.presignedUrl) return proxy.$message.warning('该文件没有预签名URL')
  previewUrl.value = row.presignedUrl
  let ext = (row.name || '').split('.').pop().toLowerCase()
  if (['jpg', 'jpeg', 'png', 'gif', 'bmp', 'webp'].includes(ext)) {
    previewType.value = 'img'
  } else if (ext === 'pdf') {
    previewType.value = 'pdf'
  } else {
    previewType.value = 'other'
  }
  previewModel.value = true
}
</script>

<style scoped>
.vol-container {
  padding: 10px;
}
.btn-group {
  padding: 0 0 10px 0;
}
.preview-container {
  display: flex;
  justify-content: center;
  align-items: center;
  min-height: 400px;
}
.no-preview {
  color: #999;
  font-size: 16px;
}
</style>
