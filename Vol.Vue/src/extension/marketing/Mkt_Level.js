export default {
  table: {
    key: 'Id',
    footer: 'Foots',
    cnName: '等级',
    name: 'Mkt_Level',
    url: '/Mkt_Level/',
    sortName: 'CreateDate',
    searchFormFields: { Name: '', Enable: '' },
    columns: [
      { field: 'Id', title: 'Id', type: 'int', width: 90, hidden: true, readonly: true, require: true, align: 'left' },
      { field: 'Name', title: '名称', type: 'string', width: 150, require: true, align: 'left', sortable: true },
      { field: 'Icon', title: '图标', type: 'img', width: 100, align: 'left' },
      { field: 'MinAmount', title: '最小金额', type: 'decimal', width: 110, align: 'left' },
      { field: 'MaxAmount', title: '最大金额', type: 'decimal', width: 110, align: 'left' },
      { field: 'Discount', title: '折扣', type: 'decimal', width: 90, align: 'left' },
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
