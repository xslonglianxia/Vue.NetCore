export default {
  table: {
    key: 'Id',
    footer: 'Foots',
    cnName: '分类',
    name: 'Mkt_Category',
    url: '/Mkt_Category/',
    sortName: 'CreateDate',
    searchFormFields: { Name: '', Enable: '' },
    columns: [
      { field: 'Id', title: 'Id', type: 'int', width: 90, hidden: true, readonly: true, require: true, align: 'left' },
      { field: 'Name', title: '名称', type: 'string', width: 150, require: true, align: 'left', sortable: true },
      { field: 'Icon', title: '图标', type: 'img', width: 100, align: 'left' },
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
