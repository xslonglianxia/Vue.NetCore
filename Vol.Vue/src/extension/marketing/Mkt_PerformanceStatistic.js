export default {
  table: {
    key: 'Id',
    footer: 'Foots',
    cnName: '业绩统计',
    name: 'Mkt_PerformanceStatistic',
    url: '/Mkt_PerformanceStatistic/',
    sortName: 'CreateDate',
    searchFormFields: { Username: '', Nickname: '' },
    columns: [
      { field: 'Id', title: 'Id', type: 'int', width: 90, hidden: true, readonly: true, require: true, align: 'left' },
      { field: 'Username', title: '用户名', type: 'string', width: 120, align: 'left', sortable: true },
      { field: 'Nickname', title: '昵称', type: 'string', width: 120, align: 'left' },
      { field: 'LevelName', title: '等级名称', type: 'string', width: 100, align: 'left' },
      { field: 'ParentUsername', title: '上级用户名', type: 'string', width: 120, align: 'left' },
      { field: 'RechargeAmount', title: '充值金额', type: 'decimal', width: 110, align: 'left' },
      { field: 'WithdrawalAmount', title: '提现金额', type: 'decimal', width: 110, align: 'left' },
      { field: 'CommissionAmount', title: '佣金金额', type: 'decimal', width: 110, align: 'left' },
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
  formFields: {},
  methods: {
    onInit() {
      this.editFormFields = {};
      this.editFormOptions = [];
    }
  }
}
