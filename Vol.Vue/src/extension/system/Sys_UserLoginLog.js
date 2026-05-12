export default {
  table: {
    key: 'Id',
    footer: 'Foots',
    cnName: '登录日志',
    name: 'Sys_UserLoginLog',
    url: '/Sys_UserLoginLog/',
    sortName: 'CreateDate',
    searchFormFields: { UserName: '', Ip: '', Status: '' },
    columns: [
      { field: 'Id', title: 'Id', type: 'int', width: 90, hidden: true, readonly: true, require: true, align: 'left' },
      { field: 'UserName', title: '用户名', type: 'string', width: 120, align: 'left', sortable: true },
      { field: 'LoginType', title: '登录类型', type: 'int', bind: { key: 'login_type', data: [] }, width: 100, align: 'left' },
      { field: 'Ip', title: 'IP地址', type: 'string', width: 130, align: 'left' },
      { field: 'Location', title: '登录地点', type: 'string', width: 150, align: 'left' },
      { field: 'Browser', title: '浏览器', type: 'string', width: 120, align: 'left' },
      { field: 'Os', title: '操作系统', type: 'string', width: 120, align: 'left' },
      { field: 'Status', title: '状态', type: 'int', bind: { key: 'login_status', data: [] }, width: 90, align: 'left' },
      { field: 'Message', title: '消息', type: 'string', width: 200, align: 'left' },
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
