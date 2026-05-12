export default {
  table: {
    key: 'Id',
    footer: 'Foots',
    cnName: '文件引用',
    name: 'Sys_FileReference',
    url: '/Sys_FileReference/',
    sortName: 'CreateDate',
    searchFormFields: { EntityType: '', EntityId: '', FieldName: '' },
    columns: [
      { field: 'Id', title: 'Id', type: 'int', width: 90, hidden: true, readonly: true, require: true, align: 'left' },
      { field: 'FileId', title: '文件Id', type: 'int', width: 100, require: true, align: 'left' },
      { field: 'EntityType', title: '实体类型', type: 'string', width: 130, align: 'left' },
      { field: 'EntityId', title: '实体Id', type: 'int', width: 100, align: 'left' },
      { field: 'FieldName', title: '字段名称', type: 'string', width: 130, align: 'left' },
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
