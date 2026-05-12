export default {
  table: {
    key: 'Id',
    footer: 'Foots',
    cnName: '会员',
    name: 'Mkt_Member',
    url: '/Mkt_Member/',
    sortName: 'CreateDate',
    searchFormFields: { Username: '', Nickname: '', Phone: '', LevelId: '', Status: '' },
    columns: [
      { field: 'Id', title: 'Id', type: 'int', width: 90, hidden: true, readonly: true, require: true, align: 'left' },
      { field: 'Username', title: '用户名', type: 'string', link: true, width: 120, require: true, align: 'left', sortable: true },
      { field: 'Nickname', title: '昵称', type: 'string', width: 120, align: 'left' },
      { field: 'Phone', title: '手机号', type: 'string', width: 130, align: 'left' },
      { field: 'LevelId', title: '等级', type: 'int', bind: { key: 'mkt_level', data: [] }, width: 100, align: 'left' },
      { field: 'Balance', title: '余额', type: 'decimal', width: 110, align: 'left' },
      { field: 'FrozenBalance', title: '冻结余额', type: 'decimal', width: 110, align: 'left' },
      { field: 'CommissionBalance', title: '佣金余额', type: 'decimal', width: 110, align: 'left' },
      { field: 'TotalRecharge', title: '总充值', type: 'decimal', width: 110, align: 'left' },
      { field: 'TotalWithdrawal', title: '总提现', type: 'decimal', width: 110, align: 'left' },
      { field: 'Status', title: '状态', type: 'int', bind: { key: 'member_status', data: [] }, width: 90, require: true, align: 'left' },
      { field: 'Creator', title: '创建人', type: 'string', width: 130, readonly: true, align: 'left' },
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
