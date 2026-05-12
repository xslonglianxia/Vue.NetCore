<template>
  <div class="dc-pts-gift-orders">
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
    <div class="btn-group">
      <el-button type="primary" @click="edit">编 辑</el-button>
    </div>
    <vol-table
      ref="table"
      :columns="columns"
      :url="url"
      :pagination="pagination"
      :ck="true"
      :index="true"
    />
    <vol-box v-model="editBoxVisible" title="礼品订单编辑" :width="500" :height="300">
      <vol-form
        ref="editForm"
        :formFields="editFields"
        :formRules="editRules"
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
const url = '/api/DC/DC_PtsGiftOrder/'
const searchFields = reactive({
  orderNo: '',
  memberUsername: '',
  pointsRange: [null, null],
  status: '',
  createDateRange: ''
})
const searchRules = [
  [
    { title: '订单号', field: 'orderNo' },
    { title: '用户名', field: 'memberUsername', type: 'like' },
    { title: '积分范围', field: 'pointsRange', type: 'range' }
  ],
  [
    { title: '状态', field: 'status', type: 'select', data: [{ key: 0, value: '待处理' }, { key: 1, value: '已发货' }, { key: 2, value: '已完成' }, { key: 3, value: '已取消' }] },
    { title: '创建时间', field: 'createDateRange', type: 'datetime', range: true }
  ]
]
const editFields = reactive({
  status: 0,
  remark: ''
})
const editRules = [
  [{ title: '状态', field: 'status', type: 'select', data: [{ key: 0, value: '待处理' }, { key: 1, value: '已发货' }, { key: 2, value: '已完成' }, { key: 3, value: '已取消' }] }],
  [{ title: '备注', field: 'remark', type: 'textarea', colSize: 24 }]
]
const columns = reactive([
  { field: 'orderNo', title: '订单号', type: 'string', width: 150 },
  { field: 'memberUsername', title: '用户名', type: 'string', width: 120 },
  { field: 'giftTitle', title: '礼品标题', type: 'string', width: 150 },
  { field: 'giftPic', title: '礼品图片', type: 'img', width: 80 },
  { field: 'points', title: '积分', type: 'int', width: 80 },
  { field: 'consignee', title: '收货人', type: 'string', width: 100 },
  { field: 'telephone', title: '联系电话', type: 'string', width: 120 },
  { field: 'deliveryAddress', title: '收货地址', type: 'string', width: 200 },
  { field: 'status', title: '状态', type: 'int', width: 80, bind: { key: 'dc_pts_order_status', data: [] } },
  { field: 'remark', title: '备注', type: 'string', width: 150 },
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
  if (searchFields.orderNo) wheres.push({ name: 'orderNo', value: searchFields.orderNo })
  if (searchFields.memberUsername) wheres.push({ name: 'memberUsername', value: searchFields.memberUsername, displayType: 'like' })
  if (searchFields.pointsRange[0] != null) wheres.push({ name: 'points', value: searchFields.pointsRange[0], displayType: 'thanorequal' })
  if (searchFields.pointsRange[1] != null) wheres.push({ name: 'points', value: searchFields.pointsRange[1], displayType: 'lessorequal' })
  if (searchFields.status !== '') wheres.push({ name: 'status', value: searchFields.status })
  if (searchFields.createDateRange) wheres.push({ name: 'createDate', value: searchFields.createDateRange, displayType: 'range' })
  table.value.load(wheres)
}
const resetSearch = () => {
  searchFields.orderNo = ''
  searchFields.memberUsername = ''
  searchFields.pointsRange = [null, null]
  searchFields.status = ''
  searchFields.createDateRange = ''
  table.value.load([])
}
const edit = () => {
  let rows = table.value.getSelected()
  if (!rows || rows.length === 0) return proxy.$message.warning('请选择要编辑的行')
  if (rows.length > 1) return proxy.$message.warning('只能选择一行进行编辑')
  currentRow.value = rows[0]
  Object.keys(editFields).forEach(k => { editFields[k] = rows[0][k] ?? editFields[k] })
  editBoxVisible.value = true
}
const save = () => {
  let params = { ...editFields }
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
}
</script>
<style lang="less" scoped>
.dc-pts-gift-orders {
  padding: 10px;
}
.btn-group {
  padding: 6px 0;
  display: flex;
  gap: 6px;
}
</style>
