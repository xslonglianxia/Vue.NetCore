<template>
  <div class="dc-mkt-yuebao-accounts">
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
      <el-button type="primary" @click="editRow">编 辑</el-button>
    </div>
    <vol-table
      ref="table"
      :columns="columns"
      :url="url"
      :pagination="pagination"
      :ck="true"
      :index="true"
    />
    <vol-box v-model="editBoxVisible" title="余额宝账户编辑" :width="550" :height="350">
      <vol-form
        ref="editForm"
        :formFields="editFormFields"
        :formRules="editFormRules"
        :labelWidth="100"
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
const url = '/api/DC/DC_MktYuebaoAccount/'
const searchFormFields = reactive({ memberUsername: '', memberPhone: '', availableBalanceRange: '', enabled: '' })
const searchFormRules = [
  [
    { title: '会员账号', field: 'memberUsername', type: 'like' },
    { title: '手机号', field: 'memberPhone' },
    { title: '可用余额范围', field: 'availableBalanceRange' }
  ],
  [
    { title: '启用', field: 'enabled', type: 'select', data: [{ key: 1, value: '是' }, { key: 0, value: '否' }] }
  ]
]
const editFormFields = reactive({ hike: 0, hikeEnabled: 0, enabled: 1, remark: '' })
const editFormRules = [
  [{ title: '加息', field: 'hike', type: 'number' }, { title: '加息启用', field: 'hikeEnabled', type: 'select', data: [{ key: 1, value: '是' }, { key: 0, value: '否' }] }],
  [{ title: '启用', field: 'enabled', type: 'select', data: [{ key: 1, value: '是' }, { key: 0, value: '否' }] }],
  [{ title: '备注', field: 'remark', type: 'textarea', colSize: 24 }]
]
const columns = reactive([
  { field: 'memberUsername', title: '会员账号', type: 'string', width: 110, sort: true },
  { field: 'memberPhone', title: '手机号', type: 'string', width: 110 },
  { field: 'balance', title: '余额', type: 'decimal', width: 100 },
  { field: 'availableBalance', title: '可用余额', type: 'decimal', width: 100 },
  { field: 'freezeBalance', title: '冻结余额', type: 'decimal', width: 100 },
  { field: 'hike', title: '加息', type: 'decimal', width: 80 },
  { field: 'hikeEnabled', title: '加息启用', type: 'byte', width: 80, bind: { key: 'enable', data: [] } },
  { field: 'enabled', title: '启用', type: 'byte', width: 70, bind: { key: 'enable', data: [] } },
  { field: 'remark', title: '备注', type: 'string', width: 120 },
  { field: 'createDate', title: '创建时间', type: 'datetime', width: 140, sort: true }
])
const pagination = reactive({ total: 0, size: 30, sortName: 'CreateDate' })
const editBoxVisible = ref(false)
const currentRow = ref(null)
const table = ref(null)
const searchForm = ref(null)
const editForm = ref(null)
const search = () => {
  let wheres = []
  if (searchFormFields.memberUsername) wheres.push({ name: 'memberUsername', value: searchFormFields.memberUsername, displayType: 'like' })
  if (searchFormFields.memberPhone) wheres.push({ name: 'memberPhone', value: searchFormFields.memberPhone })
  if (searchFormFields.availableBalanceRange) wheres.push({ name: 'availableBalance', value: searchFormFields.availableBalanceRange, displayType: 'range' })
  if (searchFormFields.enabled !== '') wheres.push({ name: 'enabled', value: searchFormFields.enabled })
  table.value.load(wheres)
}
const resetSearch = () => {
  Object.keys(searchFormFields).forEach(k => { searchFormFields[k] = '' })
  table.value.load([])
}
const editRow = () => {
  let rows = table.value.getSelected()
  if (!rows || rows.length === 0) return proxy.$message.warning('请选择要编辑的行')
  if (rows.length > 1) return proxy.$message.warning('只能选择一行进行编辑')
  currentRow.value = rows[0]
  editFormFields.hike = rows[0].hike ?? 0
  editFormFields.hikeEnabled = rows[0].hikeEnabled ?? 0
  editFormFields.enabled = rows[0].enabled ?? 1
  editFormFields.remark = rows[0].remark || ''
  editBoxVisible.value = true
}
const save = () => {
  let params = {
    id: currentRow.value.id || currentRow.value.Id,
    hike: editFormFields.hike,
    hikeEnabled: editFormFields.hikeEnabled,
    enabled: editFormFields.enabled,
    remark: editFormFields.remark
  }
  proxy.http.post(url + 'update', params, true).then(result => {
    if (result.status) { proxy.$message.success('保存成功'); editBoxVisible.value = false; table.value.load() }
    else proxy.$message.error(result.message)
  })
}
</script>
<style lang="less" scoped>
.dc-mkt-yuebao-accounts { padding: 10px; }
.btn-group { padding: 6px 0; display: flex; gap: 6px; }
</style>
