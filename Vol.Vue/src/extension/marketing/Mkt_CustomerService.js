export default {
  table: {
    key: 'Id',
    footer: 'Foots',
    cnName: '客服',
    name: 'Mkt_CustomerService',
    url: '/Mkt_CustomerService/',
    sortName: 'CreateDate',
    searchFormFields: { Title: '', Type: '', Enable: '' },
    columns: [
      { field: 'Id', title: 'Id', type: 'int', width: 90, hidden: true, readonly: true, require: true, align: 'left' },
      { field: 'Title', title: '标题', type: 'string', width: 200, require: true, align: 'left', sortable: true },
      { field: 'Type', title: '类型', type: 'int', bind: { key: 'service_type', data: [] }, width: 100, align: 'left' },
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
