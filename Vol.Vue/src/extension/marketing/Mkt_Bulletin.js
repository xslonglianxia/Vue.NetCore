export default {
  table: {
    key: 'Id',
    footer: 'Foots',
    cnName: '公告板',
    name: 'Mkt_Bulletin',
    url: '/Mkt_Bulletin/',
    sortName: 'CreateDate',
    searchFormFields: { Title: '', Enable: '' },
    columns: [
      { field: 'Id', title: 'Id', type: 'int', width: 90, hidden: true, readonly: true, require: true, align: 'left' },
      { field: 'Title', title: '标题', type: 'string', width: 200, require: true, align: 'left', sortable: true },
      { field: 'Sort', title: '排序', type: 'int', width: 80, align: 'left' },
      { field: 'Enable', title: '启用', type: 'byte', bind: { key: 'enable', data: [] }, width: 90, require: true, align: 'left' },
      { field: 'PublishTime', title: '发布时间', type: 'datetime', width: 150, align: 'left' },
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
