<template>
  <div class="dc-mkt-member-login-logs">
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
const url = '/api/DC/DC_MktMemberLoginLog/'
const searchFormFields = reactive({ memberUsername: '', ip: '', success: '', createDateRange: '' })
const searchFormRules = [
  [
    { title: '会员账号', field: 'memberUsername', type: 'like' },
    { title: 'IP', field: 'ip' },
    { title: '成功', field: 'success', type: 'select', data: [{ key: 1, value: '是' }, { key: 0, value: '否' }] }
  ],
  [
    { title: '创建日期', field: 'createDateRange', type: 'datetime', range: true }
  ]
]
const columns = reactive([
  { field: 'memberUsername', title: '会员账号', type: 'string', width: 120, sort: true },
  { field: 'param', title: '参数', type: 'string', width: 150 },
  { field: 'ip', title: 'IP', type: 'string', width: 120 },
  { field: 'address', title: '地址', type: 'string', width: 150 },
  { field: 'success', title: '成功', type: 'byte', width: 70, bind: { key: 'enable', data: [] } },
  { field: 'createDate', title: '创建时间', type: 'datetime', width: 140, sort: true }
])
const pagination = reactive({ total: 0, size: 30, sortName: 'CreateDate' })
const table = ref(null)
const searchForm = ref(null)
const search = () => {
  let wheres = []
  if (searchFormFields.memberUsername) wheres.push({ name: 'memberUsername', value: searchFormFields.memberUsername, displayType: 'like' })
  if (searchFormFields.ip) wheres.push({ name: 'ip', value: searchFormFields.ip })
  if (searchFormFields.success !== '') wheres.push({ name: 'success', value: searchFormFields.success })
  if (searchFormFields.createDateRange) wheres.push({ name: 'createDate', value: searchFormFields.createDateRange, displayType: 'range' })
  table.value.load(wheres)
}
const resetSearch = () => {
  Object.keys(searchFormFields).forEach(k => { searchFormFields[k] = '' })
  table.value.load([])
}
</script>
<style lang="less" scoped>
.dc-mkt-member-login-logs { padding: 10px; }
</style>
