<template>
  <div class="dc-mkt-settings">
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
    <vol-box v-model="editBoxVisible" title="设置编辑" :width="800" :height="550">
      <vol-form
        ref="editForm"
        :formFields="editFormFields"
        :formRules="editFormRules"
        :labelWidth="120"
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
const url = '/api/DC/DC_MktSetting/'
const searchFormFields = reactive({ code: '', kind: '' })
const searchFormRules = [
  [
    { title: '编码', field: 'code' },
    { title: '类型', field: 'kind', type: 'select', data: [] }
  ]
]
const editFormFields = reactive({
  code: '', kind: '', value: '', levelSeq: 0, amount: 0, bonus: 0,
  seq: 0, url: '', message: '', interval: 0, limit: 0,
  dailyInterestRate: 0, orderNumber: 0, remark: ''
})
const editFormRules = [
  [{ title: '编码', field: 'code', required: true }, { title: '类型', field: 'kind', type: 'select', data: [] }],
  [{ title: '值', field: 'value' }, { title: '等级序号', field: 'levelSeq', type: 'number' }],
  [{ title: '金额', field: 'amount', type: 'number' }, { title: '奖励', field: 'bonus', type: 'number' }],
  [{ title: '排序', field: 'seq', type: 'number' }, { title: '链接', field: 'url' }],
  [{ title: '消息', field: 'message' }, { title: '间隔', field: 'interval', type: 'number' }],
  [{ title: '限制', field: 'limit', type: 'number' }, { title: '日利率', field: 'dailyInterestRate', type: 'number' }],
  [{ title: '订单数量', field: 'orderNumber', type: 'number' }, { title: '备注', field: 'remark', type: 'textarea' }]
]
const columns = reactive([
  { field: 'code', title: '编码', type: 'string', width: 120, sort: true },
  { field: 'kind', title: '类型', type: 'string', width: 80, bind: { key: 'dc_mkt_setting_kind', data: [] } },
  { field: 'value', title: '值', type: 'string', width: 100 },
  { field: 'levelSeq', title: '等级序号', type: 'int', width: 90 },
  { field: 'amount', title: '金额', type: 'decimal', width: 90 },
  { field: 'bonus', title: '奖励', type: 'decimal', width: 90 },
  { field: 'seq', title: '排序', type: 'int', width: 70 },
  { field: 'url', title: '链接', type: 'string', width: 120 },
  { field: 'message', title: '消息', type: 'string', width: 120 },
  { field: 'interval', title: '间隔', type: 'int', width: 70 },
  { field: 'limit', title: '限制', type: 'int', width: 70 },
  { field: 'dailyInterestRate', title: '日利率', type: 'decimal', width: 80 },
  { field: 'orderNumber', title: '订单数量', type: 'int', width: 90 },
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
  if (searchFormFields.code) wheres.push({ name: 'code', value: searchFormFields.code })
  if (searchFormFields.kind) wheres.push({ name: 'kind', value: searchFormFields.kind })
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
.dc-mkt-settings { padding: 10px; }
.btn-group { padding: 6px 0; display: flex; gap: 6px; }
</style>
