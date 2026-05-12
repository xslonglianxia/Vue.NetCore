<template>
  <div class="dc-pts-flows">
    <vol-form
      ref="searchForm"
      :formFields="searchFields"
      :formRules="searchRules"
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
const url = '/api/DC/DC_PtsFlow/'
const searchFields = reactive({
  memberUsername: '',
  pointsRange: [null, null],
  createDateRange: ''
})
const searchRules = [
  [
    { title: '用户名', field: 'memberUsername', type: 'like' },
    { title: '积分范围', field: 'pointsRange', type: 'range' },
    { title: '创建时间', field: 'createDateRange', type: 'datetime', range: true }
  ]
]
const columns = reactive([
  { field: 'flowNo', title: '流水号', type: 'string', width: 150 },
  { field: 'tradingNo', title: '交易号', type: 'string', width: 150 },
  { field: 'memberUsername', title: '用户名', type: 'string', width: 120 },
  { field: 'memberPhone', title: '手机号', type: 'string', width: 120 },
  { field: 'points', title: '积分', type: 'int', width: 80 },
  { field: 'beforePoints', title: '变动前积分', type: 'int', width: 100 },
  { field: 'afterPoints', title: '变动后积分', type: 'int', width: 100 },
  { field: 'remark', title: '备注', type: 'string', width: 180 },
  { field: 'createDate', title: '创建时间', type: 'datetime', width: 140, sort: true }
])
const pagination = reactive({ total: 0, size: 30, sortName: 'CreateDate' })
const table = ref(null)
const searchForm = ref(null)
const search = () => {
  let wheres = []
  if (searchFields.memberUsername) wheres.push({ name: 'memberUsername', value: searchFields.memberUsername, displayType: 'like' })
  if (searchFields.pointsRange[0] != null) wheres.push({ name: 'points', value: searchFields.pointsRange[0], displayType: 'thanorequal' })
  if (searchFields.pointsRange[1] != null) wheres.push({ name: 'points', value: searchFields.pointsRange[1], displayType: 'lessorequal' })
  if (searchFields.createDateRange) wheres.push({ name: 'createDate', value: searchFields.createDateRange, displayType: 'range' })
  table.value.load(wheres)
}
const resetSearch = () => {
  searchFields.memberUsername = ''
  searchFields.pointsRange = [null, null]
  searchFields.createDateRange = ''
  table.value.load([])
}
</script>
<style lang="less" scoped>
.dc-pts-flows {
  padding: 10px;
}
</style>
