<template>
  <div class="dc-pts-gifts">
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
    <vol-box v-model="editBoxVisible" title="积分礼品编辑" :width="700" :height="500">
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
const url = '/api/DC/DC_PtsGift/'
const searchFields = reactive({
  title: '',
  kind: '',
  pointsRange: [null, null],
  enabled: ''
})
const searchRules = [
  [
    { title: '标题', field: 'title', type: 'like' },
    { title: '类型', field: 'kind' },
    { title: '积分范围', field: 'pointsRange', type: 'range' },
    { title: '启用', field: 'enabled', type: 'select', data: [{ key: 1, value: '是' }, { key: 0, value: '否' }] }
  ]
]
const editFields = reactive({
  title: '',
  pic: '',
  kind: '',
  points: 0,
  price: 0,
  giftStock: 0,
  giftAvailableStock: 0,
  giftFreezeStock: 0,
  giftSaleVolume: 0,
  enabled: 1,
  remark: ''
})
const editRules = [
  [
    { title: '标题', field: 'title', required: true },
    { title: '图片', field: 'pic' }
  ],
  [
    { title: '类型', field: 'kind' },
    { title: '积分', field: 'points', type: 'number' }
  ],
  [
    { title: '价格', field: 'price', type: 'number' },
    { title: '库存', field: 'giftStock', type: 'number' }
  ],
  [
    { title: '可用库存', field: 'giftAvailableStock', type: 'number' },
    { title: '冻结库存', field: 'giftFreezeStock', type: 'number' }
  ],
  [
    { title: '销量', field: 'giftSaleVolume', type: 'number' },
    { title: '启用', field: 'enabled', type: 'select', data: [{ key: 1, value: '是' }, { key: 0, value: '否' }] }
  ],
  [
    { title: '备注', field: 'remark', type: 'textarea', colSize: 24 }
  ]
]
const columns = reactive([
  { field: 'title', title: '标题', type: 'string', width: 150 },
  { field: 'pic', title: '图片', type: 'img', width: 80 },
  { field: 'kind', title: '类型', type: 'string', width: 80 },
  { field: 'points', title: '积分', type: 'int', width: 80 },
  { field: 'price', title: '价格', type: 'decimal', width: 80 },
  { field: 'giftStock', title: '库存', type: 'int', width: 80 },
  { field: 'giftAvailableStock', title: '可用库存', type: 'int', width: 90 },
  { field: 'giftFreezeStock', title: '冻结库存', type: 'int', width: 90 },
  { field: 'giftSaleVolume', title: '销量', type: 'int', width: 80 },
  { field: 'enabled', title: '启用', type: 'byte', width: 70, bind: { key: 'enable', data: [] } },
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
  if (searchFields.title) wheres.push({ name: 'title', value: searchFields.title, displayType: 'like' })
  if (searchFields.kind) wheres.push({ name: 'kind', value: searchFields.kind, displayType: 'like' })
  if (searchFields.pointsRange[0] != null) wheres.push({ name: 'points', value: searchFields.pointsRange[0], displayType: 'thanorequal' })
  if (searchFields.pointsRange[1] != null) wheres.push({ name: 'points', value: searchFields.pointsRange[1], displayType: 'lessorequal' })
  if (searchFields.enabled !== '') wheres.push({ name: 'enabled', value: searchFields.enabled })
  table.value.load(wheres)
}
const resetSearch = () => {
  searchFields.title = ''
  searchFields.kind = ''
  searchFields.pointsRange = [null, null]
  searchFields.enabled = ''
  table.value.load([])
}
const add = () => {
  Object.keys(editFields).forEach(k => {
    if (typeof editFields[k] === 'number') editFields[k] = 0
    else editFields[k] = ''
  })
  editFields.enabled = 1
  currentRow.value = null
  editBoxVisible.value = true
}
const edit = () => {
  let rows = table.value.getSelected()
  if (!rows || rows.length === 0) return proxy.$message.warning('请选择要编辑的行')
  if (rows.length > 1) return proxy.$message.warning('只能选择一行进行编辑')
  currentRow.value = rows[0]
  Object.keys(editFields).forEach(k => { editFields[k] = rows[0][k] ?? editFields[k] })
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
  let params = { ...editFields }
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
.dc-pts-gifts {
  padding: 10px;
}
.btn-group {
  padding: 6px 0;
  display: flex;
  gap: 6px;
}
</style>
