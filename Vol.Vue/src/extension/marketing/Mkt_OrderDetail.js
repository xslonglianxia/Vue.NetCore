export default {
  table: {
    key: 'Id',
    footer: 'Foots',
    cnName: '订单明细',
    name: 'Mkt_OrderDetail',
    url: '/Mkt_OrderDetail/',
    sortName: 'CreateDate',
    searchFormFields: { OrderNo: '', Username: '', Status: '', Type: '' },
    columns: [
      { field: 'Id', title: 'Id', type: 'int', width: 90, hidden: true, readonly: true, require: true, align: 'left' },
      { field: 'OrderNo', title: '订单号', type: 'string', link: true, width: 180, align: 'left', sortable: true },
      { field: 'Username', title: '用户名', type: 'string', width: 120, align: 'left' },
      { field: 'ProductName', title: '商品名称', type: 'string', width: 150, align: 'left' },
      { field: 'Amount', title: '金额', type: 'decimal', width: 110, align: 'left' },
      { field: 'CommissionRate', title: '佣金比例', type: 'decimal', width: 100, align: 'left' },
      { field: 'CommissionAmount', title: '佣金金额', type: 'decimal', width: 110, align: 'left' },
      { field: 'Status', title: '状态', type: 'int', bind: { key: 'order_status', data: [] }, width: 90, align: 'left' },
      { field: 'Type', title: '类型', type: 'int', bind: { key: 'order_type', data: [] }, width: 90, align: 'left' },
      { field: 'CreateDate', title: '创建时间', type: 'datetime', width: 150, readonly: true, align: 'left', sortable: true }
    ],
    detail: {
      cnName: '明细',
      columns: [],
      sortName: 'CreateDate',
      key: 'Id',
      delKeys: []
    }
  },
  extend: {},
  text: '',
  methods: {}
}
