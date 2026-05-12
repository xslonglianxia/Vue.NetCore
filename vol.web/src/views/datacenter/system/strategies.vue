<template>
  <div class="vol-container">
    <div class="btn-group">
      <el-button type="primary" @click="add">新增</el-button>
      <el-button type="danger" @click="del">删除</el-button>
    </div>
    <vol-table ref="table" :url="url" :columns="columns" :pagination="pagination" @loadBefore="loadBefore" @loadAfter="loadAfter"></vol-table>
    <vol-box v-model="model" :height="320" :width="450" :title="boxTitle">
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
const url = '/api/DC/DC_SysStrategy/'
const model = ref(false)
const boxType = ref('Add')
const boxTitle = ref('新增')
const table = ref(null)
const form = ref(null)
const currentRow = ref(null)

const formFields = reactive({
  name: '',
  code: '',
  remark: ''
})

const formRules = reactive([
  [
    { field: 'name', title: '名称', type: 'string', require: true },
    { field: 'code', title: '编码', type: 'string', require: true }
  ],
  [
    { field: 'remark', title: '备注', type: 'textarea' }
  ]
])

const columns = reactive([
  { field: 'name', title: '名称', type: 'string', width: 200 },
  { field: 'code', title: '编码', type: 'string', width: 200 },
  { field: 'remark', title: '备注', type: 'string', width: 250 },
  { field: 'createDate', title: '创建时间', type: 'datetime', width: 150 },
  { title: '操作', width: 150, fixed: 'right', align: 'center', render: (h, { row }) => {
    return h('div', [
      h('el-button', { type: 'primary', link: true, onClick: () => edit(row) }, '编辑'),
      h('el-button', { type: 'danger', link: true, onClick: () => delRow(row) }, '删除')
    ])
  }}
])

const pagination = reactive({ total: 0, size: 30, sortName: '' })

const loadBefore = (param) => { return true }
const loadAfter = (data) => {}

const resetForm = () => {
  Object.assign(formFields, { name: '', code: '', remark: '' })
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
</script>

<style scoped>
.vol-container {
  padding: 10px;
}
.btn-group {
  padding: 0 0 10px 0;
}
</style>
