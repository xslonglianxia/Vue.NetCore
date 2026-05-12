export default {
  table: {
    key: 'Id',
    footer: 'Foots',
    cnName: '系统设置',
    name: 'Mkt_Setting',
    url: '/Mkt_Setting/',
    sortName: 'CreateDate',
    searchFormFields: { Key: '', GroupName: '' },
    columns: [
      { field: 'Id', title: 'Id', type: 'int', width: 90, hidden: true, readonly: true, require: true, align: 'left' },
      { field: 'Key', title: '键', type: 'string', width: 150, require: true, align: 'left', sortable: true },
      { field: 'Value', title: '值', type: 'string', width: 200, align: 'left' },
      { field: 'Description', title: '描述', type: 'string', width: 200, align: 'left' },
      { field: 'GroupName', title: '分组', type: 'string', width: 120, align: 'left' },
      { field: 'Sort', title: '排序', type: 'int', width: 80, align: 'left' },
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
