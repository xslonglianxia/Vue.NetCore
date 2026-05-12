export default {
  table: {
    key: 'Id',
    footer: 'Foots',
    cnName: '积分账户',
    name: 'Pts_Account',
    url: '/Pts_Account/',
    sortName: 'CreateDate',
    searchFormFields: { Username: '' },
    columns: [
      { field: 'Id', title: 'Id', type: 'int', width: 90, hidden: true, readonly: true, require: true, align: 'left' },
      { field: 'Username', title: '用户名', type: 'string', width: 120, align: 'left', sortable: true },
      { field: 'Balance', title: '余额', type: 'int', width: 100, align: 'left' },
      { field: 'TotalEarned', title: '总获得', type: 'int', width: 100, align: 'left' },
      { field: 'TotalSpent', title: '总消费', type: 'int', width: 100, align: 'left' },
      { field: 'CreateDate', title: '创建时间', type: 'datetime', width: 150, readonly: true, align: 'left', sortable: true },
      { field: 'ModifyDate', title: '修改时间', type: 'datetime', width: 150, readonly: true, align: 'left', sortable: true }
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
