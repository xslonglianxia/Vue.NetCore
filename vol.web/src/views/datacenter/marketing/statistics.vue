<template>
  <div class="dc-mkt-statistics">
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
const url = '/api/DC/DC_MktStatistic/'
const searchFormFields = reactive({ dateRange: '' })
const searchFormRules = [
  [
    { title: '日期范围', field: 'dateRange', type: 'datetime', range: true }
  ]
]
const columns = reactive([
  { field: 'date', title: '日期', type: 'string', width: 100, sort: true },
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
  { field: 'taskCompleteNumber', title: '任务完成数', type: 'int', width: 90 }
])
const pagination = reactive({ total: 0, size: 30, sortName: 'Date' })
const table = ref(null)
const searchForm = ref(null)
const search = () => {
  let wheres = []
  if (searchFormFields.dateRange) wheres.push({ name: 'date', value: searchFormFields.dateRange, displayType: 'range' })
  table.value.load(wheres)
}
const resetSearch = () => {
  Object.keys(searchFormFields).forEach(k => { searchFormFields[k] = '' })
  table.value.load([])
}
</script>
<style lang="less" scoped>
.dc-mkt-statistics { padding: 10px; }
</style>
