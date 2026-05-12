export default {
  table: {
    key: 'Id',
    footer: 'Foots',
    cnName: '操作日志',
    name: 'Sys_OperationLog',
    url: '/Sys_OperationLog/',
    sortName: 'CreateDate',
    searchFormFields: { UserName: '', Module: '', Action: '', Url: '', Ip: '' },
    columns: [
      { field: 'Id', title: 'Id', type: 'int', width: 90, hidden: true, readonly: true, require: true, align: 'left' },
      { field: 'UserName', title: '用户名', type: 'string', width: 120, align: 'left', sortable: true },
      { field: 'Module', title: '模块', type: 'string', width: 150, align: 'left' },
      { field: 'Action', title: '操作', type: 'string', width: 120, align: 'left' },
      { field: 'Method', title: '请求方法', type: 'string', width: 100, align: 'left' },
      { field: 'Url', title: '请求地址', type: 'string', width: 200, align: 'left' },
      { field: 'Ip', title: 'IP地址', type: 'string', width: 130, align: 'left' },
      { field: 'Duration', title: '耗时(ms)', type: 'int', width: 90, align: 'left' },
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
