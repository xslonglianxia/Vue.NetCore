<template>
  <div class="vol-container">
    <div class="search-form">
      <el-form :inline="true" :model="searchFields">
        <el-form-item label="用户名">
          <el-input v-model="searchFields.username" clearable placeholder="用户名"></el-input>
        </el-form-item>
        <el-form-item label="请求方法">
          <el-input v-model="searchFields.method" clearable placeholder="请求方法"></el-input>
        </el-form-item>
        <el-form-item label="请求地址">
          <el-input v-model="searchFields.url" clearable placeholder="请求地址"></el-input>
        </el-form-item>
        <el-form-item label="状态">
          <el-select v-model="searchFields.status" clearable placeholder="请选择">
            <el-option :value="1" label="成功"></el-option>
            <el-option :value="0" label="失败"></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="操作时间">
          <el-date-picker v-model="searchFields.createDateRange" type="daterange" range-separator="-" start-placeholder="开始时间" end-placeholder="结束时间" value-format="YYYY-MM-DD"></el-date-picker>
        </el-form-item>
        <el-form-item>
          <el-button type="primary" @click="search">查询</el-button>
          <el-button @click="resetSearch">重置</el-button>
        </el-form-item>
      </el-form>
    </div>
    <vol-table ref="table" :url="url" :columns="columns" :pagination="pagination" @loadBefore="loadBefore" @loadAfter="loadAfter"></vol-table>
  </div>
</template>

<script setup>
import { ref, reactive } from 'vue'
import VolTable from '@/components/basic/VolTable.vue'

const url = '/api/DC/DC_SysOperationLog/'
const table = ref(null)

const searchFields = reactive({
  username: '',
  method: '',
  url: '',
  status: null,
  createDateRange: null
})

const columns = reactive([
  { field: 'username', title: '用户名', type: 'string', width: 100 },
  { field: 'resourceCode', title: '资源编码', type: 'string', width: 130 },
  { field: 'method', title: '请求方法', type: 'string', width: 90 },
  { field: 'url', title: '请求地址', type: 'string', width: 220 },
  { field: 'parameter', title: '请求参数', type: 'string', width: 200 },
  { field: 'ip', title: 'IP', type: 'string', width: 120 },
  { field: 'address', title: '地址', type: 'string', width: 130 },
  { field: 'status', title: '状态', type: 'string', width: 80, bind: { key: 'status', data: [{ key: 1, value: '成功' }, { key: 0, value: '失败' }] } },
  { field: 'message', title: '消息', type: 'string', width: 200 },
  { field: 'duration', title: '耗时(ms)', type: 'int', width: 90 },
  { field: 'createDate', title: '操作时间', type: 'datetime', width: 150 }
])

const pagination = reactive({ total: 0, size: 30, sortName: '' })

const loadBefore = (param) => {
  if (searchFields.username) param.wheres.push({ name: 'username', value: searchFields.username })
  if (searchFields.method) param.wheres.push({ name: 'method', value: searchFields.method })
  if (searchFields.url) param.wheres.push({ name: 'url', value: searchFields.url })
  if (searchFields.status !== null && searchFields.status !== '') param.wheres.push({ name: 'status', value: searchFields.status })
  if (searchFields.createDateRange && searchFields.createDateRange.length === 2) {
    param.wheres.push({ name: 'createDate', value: searchFields.createDateRange[0], displayType: 'thanorequal' })
    param.wheres.push({ name: 'createDate', value: searchFields.createDateRange[1], displayType: 'lessorequal' })
  }
  return true
}

const loadAfter = (data) => {}

const search = () => {
  table.value.load(null, true)
}

const resetSearch = () => {
  Object.assign(searchFields, { username: '', method: '', url: '', status: null, createDateRange: null })
  table.value.load(null, true)
}
</script>

<style scoped>
.vol-container {
  padding: 10px;
}
.search-form {
  padding: 10px 0 0 0;
}
</style>
