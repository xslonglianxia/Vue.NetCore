<template>
  <div class="vol-container">
    <div class="search-form">
      <el-form :inline="true" :model="searchFields">
        <el-form-item label="用户名">
          <el-input v-model="searchFields.username" clearable placeholder="用户名"></el-input>
        </el-form-item>
        <el-form-item label="IP">
          <el-input v-model="searchFields.ip" clearable placeholder="IP地址"></el-input>
        </el-form-item>
        <el-form-item label="是否成功">
          <el-select v-model="searchFields.success" clearable placeholder="请选择">
            <el-option :value="1" label="成功"></el-option>
            <el-option :value="0" label="失败"></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="登录时间">
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

const url = '/api/DC/DC_SysUserLoginLog/'
const table = ref(null)

const searchFields = reactive({
  username: '',
  ip: '',
  success: null,
  createDateRange: null
})

const columns = reactive([
  { field: 'username', title: '用户名', type: 'string', width: 120 },
  { field: 'param', title: '登录参数', type: 'string', width: 200 },
  { field: 'ip', title: 'IP', type: 'string', width: 130 },
  { field: 'address', title: '地址', type: 'string', width: 150 },
  { field: 'success', title: '是否成功', type: 'string', width: 90, bind: { key: 'success', data: [{ key: 1, value: '成功' }, { key: 0, value: '失败' }] } },
  { field: 'createDate', title: '登录时间', type: 'datetime', width: 150 }
])

const pagination = reactive({ total: 0, size: 30, sortName: '' })

const loadBefore = (param) => {
  if (searchFields.username) param.wheres.push({ name: 'username', value: searchFields.username })
  if (searchFields.ip) param.wheres.push({ name: 'ip', value: searchFields.ip })
  if (searchFields.success !== null && searchFields.success !== '') param.wheres.push({ name: 'success', value: searchFields.success })
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
  Object.assign(searchFields, { username: '', ip: '', success: null, createDateRange: null })
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
