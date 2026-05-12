<template>
  <div class="dc-pts-accounts">
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
    <vol-box v-model="editBoxVisible" title="积分账户编辑" :width="600" :height="350">
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
const url = '/api/DC/DC_PtsAccount/'
const searchFields = reactive({
  memberUsername: '',
  memberPhone: '',
  availablePointsRange: [null, null]
})
const searchRules = [
  [
    { title: '用户名', field: 'memberUsername', type: 'like' },
    { title: '手机号', field: 'memberPhone' },
    { title: '可用积分范围', field: 'availablePointsRange', type: 'range' }
  ]
]
const editFields = reactive({
  points: 0,
  availablePoints: 0,
  freezePoints: 0,
  remark: ''
})
const editRules = [
  [
    { title: '积分', field: 'points', type: 'number' },
    { title: '可用积分', field: 'availablePoints', type: 'number' }
  ],
  [
    { title: '冻结积分', field: 'freezePoints', type: 'number' },
    { title: '备注', field: 'remark' }
  ]
]
const columns = reactive([
  { field: 'memberUsername', title: '用户名', type: 'string', width: 120 },
  { field: 'memberPhone', title: '手机号', type: 'string', width: 120 },
  { field: 'points', title: '积分', type: 'int', width: 100 },
  { field: 'availablePoints', title: '可用积分', type: 'int', width: 100 },
  { field: 'freezePoints', title: '冻结积分', type: 'int', width: 100 },
  { field: 'remark', title: '备注', type: 'string', width: 180 },
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
  if (searchFields.memberUsername) wheres.push({ name: 'memberUsername', value: searchFields.memberUsername, displayType: 'like' })
  if (searchFields.memberPhone) wheres.push({ name: 'memberPhone', value: searchFields.memberPhone, displayType: 'like' })
  if (searchFields.availablePointsRange[0] != null) wheres.push({ name: 'availablePoints', value: searchFields.availablePointsRange[0], displayType: 'thanorequal' })
  if (searchFields.availablePointsRange[1] != null) wheres.push({ name: 'availablePoints', value: searchFields.availablePointsRange[1], displayType: 'lessorequal' })
  table.value.load(wheres)
}
const resetSearch = () => {
  searchFields.memberUsername = ''
  searchFields.memberPhone = ''
  searchFields.availablePointsRange = [null, null]
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
.dc-pts-accounts {
  padding: 10px;
}
.btn-group {
  padding: 6px 0;
  display: flex;
  gap: 6px;
}
</style>
