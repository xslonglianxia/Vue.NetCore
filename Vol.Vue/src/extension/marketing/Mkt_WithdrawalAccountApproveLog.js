export default {
  table: {
    key: 'Id',
    footer: 'Foots',
    cnName: '提现账户审核',
    name: 'Mkt_WithdrawalAccountApproveLog',
    url: '/Mkt_WithdrawalAccountApproveLog/',
    sortName: 'CreateDate',
    searchFormFields: { Username: '', RealName: '', Status: '' },
    columns: [
      { field: 'Id', title: 'Id', type: 'int', width: 90, hidden: true, readonly: true, require: true, align: 'left' },
      { field: 'Username', title: '用户名', type: 'string', width: 120, align: 'left', sortable: true },
      { field: 'RealName', title: '真实姓名', type: 'string', width: 120, align: 'left' },
      { field: 'BankName', title: '银行名称', type: 'string', width: 130, align: 'left' },
      { field: 'BankAccount', title: '银行账号', type: 'string', width: 180, align: 'left' },
      { field: 'Status', title: '状态', type: 'int', bind: { key: 'audit_status', data: [] }, width: 90, align: 'left' },
      { field: 'ApproveUserName', title: '审核人', type: 'string', width: 120, align: 'left' },
      { field: 'ApproveTime', title: '审核时间', type: 'datetime', width: 150, align: 'left' },
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
