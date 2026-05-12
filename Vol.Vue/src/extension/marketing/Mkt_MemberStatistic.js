export default {
  table: {
    key: 'Id',
    footer: 'Foots',
    cnName: '会员统计',
    name: 'Mkt_MemberStatistic',
    url: '/Mkt_MemberStatistic/',
    sortName: 'CreateDate',
    searchFormFields: { Username: '', Date: '' },
    columns: [
      { field: 'Id', title: 'Id', type: 'int', width: 90, hidden: true, readonly: true, require: true, align: 'left' },
      { field: 'Username', title: '用户名', type: 'string', width: 120, align: 'left', sortable: true },
      { field: 'RechargeAmount', title: '充值金额', type: 'decimal', width: 110, align: 'left' },
      { field: 'WithdrawalAmount', title: '提现金额', type: 'decimal', width: 110, align: 'left' },
      { field: 'CommissionAmount', title: '佣金金额', type: 'decimal', width: 110, align: 'left' },
      { field: 'GiveAmount', title: '赠送金额', type: 'decimal', width: 110, align: 'left' },
      { field: 'OrderNumber', title: '订单数', type: 'int', width: 90, align: 'left' },
      { field: 'Date', title: '日期', type: 'datetime', width: 120, align: 'left', sortable: true },
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
