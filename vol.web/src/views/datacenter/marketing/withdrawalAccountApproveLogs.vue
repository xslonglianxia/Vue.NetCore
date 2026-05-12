<template>
  <div class="dc-mkt-withdrawal-account-approve-logs">
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
    <vol-box v-model="editBoxVisible" title="提现账户审核日志编辑" :width="800" :height="500">
      <vol-form
        ref="editForm"
        :formFields="editFormFields"
        :formRules="editFormRules"
        :labelWidth="140"
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
const url = '/api/DC/DC_MktWithdrawalAccountApproveLog/'
const searchFormFields = reactive({ memberUsername: '', memberPhone: '' })
const searchFormRules = [
  [
    { title: '会员账号', field: 'memberUsername', type: 'like' },
    { title: '手机号', field: 'memberPhone' }
  ]
]
const editFormFields = reactive({
  memberUsername: '', memberPhone: '', parentMemberUsername: '', walletAddress: '',
  kindName: '', approveAmount: 0, accountBalance: 0, verified: 0,
  verifiedWalletAddress: '', verifiedCurrencyContractAddress: '', verifiedHash: '',
  autoSync: 0, remark: ''
})
const editFormRules = [
  [{ title: '会员账号', field: 'memberUsername', required: true }, { title: '手机号', field: 'memberPhone' }],
  [{ title: '上级账号', field: 'parentMemberUsername' }, { title: '钱包地址', field: 'walletAddress' }],
  [{ title: '类型名称', field: 'kindName' }, { title: '审核金额', field: 'approveAmount', type: 'number' }],
  [{ title: '账户余额', field: 'accountBalance', type: 'number' }, { title: '已验证', field: 'verified', type: 'select', data: [{ key: 1, value: '是' }, { key: 0, value: '否' }] }],
  [{ title: '验证钱包地址', field: 'verifiedWalletAddress' }, { title: '验证合约地址', field: 'verifiedCurrencyContractAddress' }],
  [{ title: '验证哈希', field: 'verifiedHash' }, { title: '自动同步', field: 'autoSync', type: 'select', data: [{ key: 1, value: '是' }, { key: 0, value: '否' }] }],
  [{ title: '备注', field: 'remark', type: 'textarea', colSize: 24 }]
]
const columns = reactive([
  { field: 'memberUsername', title: '会员账号', type: 'string', width: 110, sort: true },
  { field: 'memberPhone', title: '手机号', type: 'string', width: 110 },
  { field: 'parentMemberUsername', title: '上级账号', type: 'string', width: 100 },
  { field: 'walletAddress', title: '钱包地址', type: 'string', width: 150 },
  { field: 'kindName', title: '类型名称', type: 'string', width: 90 },
  { field: 'approveAmount', title: '审核金额', type: 'decimal', width: 100 },
  { field: 'accountBalance', title: '账户余额', type: 'decimal', width: 100 },
  { field: 'verified', title: '已验证', type: 'byte', width: 70, bind: { key: 'enable', data: [] } },
  { field: 'verifiedWalletAddress', title: '验证钱包地址', type: 'string', width: 150 },
  { field: 'verifiedCurrencyContractAddress', title: '验证合约地址', type: 'string', width: 150 },
  { field: 'verifiedHash', title: '验证哈希', type: 'string', width: 130 },
  { field: 'autoSync', title: '自动同步', type: 'byte', width: 80, bind: { key: 'enable', data: [] } },
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
.dc-mkt-withdrawal-account-approve-logs { padding: 10px; }
.btn-group { padding: 6px 0; display: flex; gap: 6px; }
</style>
