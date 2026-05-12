export default {
  table: {
    key: 'Id',
    footer: 'Foots',
    cnName: '会员登录日志',
    name: 'Mkt_MemberLoginLog',
    url: '/Mkt_MemberLoginLog/',
    sortName: 'CreateDate',
    searchFormFields: { Username: '', Ip: '' },
    columns: [
      { field: 'Id', title: 'Id', type: 'int', width: 90, hidden: true, readonly: true, require: true, align: 'left' },
      { field: 'Username', title: '用户名', type: 'string', width: 120, align: 'left', sortable: true },
      { field: 'Ip', title: 'IP地址', type: 'string', width: 130, align: 'left' },
      { field: 'Location', title: '登录地点', type: 'string', width: 150, align: 'left' },
      { field: 'Browser', title: '浏览器', type: 'string', width: 120, align: 'left' },
      { field: 'Os', title: '操作系统', type: 'string', width: 120, align: 'left' },
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
