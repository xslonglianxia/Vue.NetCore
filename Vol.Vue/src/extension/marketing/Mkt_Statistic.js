export default {
  table: {
    key: 'Id',
    footer: 'Foots',
    cnName: '统计',
    name: 'Mkt_Statistic',
    url: '/Mkt_Statistic/',
    sortName: 'CreateDate',
    searchFormFields: { Date: '' },
    columns: [
      { field: 'Id', title: 'Id', type: 'int', width: 90, hidden: true, readonly: true, require: true, align: 'left' },
      { field: 'Date', title: '日期', type: 'datetime', width: 120, align: 'left', sortable: true },
      { field: 'RechargeAmount', title: '充值金额', type: 'decimal', width: 110, align: 'left' },
      { field: 'WithdrawalAmount', title: '提现金额', type: 'decimal', width: 110, align: 'left' },
      { field: 'CommissionAmount', title: '佣金金额', type: 'decimal', width: 110, align: 'left' },
      { field: 'MemberNumber', title: '会员数', type: 'int', width: 90, align: 'left' },
      { field: 'OrderNumber', title: '订单数', type: 'int', width: 90, align: 'left' },
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
