<template>
  <div class="dc-mkt-yuebao-trading-flows">
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
      <el-button type="warning" @click="toggleHide">隐藏/显示</el-button>
    </div>
    <vol-table
      ref="table"
      :columns="columns"
      :url="url"
      :pagination="pagination"
      :ck="true"
      :index="true"
    />
  </div>
</template>
<script setup>
import VolTable from '@/components/basic/VolTable.vue'
import VolForm from '@/components/basic/VolForm.vue'
import { ref, reactive, getCurrentInstance } from 'vue'
const { proxy } = getCurrentInstance()
const url = '/api/DC/DC_MktYuebaoTradingFlow/'
const searchFormFields = reactive({ memberUsername: '', amountRange: '', createDateRange: '' })
const searchFormRules = [
  [
    { title: '会员账号', field: 'memberUsername', type: 'like' },
    { title: '金额范围', field: 'amountRange' },
    { title: '创建日期', field: 'createDateRange', type: 'datetime', range: true }
  ]
]
const columns = reactive([
  { field: 'flowNo', title: '流水号', type: 'string', width: 140, sort: true },
  { field: 'tradingNo', title: '交易号', type: 'string', width: 140 },
  { field: 'tradingKind', title: '交易类型', type: 'string', width: 90, bind: { key: 'dc_mkt_trading_kind', data: [] } },
  { field: 'memberUsername', title: '会员账号', type: 'string', width: 110 },
  { field: 'amount', title: '金额', type: 'decimal', width: 100 },
  { field: 'beforeBalance', title: '变动前余额', type: 'decimal', width: 110 },
  { field: 'afterBalance', title: '变动后余额', type: 'decimal', width: 110 },
  { field: 'hidden', title: '隐藏', type: 'byte', width: 70, bind: { key: 'enable', data: [] } },
  { field: 'remark', title: '备注', type: 'string', width: 120 },
  { field: 'createDate', title: '创建时间', type: 'datetime', width: 140, sort: true }
])
const pagination = reactive({ total: 0, size: 30, sortName: 'CreateDate' })
const table = ref(null)
const searchForm = ref(null)
const search = () => {
  let wheres = []
  if (searchFormFields.memberUsername) wheres.push({ name: 'memberUsername', value: searchFormFields.memberUsername, displayType: 'like' })
  if (searchFormFields.amountRange) wheres.push({ name: 'amount', value: searchFormFields.amountRange, displayType: 'range' })
  if (searchFormFields.createDateRange) wheres.push({ name: 'createDate', value: searchFormFields.createDateRange, displayType: 'range' })
  table.value.load(wheres)
}
const resetSearch = () => {
  Object.keys(searchFormFields).forEach(k => { searchFormFields[k] = '' })
  table.value.load([])
}
const toggleHide = () => {
  let rows = table.value.getSelected()
  if (!rows || rows.length === 0) return proxy.$message.warning('请选择要操作的记录')
  let ids = rows.map(r => r.id || r.Id)
  proxy.http.post(url + 'toggleHide', ids, true).then(result => {
    if (result.status) { proxy.$message.success('操作成功'); table.value.load() }
    else proxy.$message.error(result.message)
  })
}
</script>
<style lang="less" scoped>
.dc-mkt-yuebao-trading-flows { padding: 10px; }
.btn-group { padding: 6px 0; display: flex; gap: 6px; }
</style>
