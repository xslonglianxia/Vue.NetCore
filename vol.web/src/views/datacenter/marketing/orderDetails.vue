<template>
  <div class="dc-mkt-order-details">
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
      <el-button type="warning" @click="cancelOrder">取 消</el-button>
      <el-button type="info" @click="commentRow">评 论</el-button>
    </div>
    <vol-table
      ref="table"
      :columns="columns"
      :url="url"
      :pagination="pagination"
      :ck="true"
      :index="true"
    />
    <vol-box v-model="editBoxVisible" title="订单详情编辑" :width="600" :height="300">
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
    <vol-box v-model="commentBoxVisible" title="评论" :width="500" :height="280">
      <vol-form
        ref="commentForm"
        :formFields="commentFormFields"
        :formRules="commentFormRules"
        :labelWidth="70"
      />
      <template #footer>
        <el-button type="primary" @click="saveComment">提 交</el-button>
        <el-button @click="commentBoxVisible = false">关 闭</el-button>
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
const url = '/api/DC/DC_MktOrderDetail/'
const searchFormFields = reactive({ detailNo: '', memberUsername: '', kind: '', status: '', amountRange: '', createDateRange: '' })
const searchFormRules = [
  [
    { title: '订单号', field: 'detailNo' },
    { title: '会员账号', field: 'memberUsername', type: 'like' },
    { title: '类型', field: 'kind', type: 'select', data: [] }
  ],
  [
    { title: '状态', field: 'status', type: 'select', data: [] },
    { title: '金额范围', field: 'amountRange' },
    { title: '创建日期', field: 'createDateRange', type: 'datetime', range: true }
  ]
]
const editFormFields = reactive({ expiredDate: '', remark: '' })
const editFormRules = [
  [{ title: '过期时间', field: 'expiredDate', type: 'datetime' }],
  [{ title: '备注', field: 'remark', type: 'textarea', colSize: 24 }]
]
const commentFormFields = reactive({ content: '' })
const commentFormRules = [
  [{ title: '内容', field: 'content', type: 'textarea', colSize: 24 }]
]
const columns = reactive([
  { field: 'detailNo', title: '订单号', type: 'string', width: 140, sort: true },
  { field: 'memberUsername', title: '会员账号', type: 'string', width: 110 },
  { field: 'kind', title: '类型', type: 'int', width: 80, bind: { key: 'dc_mkt_order_kind', data: [] } },
  { field: 'spuTitle', title: '商品标题', type: 'string', width: 150 },
  { field: 'spuPic', title: '商品图片', type: 'img', width: 80 },
  { field: 'seq', title: '序号', type: 'int', width: 70 },
  { field: 'amount', title: '金额', type: 'decimal', width: 90 },
  { field: 'commissionPercentage', title: '佣金比例', type: 'decimal', width: 90 },
  { field: 'commission', title: '佣金', type: 'decimal', width: 90 },
  { field: 'parentCommissionPercentage', title: '上级佣金比例', type: 'decimal', width: 110 },
  { field: 'parentCommission', title: '上级佣金', type: 'decimal', width: 90 },
  { field: 'additionalCommission', title: '额外佣金', type: 'decimal', width: 90 },
  { field: 'status', title: '状态', type: 'int', width: 80, bind: { key: 'dc_mkt_order_status', data: [] } },
  { field: 'expiredDate', title: '过期时间', type: 'datetime', width: 140 },
  { field: 'remark', title: '备注', type: 'string', width: 120 },
  { field: 'createDate', title: '创建时间', type: 'datetime', width: 140, sort: true }
])
const pagination = reactive({ total: 0, size: 30, sortName: 'CreateDate' })
const editBoxVisible = ref(false)
const commentBoxVisible = ref(false)
const currentRow = ref(null)
const table = ref(null)
const searchForm = ref(null)
const editForm = ref(null)
const commentForm = ref(null)
const search = () => {
  let wheres = []
  if (searchFormFields.detailNo) wheres.push({ name: 'detailNo', value: searchFormFields.detailNo })
  if (searchFormFields.memberUsername) wheres.push({ name: 'memberUsername', value: searchFormFields.memberUsername, displayType: 'like' })
  if (searchFormFields.kind !== '') wheres.push({ name: 'kind', value: searchFormFields.kind })
  if (searchFormFields.status !== '') wheres.push({ name: 'status', value: searchFormFields.status })
  if (searchFormFields.amountRange) wheres.push({ name: 'amount', value: searchFormFields.amountRange, displayType: 'range' })
  if (searchFormFields.createDateRange) wheres.push({ name: 'createDate', value: searchFormFields.createDateRange, displayType: 'range' })
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
  editFormFields.expiredDate = rows[0].expiredDate || ''
  editFormFields.remark = rows[0].remark || ''
  editBoxVisible.value = true
}
const save = () => {
  let params = {
    id: currentRow.value.id || currentRow.value.Id,
    expiredDate: editFormFields.expiredDate,
    remark: editFormFields.remark
  }
  proxy.http.post(url + 'update', params, true).then(result => {
    if (result.status) { proxy.$message.success('保存成功'); editBoxVisible.value = false; table.value.load() }
    else proxy.$message.error(result.message)
  })
}
const cancelOrder = () => {
  let rows = table.value.getSelected()
  if (!rows || rows.length === 0) return proxy.$message.warning('请选择要取消的订单')
  let invalidRows = rows.filter(r => r.status !== 1)
  if (invalidRows.length > 0) return proxy.$message.warning('只能取消状态为1的订单')
  proxy.$confirm('确认要取消选中的订单吗?', '提示', { type: 'warning' }).then(() => {
    let ids = rows.map(r => r.id || r.Id)
    proxy.http.post(url + 'cancel', ids, true).then(result => {
      if (result.status) { proxy.$message.success('取消成功'); table.value.load() }
      else proxy.$message.error(result.message)
    })
  })
}
const commentRow = () => {
  let rows = table.value.getSelected()
  if (!rows || rows.length === 0) return proxy.$message.warning('请选择要评论的订单')
  if (rows.length > 1) return proxy.$message.warning('只能选择一行进行评论')
  currentRow.value = rows[0]
  commentFormFields.content = ''
  commentBoxVisible.value = true
}
const saveComment = () => {
  if (!commentFormFields.content) return proxy.$message.warning('请输入评论内容')
  let params = {
    id: currentRow.value.id || currentRow.value.Id,
    content: commentFormFields.content
  }
  proxy.http.post(url + 'comment', params, true).then(result => {
    if (result.status) { proxy.$message.success('评论成功'); commentBoxVisible.value = false; table.value.load() }
    else proxy.$message.error(result.message)
  })
}
</script>
<style lang="less" scoped>
.dc-mkt-order-details { padding: 10px; }
.btn-group { padding: 6px 0; display: flex; gap: 6px; }
</style>
