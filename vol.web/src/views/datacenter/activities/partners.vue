<template>
  <div class="dc-act-partners">
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
      :ck="true"
      :index="true"
    >
      <template #hidden="scope">
        <el-switch
          v-model="scope.row.hidden"
          :active-value="1"
          :inactive-value="0"
          @change="toggleHidden(scope.row)"
        ></el-switch>
      </template>
    </vol-table>
  </div>
</template>
<script setup>
import VolTable from '@/components/basic/VolTable.vue'
import VolForm from '@/components/basic/VolForm.vue'
import { ref, reactive, getCurrentInstance } from 'vue'
const { proxy } = getCurrentInstance()
const url = '/api/DC/DC_ActPartner/'
const searchFields = reactive({
  activityId: '',
  memberUsername: '',
  createDateRange: ''
})
const searchRules = [
  [
    { title: '活动ID', field: 'activityId' },
    { title: '用户名', field: 'memberUsername', type: 'like' },
    { title: '创建时间', field: 'createDateRange', type: 'datetime', range: true }
  ]
]
const columns = reactive([
  { field: 'activityId', title: '活动ID', type: 'string', width: 100 },
  { field: 'memberUsername', title: '用户名', type: 'string', width: 120 },
  { field: 'memberPhone', title: '手机号', type: 'string', width: 120 },
  { field: 'winning', title: '中奖', type: 'byte', width: 70, bind: { key: 'enable', data: [] } },
  { field: 'prizeKind', title: '奖品类型', type: 'string', width: 90 },
  { field: 'prizeTitle', title: '奖品标题', type: 'string', width: 120 },
  { field: 'prizePic', title: '奖品图片', type: 'img', width: 80 },
  { field: 'prizePrice', title: '奖品价格', type: 'decimal', width: 90 },
  { field: 'verified', title: '已核销', type: 'byte', width: 70, bind: { key: 'enable', data: [] } },
  { field: 'hidden', title: '隐藏', type: 'byte', width: 70, render: true },
  { field: 'remark', title: '备注', type: 'string', width: 150 },
  { field: 'createDate', title: '创建时间', type: 'datetime', width: 140, sort: true }
])
const pagination = reactive({ total: 0, size: 30, sortName: 'CreateDate' })
const table = ref(null)
const searchForm = ref(null)
const search = () => {
  let wheres = []
  if (searchFields.activityId) wheres.push({ name: 'activityId', value: searchFields.activityId })
  if (searchFields.memberUsername) wheres.push({ name: 'memberUsername', value: searchFields.memberUsername, displayType: 'like' })
  if (searchFields.createDateRange) wheres.push({ name: 'createDate', value: searchFields.createDateRange, displayType: 'range' })
  table.value.load(wheres)
}
const resetSearch = () => {
  searchFields.activityId = ''
  searchFields.memberUsername = ''
  searchFields.createDateRange = ''
  table.value.load([])
}
const toggleHidden = (row) => {
  proxy.http.post(url + 'update', {
    id: row.id || row.Id,
    hidden: row.hidden
  }, true).then(result => {
    if (result.status) {
      proxy.$message.success('操作成功')
    } else {
      proxy.$message.error(result.message)
    }
  })
}
</script>
<style lang="less" scoped>
.dc-act-partners {
  padding: 10px;
}
</style>
