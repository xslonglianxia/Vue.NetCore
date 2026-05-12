export default {
  table: {
    key: 'Id',
    footer: 'Foots',
    cnName: '提现记录',
    name: 'Mkt_WithdrawalRecord',
    url: '/Mkt_WithdrawalRecord/',
    sortName: 'CreateDate',
    searchFormFields: { OrderNo: '', Username: '', Status: '', AuditStatus: '' },
    columns: [
      { field: 'Id', title: 'Id', type: 'int', width: 90, hidden: true, readonly: true, require: true, align: 'left' },
      { field: 'OrderNo', title: '订单号', type: 'string', link: true, width: 180, align: 'left', sortable: true },
      { field: 'Username', title: '用户名', type: 'string', width: 120, align: 'left' },
      { field: 'Amount', title: '金额', type: 'decimal', width: 110, align: 'left' },
      { field: 'Fee', title: '手续费', type: 'decimal', width: 90, align: 'left' },
      { field: 'RealAmount', title: '实际金额', type: 'decimal', width: 110, align: 'left' },
      { field: 'BankName', title: '银行名称', type: 'string', width: 130, align: 'left' },
      { field: 'RealName', title: '真实姓名', type: 'string', width: 120, align: 'left' },
      { field: 'Status', title: '状态', type: 'int', bind: { key: 'withdrawal_status', data: [] }, width: 90, align: 'left' },
      { field: 'AuditStatus', title: '审核状态', type: 'int', bind: { key: 'audit_status', data: [] }, width: 90, align: 'left' },
      { field: 'Visible', title: '是否可见', type: 'byte', bind: { key: 'enable', data: [] }, width: 90, align: 'left' },
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
