<template>
  <div class="container">
    <view-grid ref="grid" :columns="columns" :detail="detail" :editFormFields="editFormFields" :editFormOptions="editFormOptions" :searchFormFields="searchFormFields" :searchFormOptions="searchFormOptions" :table="table" :extend="extend">
    </view-grid>
  </div>
</template>

<script>
import extend from '@/extension/marketing/Mkt_YuebaoTradingFlow.js'
import ViewGrid from '@/components/basic/ViewGrid.vue'
export default {
  components: { ViewGrid },
  data() {
    return {
      table: extend.table,
      extend: extend.extend,
      editFormFields: extend.editFormFields || {},
      editFormOptions: extend.editFormOptions || [],
      searchFormFields: extend.searchFormFields || {},
      searchFormOptions: extend.searchFormOptions || [],
      columns: extend.columns || [],
      detail: extend.detail || {}
    }
  }
}
</script>
