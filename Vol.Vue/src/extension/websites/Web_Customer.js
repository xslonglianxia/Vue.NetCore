export default {
  table: {
    key: 'Id',
    footer: 'Foots',
    cnName: '站点客户',
    name: 'Web_Customer',
    url: '/Web_Customer/',
    sortName: 'CreateDate',
    searchFormFields: { Name: '', Domain: '', Status: '' },
    columns: [
      { field: 'Id', title: 'Id', type: 'int', width: 90, hidden: true, readonly: true, require: true, align: 'left' },
      { field: 'Name', title: '名称', type: 'string', width: 150, require: true, align: 'left', sortable: true },
      { field: 'Domain', title: '域名', type: 'string', width: 200, align: 'left' },
      { field: 'ContactName', title: '联系人', type: 'string', width: 120, align: 'left' },
      { field: 'ContactPhone', title: '联系电话', type: 'string', width: 130, align: 'left' },
      { field: 'Status', title: '状态', type: 'int', bind: { key: 'customer_status', data: [] }, width: 90, align: 'left' },
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
