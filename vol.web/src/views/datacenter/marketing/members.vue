<template>
  <div class="dc-mkt-members">
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
      <el-button type="warning" @click="freeze">冻 结</el-button>
      <el-button type="info" @click="unfreeze">解 冻</el-button>
      <el-button type="primary" plain @click="adjustBalance">调整余额</el-button>
    </div>
    <vol-table
      ref="table"
      :columns="columns"
      :url="url"
      :pagination="pagination"
      :ck="true"
      :index="true"
    />
    <vol-box v-model="editBoxVisible" title="会员编辑" :width="800" :height="500">
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
    <vol-box v-model="balanceBoxVisible" title="调整余额" :width="500" :height="300">
      <vol-form
        ref="balanceForm"
        :formFields="balanceFormFields"
        :formRules="balanceFormRules"
        :labelWidth="100"
      />
      <template #footer>
        <el-button type="primary" @click="saveBalance">确 定</el-button>
        <el-button @click="balanceBoxVisible = false">关 闭</el-button>
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
const url = '/api/DC/DC_MktMember/'
const searchFormFields = reactive({
  memberUsername: '',
  memberPhone: '',
  levelId: '',
  enabled: '',
  lockedStatus: '',
  virtualStatus: '',
  availableBalanceRange: '',
  reputationScopeRange: '',
  createDateRange: ''
})
const searchFormRules = [
  [
    { title: '会员账号', field: 'memberUsername', type: 'like' },
    { title: '手机号', field: 'memberPhone' },
    { title: '等级', field: 'levelId', type: 'select', data: [] }
  ],
  [
    { title: '启用', field: 'enabled', type: 'select', data: [{ key: 1, value: '是' }, { key: 0, value: '否' }] },
    { title: '锁定', field: 'lockedStatus', type: 'select', data: [{ key: 1, value: '是' }, { key: 0, value: '否' }] },
    { title: '虚拟', field: 'virtualStatus', type: 'select', data: [{ key: 1, value: '是' }, { key: 0, value: '否' }] }
  ],
  [
    { title: '可用余额范围', field: 'availableBalanceRange' },
    { title: '信誉范围', field: 'reputationScopeRange' },
    { title: '创建日期', field: 'createDateRange', type: 'datetime', range: true }
  ]
]
const editFormFields = reactive({
  memberUsername: '',
  memberPhone: '',
  email: '',
  gender: '',
  levelId: '',
  inviteCode: '',
  parentUsername: '',
  balance: 0,
  availableBalance: 0,
  freezeBalance: 0,
  reputationScope: 0,
  enabled: 1,
  lockedStatus: 0,
  virtualStatus: 0,
  onlineStatus: 0,
  lastLoginDate: '',
  lastLoginIp: '',
  allowInvitations: 1,
  orderSeq: 0,
  signSeq: 0,
  signNumber: 0,
  resetNumber: 0,
  taskCompleteNumber: 0,
  childrenNumber: 0,
  rechargeAmount: 0,
  withdrawalAmount: 0
})
const editFormRules = [
  [
    { title: '会员账号', field: 'memberUsername', required: true },
    { title: '手机号', field: 'memberPhone' },
    { title: '邮箱', field: 'email' }
  ],
  [
    { title: '性别', field: 'gender', type: 'select', data: [{ key: 0, value: '女' }, { key: 1, value: '男' }] },
    { title: '等级', field: 'levelId', type: 'select', data: [] },
    { title: '邀请码', field: 'inviteCode' }
  ],
  [
    { title: '上级账号', field: 'parentUsername' },
    { title: '余额', field: 'balance', type: 'number' },
    { title: '可用余额', field: 'availableBalance', type: 'number' }
  ],
  [
    { title: '冻结余额', field: 'freezeBalance', type: 'number' },
    { title: '信誉范围', field: 'reputationScope', type: 'number' },
    { title: '启用', field: 'enabled', type: 'select', data: [{ key: 1, value: '是' }, { key: 0, value: '否' }] }
  ],
  [
    { title: '锁定', field: 'lockedStatus', type: 'select', data: [{ key: 1, value: '是' }, { key: 0, value: '否' }] },
    { title: '虚拟', field: 'virtualStatus', type: 'select', data: [{ key: 1, value: '是' }, { key: 0, value: '否' }] },
    { title: '在线', field: 'onlineStatus', type: 'select', data: [{ key: 1, value: '是' }, { key: 0, value: '否' }] }
  ],
  [
    { title: '允许邀请', field: 'allowInvitations', type: 'select', data: [{ key: 1, value: '是' }, { key: 0, value: '否' }] },
    { title: '排序', field: 'orderSeq', type: 'number' },
    { title: '签到序号', field: 'signSeq', type: 'number' }
  ],
  [
    { title: '签到次数', field: 'signNumber', type: 'number' },
    { title: '重置次数', field: 'resetNumber', type: 'number' },
    { title: '任务完成数', field: 'taskCompleteNumber', type: 'number' }
  ],
  [
    { title: '下级数量', field: 'childrenNumber', type: 'number' },
    { title: '充值金额', field: 'rechargeAmount', type: 'number' },
    { title: '提现金额', field: 'withdrawalAmount', type: 'number' }
  ]
]
const balanceFormFields = reactive({
  adjustKind: '',
  amount: 0,
  remark: ''
})
const balanceFormRules = [
  [{ title: '调整类型', field: 'adjustKind', required: true, type: 'select', data: [{ key: 1, value: '增加' }, { key: 2, value: '减少' }] }],
  [{ title: '金额', field: 'amount', required: true, type: 'number' }],
  [{ title: '备注', field: 'remark', type: 'textarea', colSize: 24 }]
]
const columns = reactive([
  { field: 'memberUsername', title: '会员账号', type: 'string', width: 110, sort: true },
  { field: 'memberPhone', title: '手机号', type: 'string', width: 110 },
  { field: 'email', title: '邮箱', type: 'string', width: 150 },
  { field: 'gender', title: '性别', type: 'int', width: 60, bind: { key: 'gender', data: [] } },
  { field: 'levelId', title: '等级', type: 'int', width: 80, bind: { key: 'dc_mkt_level', data: [] } },
  { field: 'inviteCode', title: '邀请码', type: 'string', width: 100 },
  { field: 'parentUsername', title: '上级账号', type: 'string', width: 100 },
  { field: 'balance', title: '余额', type: 'decimal', width: 100 },
  { field: 'availableBalance', title: '可用余额', type: 'decimal', width: 100 },
  { field: 'freezeBalance', title: '冻结余额', type: 'decimal', width: 100 },
  { field: 'reputationScope', title: '信誉范围', type: 'int', width: 80 },
  { field: 'enabled', title: '启用', type: 'byte', width: 70, bind: { key: 'enable', data: [] } },
  { field: 'lockedStatus', title: '锁定', type: 'byte', width: 70, bind: { key: 'enable', data: [] } },
  { field: 'virtualStatus', title: '虚拟', type: 'byte', width: 70, bind: { key: 'enable', data: [] } },
  { field: 'onlineStatus', title: '在线', type: 'byte', width: 70, bind: { key: 'enable', data: [] } },
  { field: 'lastLoginDate', title: '最后登录', type: 'datetime', width: 140 },
  { field: 'lastLoginIp', title: '最后IP', type: 'string', width: 120 },
  { field: 'allowInvitations', title: '允许邀请', type: 'byte', width: 80, bind: { key: 'enable', data: [] } },
  { field: 'orderSeq', title: '排序', type: 'int', width: 70 },
  { field: 'signSeq', title: '签到序号', type: 'int', width: 80 },
  { field: 'signNumber', title: '签到次数', type: 'int', width: 80 },
  { field: 'resetNumber', title: '重置次数', type: 'int', width: 80 },
  { field: 'taskCompleteNumber', title: '任务完成数', type: 'int', width: 90 },
  { field: 'childrenNumber', title: '下级数量', type: 'int', width: 80 },
  { field: 'rechargeAmount', title: '充值金额', type: 'decimal', width: 100 },
  { field: 'withdrawalAmount', title: '提现金额', type: 'decimal', width: 100 },
  { field: 'createDate', title: '创建时间', type: 'datetime', width: 140, sort: true }
])
const pagination = reactive({ total: 0, size: 30, sortName: 'CreateDate' })
const editBoxVisible = ref(false)
const balanceBoxVisible = ref(false)
const currentRow = ref(null)
const table = ref(null)
const searchForm = ref(null)
const editForm = ref(null)
const balanceForm = ref(null)
const search = () => {
  let wheres = []
  if (searchFormFields.memberUsername) wheres.push({ name: 'memberUsername', value: searchFormFields.memberUsername, displayType: 'like' })
  if (searchFormFields.memberPhone) wheres.push({ name: 'memberPhone', value: searchFormFields.memberPhone, displayType: 'like' })
  if (searchFormFields.levelId !== '') wheres.push({ name: 'levelId', value: searchFormFields.levelId })
  if (searchFormFields.enabled !== '') wheres.push({ name: 'enabled', value: searchFormFields.enabled })
  if (searchFormFields.lockedStatus !== '') wheres.push({ name: 'lockedStatus', value: searchFormFields.lockedStatus })
  if (searchFormFields.virtualStatus !== '') wheres.push({ name: 'virtualStatus', value: searchFormFields.virtualStatus })
  if (searchFormFields.availableBalanceRange) wheres.push({ name: 'availableBalance', value: searchFormFields.availableBalanceRange, displayType: 'range' })
  if (searchFormFields.reputationScopeRange) wheres.push({ name: 'reputationScope', value: searchFormFields.reputationScopeRange, displayType: 'range' })
  if (searchFormFields.createDateRange) wheres.push({ name: 'createDate', value: searchFormFields.createDateRange, displayType: 'range' })
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
  editFormFields.enabled = 1
  editFormFields.allowInvitations = 1
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
      if (result.status) {
        proxy.$message.success('删除成功')
        table.value.load()
      } else {
        proxy.$message.error(result.message)
      }
    })
  })
}
const save = () => {
  let params = { ...editFormFields }
  if (currentRow.value) {
    params.id = currentRow.value.id || currentRow.value.Id
    proxy.http.post(url + 'update', params, true).then(result => {
      if (result.status) {
        proxy.$message.success('保存成功')
        editBoxVisible.value = false
        table.value.load()
      } else {
        proxy.$message.error(result.message)
      }
    })
  } else {
    proxy.http.post(url + 'add', params, true).then(result => {
      if (result.status) {
        proxy.$message.success('新建成功')
        editBoxVisible.value = false
        table.value.load()
      } else {
        proxy.$message.error(result.message)
      }
    })
  }
}
const freeze = () => {
  let rows = table.value.getSelected()
  if (!rows || rows.length === 0) return proxy.$message.warning('请选择要冻结的行')
  let ids = rows.map(r => r.id || r.Id)
  proxy.http.post(url + 'freeze', ids, true).then(result => {
    if (result.status) {
      proxy.$message.success('冻结成功')
      table.value.load()
    } else {
      proxy.$message.error(result.message)
    }
  })
}
const unfreeze = () => {
  let rows = table.value.getSelected()
  if (!rows || rows.length === 0) return proxy.$message.warning('请选择要解冻的行')
  let ids = rows.map(r => r.id || r.Id)
  proxy.http.post(url + 'unfreeze', ids, true).then(result => {
    if (result.status) {
      proxy.$message.success('解冻成功')
      table.value.load()
    } else {
      proxy.$message.error(result.message)
    }
  })
}
const adjustBalance = () => {
  let rows = table.value.getSelected()
  if (!rows || rows.length === 0) return proxy.$message.warning('请选择要调整余额的行')
  if (rows.length > 1) return proxy.$message.warning('只能选择一行进行操作')
  currentRow.value = rows[0]
  balanceFormFields.adjustKind = ''
  balanceFormFields.amount = 0
  balanceFormFields.remark = ''
  balanceBoxVisible.value = true
}
const saveBalance = () => {
  if (!balanceFormFields.adjustKind) return proxy.$message.warning('请选择调整类型')
  if (!balanceFormFields.amount) return proxy.$message.warning('请输入金额')
  let params = {
    id: currentRow.value.id || currentRow.value.Id,
    adjustKind: balanceFormFields.adjustKind,
    amount: balanceFormFields.amount,
    remark: balanceFormFields.remark
  }
  proxy.http.post(url + 'adjustBalance', params, true).then(result => {
    if (result.status) {
      proxy.$message.success('调整成功')
      balanceBoxVisible.value = false
      table.value.load()
    } else {
      proxy.$message.error(result.message)
    }
  })
}
</script>
<style lang="less" scoped>
.dc-mkt-members {
  padding: 10px;
}
.btn-group {
  padding: 6px 0;
  display: flex;
  gap: 6px;
}
</style>
