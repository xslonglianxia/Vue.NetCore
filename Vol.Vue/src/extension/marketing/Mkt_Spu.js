export default {
  table: {
    key: 'Id',
    footer: 'Foots',
    cnName: '商品SPU',
    name: 'Mkt_Spu',
    url: '/Mkt_Spu/',
    sortName: 'CreateDate',
    searchFormFields: { Name: '', CategoryId: '', Enable: '' },
    columns: [
      { field: 'Id', title: 'Id', type: 'int', width: 90, hidden: true, readonly: true, require: true, align: 'left' },
      { field: 'Name', title: '商品名称', type: 'string', width: 180, require: true, align: 'left', sortable: true },
      { field: 'CategoryId', title: '分类', type: 'int', bind: { key: 'mkt_category', data: [] }, width: 100, align: 'left' },
      { field: 'Price', title: '价格', type: 'decimal', width: 110, align: 'left' },
      { field: 'CommissionRate', title: '佣金比例', type: 'decimal', width: 100, align: 'left' },
      { field: 'Image', title: '图片', type: 'img', width: 150, align: 'left' },
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
