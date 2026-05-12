<template>
  <div class="dc-mkt-levels">
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
    <vol-box v-model="editBoxVisible" title="等级编辑" :width="800" :height="550">
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
const url = '/api/DC/DC_MktLevel/'
const searchFormFields = reactive({ name: '' })
const searchFormRules = [
  [{ title: '等级名称', field: 'name', type: 'like' }]
]
const editFormFields = reactive({
  name: '', icon: '', seq: 0, price: 0, balanceMin: 0, orderLimit: 0,
  completeLimit: 0, withdrawalLimit: 0, withdrawalAmountMin: 0, withdrawalAmountMax: 0,
  withdrawalFeeRate: 0, minCommissionPercentage: 0, maxCommissionPercentage: 0,
  minEvenCommissionPercentage: 0, maxEvenCommissionPercentage: 0, inviteQuantityMin: 0,
  signInBonus: 0, taskGroupsBonus: 0, productMatchEnabled: 0, remark: ''
})
const editFormRules = [
  [
    { title: '等级名称', field: 'name', required: true },
    { title: '图标', field: 'icon' },
    { title: '排序', field: 'seq', type: 'number' }
  ],
  [
    { title: '价格', field: 'price', type: 'number' },
    { title: '最低余额', field: 'balanceMin', type: 'number' },
    { title: '订单限制', field: 'orderLimit', type: 'number' }
  ],
  [
    { title: '完成限制', field: 'completeLimit', type: 'number' },
    { title: '提现限制', field: 'withdrawalLimit', type: 'number' },
    { title: '最低提现', field: 'withdrawalAmountMin', type: 'number' }
  ],
  [
    { title: '最高提现', field: 'withdrawalAmountMax', type: 'number' },
    { title: '提现费率', field: 'withdrawalFeeRate', type: 'number' },
    { title: '最低佣金比例', field: 'minCommissionPercentage', type: 'number' }
  ],
  [
    { title: '最高佣金比例', field: 'maxCommissionPercentage', type: 'number' },
    { title: '最低均分佣金比例', field: 'minEvenCommissionPercentage', type: 'number' },
    { title: '最高均分佣金比例', field: 'maxEvenCommissionPercentage', type: 'number' }
  ],
  [
    { title: '最低邀请数', field: 'inviteQuantityMin', type: 'number' },
    { title: '签到奖励', field: 'signInBonus', type: 'number' },
    { title: '任务组奖励', field: 'taskGroupsBonus', type: 'number' }
  ],
  [
    { title: '产品匹配', field: 'productMatchEnabled', type: 'select', data: [{ key: 1, value: '是' }, { key: 0, value: '否' }] },
    { title: '备注', field: 'remark', type: 'textarea', colSize: 24 }
  ]
]
const columns = reactive([
  { field: 'name', title: '等级名称', type: 'string', width: 100, sort: true },
  { field: 'icon', title: '图标', type: 'string', width: 80 },
  { field: 'seq', title: '排序', type: 'int', width: 70 },
  { field: 'price', title: '价格', type: 'decimal', width: 90 },
  { field: 'balanceMin', title: '最低余额', type: 'decimal', width: 90 },
  { field: 'orderLimit', title: '订单限制', type: 'int', width: 90 },
  { field: 'completeLimit', title: '完成限制', type: 'int', width: 90 },
  { field: 'withdrawalLimit', title: '提现限制', type: 'int', width: 90 },
  { field: 'withdrawalAmountMin', title: '最低提现', type: 'decimal', width: 90 },
  { field: 'withdrawalAmountMax', title: '最高提现', type: 'decimal', width: 90 },
  { field: 'withdrawalFeeRate', title: '提现费率', type: 'decimal', width: 90 },
  { field: 'minCommissionPercentage', title: '最低佣金比例', type: 'decimal', width: 110 },
  { field: 'maxCommissionPercentage', title: '最高佣金比例', type: 'decimal', width: 110 },
  { field: 'minEvenCommissionPercentage', title: '最低均分佣金比例', type: 'decimal', width: 130 },
  { field: 'maxEvenCommissionPercentage', title: '最高均分佣金比例', type: 'decimal', width: 130 },
  { field: 'inviteQuantityMin', title: '最低邀请数', type: 'int', width: 90 },
  { field: 'signInBonus', title: '签到奖励', type: 'decimal', width: 90 },
  { field: 'taskGroupsBonus', title: '任务组奖励', type: 'decimal', width: 100 },
  { field: 'productMatchEnabled', title: '产品匹配', type: 'byte', width: 80, bind: { key: 'enable', data: [] } },
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
  if (searchFormFields.name) wheres.push({ name: 'name', value: searchFormFields.name, displayType: 'like' })
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
</script>
<style lang="less" scoped>
.dc-mkt-levels { padding: 10px; }
.btn-group { padding: 6px 0; display: flex; gap: 6px; }
</style>
