export default {
  table: {
    key: 'Id',
    footer: 'Foots',
    cnName: '积分礼品',
    name: 'Pts_Gift',
    url: '/Pts_Gift/',
    sortName: 'CreateDate',
    searchFormFields: { Name: '', Enable: '' },
    columns: [
      { field: 'Id', title: 'Id', type: 'int', width: 90, hidden: true, readonly: true, require: true, align: 'left' },
      { field: 'Name', title: '名称', type: 'string', width: 150, require: true, align: 'left', sortable: true },
      { field: 'Image', title: '图片', type: 'img', width: 150, align: 'left' },
      { field: 'Points', title: '积分', type: 'int', width: 90, align: 'left' },
      { field: 'Stock', title: '库存', type: 'int', width: 90, align: 'left' },
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
