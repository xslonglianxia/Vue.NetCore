export default {
  table: {
    key: 'Id',
    footer: 'Foots',
    cnName: '积分流水',
    name: 'Pts_Flow',
    url: '/Pts_Flow/',
    sortName: 'CreateDate',
    searchFormFields: { Username: '', Type: '' },
    columns: [
      { field: 'Id', title: 'Id', type: 'int', width: 90, hidden: true, readonly: true, require: true, align: 'left' },
      { field: 'Username', title: '用户名', type: 'string', width: 120, align: 'left', sortable: true },
      { field: 'Type', title: '类型', type: 'int', bind: { key: 'points_type', data: [] }, width: 100, align: 'left' },
      { field: 'Points', title: '积分', type: 'int', width: 90, align: 'left' },
      { field: 'BeforeBalance', title: '变动前余额', type: 'int', width: 120, align: 'left' },
      { field: 'AfterBalance', title: '变动后余额', type: 'int', width: 120, align: 'left' },
      { field: 'OrderNo', title: '订单号', type: 'string', width: 180, align: 'left' },
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
