<template>
  <div class="dc-mkt-withdrawal-records">
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
      <el-button type="primary" @click="auditRow">审 核</el-button>
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
    <vol-box v-model="auditBoxVisible" title="审核" :width="500" :height="300">
      <vol-form
        ref="auditForm"
        :formFields="auditFormFields"
        :formRules="auditFormRules"
        :labelWidth="90"
      />
      <template #footer>
        <el-button type="success" @click="auditPass">通 过</el-button>
        <el-button type="danger" @click="auditReject">拒 绝</el-button>
        <el-button @click="auditBoxVisible = false">关 闭</el-button>
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
const url = '/api/DC/DC_MktWithdrawalRecord/'
const searchFormFields = reactive({ orderNo: '', memberUsername: '', status: '', amountRange: '', createDateRange: '' })
const searchFormRules = [
  [
    { title: '订单号', field: 'orderNo' },
    { title: '会员账号', field: 'memberUsername', type: 'like' },
    { title: '状态', field: 'status', type: 'select', data: [] }
  ],
  [
    { title: '金额范围', field: 'amountRange' },
    { title: '创建日期', field: 'createDateRange', type: 'datetime', range: true }
  ]
]
const auditFormFields = reactive({ auditStatus: '', remark: '' })
const auditFormRules = [
  [{ title: '审核结果', field: 'auditStatus', required: true, type: 'select', data: [{ key: 1, value: '通过' }, { key: 2, value: '拒绝' }] }],
  [{ title: '备注', field: 'remark', type: 'textarea', colSize: 24 }]
]
const columns = reactive([
  { field: 'orderNo', title: '订单号', type: 'string', width: 140, sort: true },
  { field: 'memberUsername', title: '会员账号', type: 'string', width: 110 },
  { field: 'memberPhone', title: '手机号', type: 'string', width: 110 },
  { field: 'parentMemberUsername', title: '上级账号', type: 'string', width: 100 },
  { field: 'kindId', title: '类型', type: 'int', width: 80, bind: { key: 'dc_mkt_withdrawal_kind', data: [] } },
  { field: 'tradingKind', title: '交易类型', type: 'string', width: 90 },
  { field: 'walletAddress', title: '钱包地址', type: 'string', width: 150 },
  { field: 'amount', title: '金额', type: 'decimal', width: 100 },
  { field: 'fee', title: '手续费', type: 'decimal', width: 90 },
  { field: 'amountAfterConversion', title: '转换后金额', type: 'decimal', width: 110 },
  { field: 'attachment', title: '附件', type: 'string', width: 100 },
  { field: 'status', title: '状态', type: 'int', width: 80, bind: { key: 'dc_mkt_audit_status', data: [] } },
  { field: 'virtualStatus', title: '虚拟状态', type: 'byte', width: 80 },
  { field: 'hidden', title: '隐藏', type: 'byte', width: 70, bind: { key: 'enable', data: [] } },
  { field: 'remark', title: '备注', type: 'string', width: 120 },
  { field: 'createDate', title: '创建时间', type: 'datetime', width: 140, sort: true }
])
const pagination = reactive({ total: 0, size: 30, sortName: 'CreateDate' })
const auditBoxVisible = ref(false)
const currentRows = ref([])
const table = ref(null)
const searchForm = ref(null)
const auditForm = ref(null)
const search = () => {
  let wheres = []
  if (searchFormFields.orderNo) wheres.push({ name: 'orderNo', value: searchFormFields.orderNo })
  if (searchFormFields.memberUsername) wheres.push({ name: 'memberUsername', value: searchFormFields.memberUsername, displayType: 'like' })
  if (searchFormFields.status !== '') wheres.push({ name: 'status', value: searchFormFields.status })
  if (searchFormFields.amountRange) wheres.push({ name: 'amount', value: searchFormFields.amountRange, displayType: 'range' })
  if (searchFormFields.createDateRange) wheres.push({ name: 'createDate', value: searchFormFields.createDateRange, displayType: 'range' })
  table.value.load(wheres)
}
const resetSearch = () => {
  Object.keys(searchFormFields).forEach(k => { searchFormFields[k] = '' })
  table.value.load([])
}
const auditRow = () => {
  let rows = table.value.getSelected()
  if (!rows || rows.length === 0) return proxy.$message.warning('请选择要审核的记录')
  currentRows.value = rows
  auditFormFields.auditStatus = ''
  auditFormFields.remark = ''
  auditBoxVisible.value = true
}
const auditPass = () => {
  let ids = currentRows.value.map(r => r.id || r.Id)
  proxy.http.post(url + 'audit', { ids, auditStatus: 1, remark: auditFormFields.remark }, true).then(result => {
    if (result.status) { proxy.$message.success('审核通过'); auditBoxVisible.value = false; table.value.load() }
    else proxy.$message.error(result.message)
  })
}
const auditReject = () => {
  let ids = currentRows.value.map(r => r.id || r.Id)
  proxy.http.post(url + 'audit', { ids, auditStatus: 2, remark: auditFormFields.remark }, true).then(result => {
    if (result.status) { proxy.$message.success('已拒绝'); auditBoxVisible.value = false; table.value.load() }
    else proxy.$message.error(result.message)
  })
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
.dc-mkt-withdrawal-records { padding: 10px; }
.btn-group { padding: 6px 0; display: flex; gap: 6px; }
</style>
