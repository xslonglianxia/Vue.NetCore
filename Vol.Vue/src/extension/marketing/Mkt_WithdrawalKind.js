export default {
  table: {
    key: 'Id',
    footer: 'Foots',
    cnName: '提现方式',
    name: 'Mkt_WithdrawalKind',
    url: '/Mkt_WithdrawalKind/',
    sortName: 'CreateDate',
    searchFormFields: { Name: '', Code: '', Enable: '' },
    columns: [
      { field: 'Id', title: 'Id', type: 'int', width: 90, hidden: true, readonly: true, require: true, align: 'left' },
      { field: 'Name', title: '名称', type: 'string', width: 150, require: true, align: 'left', sortable: true },
      { field: 'Code', title: '编码', type: 'string', width: 120, align: 'left' },
      { field: 'MinAmount', title: '最小金额', type: 'decimal', width: 110, align: 'left' },
      { field: 'MaxAmount', title: '最大金额', type: 'decimal', width: 110, align: 'left' },
      { field: 'FeeRate', title: '费率', type: 'decimal', width: 90, align: 'left' },
      { field: 'FeeFixed', title: '固定手续费', type: 'decimal', width: 110, align: 'left' },
      { field: 'Sort', title: '排序', type: 'int', width: 80, align: 'left' },
      { field: 'Enable', title: '启用', type: 'byte', bind: { key: 'enable', data: [] }, width: 90, require: true, align: 'left' },
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
