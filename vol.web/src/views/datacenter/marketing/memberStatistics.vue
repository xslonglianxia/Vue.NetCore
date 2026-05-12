<template>
  <div class="dc-mkt-member-statistics">
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
    <vol-table
      ref="table"
      :columns="columns"
      :url="url"
      :pagination="pagination"
      :ck="false"
      :index="true"
    />
  </div>
</template>
<script setup>
import VolTable from '@/components/basic/VolTable.vue'
import VolForm from '@/components/basic/VolForm.vue'
import { ref, reactive, getCurrentInstance } from 'vue'
const { proxy } = getCurrentInstance()
const url = '/api/DC/DC_MktMemberStatistic/'
const searchFormFields = reactive({ memberUsername: '', enabled: '', lockedStatus: '', virtualStatus: '' })
const searchFormRules = [
  [
    { title: '会员账号', field: 'memberUsername', type: 'like' },
    { title: '启用', field: 'enabled', type: 'select', data: [{ key: 1, value: '是' }, { key: 0, value: '否' }] },
    { title: '锁定', field: 'lockedStatus', type: 'select', data: [{ key: 1, value: '是' }, { key: 0, value: '否' }] },
    { title: '虚拟', field: 'virtualStatus', type: 'select', data: [{ key: 1, value: '是' }, { key: 0, value: '否' }] }
  ]
]
const columns = reactive([
  { field: 'memberUsername', title: '会员账号', type: 'string', width: 110, sort: true },
  { field: 'enabled', title: '启用', type: 'byte', width: 60, bind: { key: 'enable', data: [] } },
  { field: 'lockedStatus', title: '锁定', type: 'byte', width: 60, bind: { key: 'enable', data: [] } },
  { field: 'virtualStatus', title: '虚拟', type: 'byte', width: 60, bind: { key: 'enable', data: [] } },
  { field: 'allowInvitations', title: '允许邀请', type: 'byte', width: 80, bind: { key: 'enable', data: [] } },
  { field: 'orderSeq', title: '排序', type: 'int', width: 70 },
  { field: 'signSeq', title: '签到序号', type: 'int', width: 80 },
  { field: 'popUpNumber', title: '弹窗数', type: 'int', width: 80 },
  { field: 'rechargeAmount', title: '充值金额', type: 'decimal', width: 100 },
  { field: 'rechargeNumber', title: '充值次数', type: 'int', width: 80 },
  { field: 'withdrawalAmount', title: '提现金额', type: 'decimal', width: 100 },
  { field: 'withdrawalNumber', title: '提现次数', type: 'int', width: 80 },
  { field: 'commissionAmount', title: '佣金金额', type: 'decimal', width: 100 },
  { field: 'commissionNumber', title: '佣金次数', type: 'int', width: 80 },
  { field: 'parentCommissionAmount', title: '上级佣金金额', type: 'decimal', width: 110 },
  { field: 'parentCommissionNumber', title: '上级佣金次数', type: 'int', width: 110 },
  { field: 'giveAmount', title: '赠送金额', type: 'decimal', width: 90 },
  { field: 'giveNumber', title: '赠送次数', type: 'int', width: 80 },
  { field: 'signAmount', title: '签到金额', type: 'decimal', width: 90 },
  { field: 'signNumber', title: '签到次数', type: 'int', width: 80 },
  { field: 'orderNumber', title: '订单数', type: 'int', width: 80 },
  { field: 'taskCompleteNumber', title: '任务完成数', type: 'int', width: 90 },
  { field: 'resetNumber', title: '重置次数', type: 'int', width: 80 },
  { field: 'lastSignDate', title: '最后签到', type: 'datetime', width: 140 }
])
const pagination = reactive({ total: 0, size: 30, sortName: 'MemberUsername' })
const table = ref(null)
const searchForm = ref(null)
const search = () => {
  let wheres = []
  if (searchFormFields.memberUsername) wheres.push({ name: 'memberUsername', value: searchFormFields.memberUsername, displayType: 'like' })
  if (searchFormFields.enabled !== '') wheres.push({ name: 'enabled', value: searchFormFields.enabled })
  if (searchFormFields.lockedStatus !== '') wheres.push({ name: 'lockedStatus', value: searchFormFields.lockedStatus })
  if (searchFormFields.virtualStatus !== '') wheres.push({ name: 'virtualStatus', value: searchFormFields.virtualStatus })
  table.value.load(wheres)
}
const resetSearch = () => {
  Object.keys(searchFormFields).forEach(k => { searchFormFields[k] = '' })
  table.value.load([])
}
</script>
<style lang="less" scoped>
.dc-mkt-member-statistics { padding: 10px; }
</style>
