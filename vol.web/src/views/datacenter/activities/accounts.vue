<template>
  <div class="dc-act-accounts">
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
    <vol-box v-model="editBoxVisible" title="活动账户编辑" :width="500" :height="300">
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
const url = '/api/DC/DC_ActAccount/'
const searchFields = reactive({
  activityId: '',
  memberUsername: '',
  availableTimesRange: [null, null],
  usedTimesRange: [null, null],
  winning: ''
})
const searchRules = [
  [
    { title: '活动ID', field: 'activityId' },
    { title: '用户名', field: 'memberUsername', type: 'like' },
    { title: '可用次数范围', field: 'availableTimesRange', type: 'range' }
  ],
  [
    { title: '已用次数范围', field: 'usedTimesRange', type: 'range' },
    { title: '中奖', field: 'winning', type: 'select', data: [{ key: 1, value: '是' }, { key: 0, value: '否' }] }
  ]
]
const editFields = reactive({
  availableTimes: 0,
  usedTimes: 0,
  remark: ''
})
const editRules = [
  [
    { title: '可用次数', field: 'availableTimes', type: 'number' },
    { title: '已用次数', field: 'usedTimes', type: 'number' }
  ],
  [
    { title: '备注', field: 'remark', type: 'textarea', colSize: 24 }
  ]
]
const columns = reactive([
  { field: 'activityId', title: '活动ID', type: 'string', width: 100 },
  { field: 'memberUsername', title: '用户名', type: 'string', width: 120 },
  { field: 'memberPhone', title: '手机号', type: 'string', width: 120 },
  { field: 'availableTimes', title: '可用次数', type: 'int', width: 90 },
  { field: 'usedTimes', title: '已用次数', type: 'int', width: 90 },
  { field: 'winning', title: '中奖', type: 'byte', width: 70, bind: { key: 'enable', data: [] } },
  { field: 'prizeKind', title: '奖品类型', type: 'string', width: 90 },
  { field: 'prizeTitle', title: '奖品标题', type: 'string', width: 120 },
  { field: 'prizePic', title: '奖品图片', type: 'img', width: 80 },
  { field: 'prizePrice', title: '奖品价格', type: 'decimal', width: 90 },
  { field: 'seq', title: '排序', type: 'int', width: 70 },
  { field: 'verified', title: '已核销', type: 'byte', width: 70, bind: { key: 'enable', data: [] } },
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
  if (searchFields.activityId) wheres.push({ name: 'activityId', value: searchFields.activityId })
  if (searchFields.memberUsername) wheres.push({ name: 'memberUsername', value: searchFields.memberUsername, displayType: 'like' })
  if (searchFields.availableTimesRange[0] != null) wheres.push({ name: 'availableTimes', value: searchFields.availableTimesRange[0], displayType: 'thanorequal' })
  if (searchFields.availableTimesRange[1] != null) wheres.push({ name: 'availableTimes', value: searchFields.availableTimesRange[1], displayType: 'lessorequal' })
  if (searchFields.usedTimesRange[0] != null) wheres.push({ name: 'usedTimes', value: searchFields.usedTimesRange[0], displayType: 'thanorequal' })
  if (searchFields.usedTimesRange[1] != null) wheres.push({ name: 'usedTimes', value: searchFields.usedTimesRange[1], displayType: 'lessorequal' })
  if (searchFields.winning !== '') wheres.push({ name: 'winning', value: searchFields.winning })
  table.value.load(wheres)
}
const resetSearch = () => {
  searchFields.activityId = ''
  searchFields.memberUsername = ''
  searchFields.availableTimesRange = [null, null]
  searchFields.usedTimesRange = [null, null]
  searchFields.winning = ''
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
.dc-act-accounts {
  padding: 10px;
}
.btn-group {
  padding: 6px 0;
  display: flex;
  gap: 6px;
}
</style>
