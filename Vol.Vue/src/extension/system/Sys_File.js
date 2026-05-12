export default {
  table: {
    key: 'Id',
    footer: 'Foots',
    cnName: '文件',
    name: 'Sys_File',
    url: '/Sys_File/',
    sortName: 'CreateDate',
    searchFormFields: { Name: '', OriginalName: '', Extension: '' },
    columns: [
      { field: 'Id', title: 'Id', type: 'int', width: 90, hidden: true, readonly: true, require: true, align: 'left' },
      { field: 'Name', title: '文件名', type: 'string', width: 180, align: 'left', sortable: true },
      { field: 'OriginalName', title: '原始文件名', type: 'string', width: 180, align: 'left' },
      { field: 'Extension', title: '扩展名', type: 'string', width: 90, align: 'left' },
      { field: 'Size', title: '文件大小', type: 'decimal', width: 100, align: 'left' },
      { field: 'MimeType', title: 'Mime类型', type: 'string', width: 130, align: 'left' },
      { field: 'Path', title: '文件路径', type: 'string', width: 250, align: 'left' },
      { field: 'Hash', title: '文件哈希', type: 'string', width: 180, align: 'left' },
      { field: 'StorageType', title: '存储类型', type: 'int', bind: { key: 'storage_type', data: [] }, width: 100, align: 'left' },
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
