export default {
  table: {
    key: 'Id',
    footer: 'Foots',
    cnName: '权限分组',
    name: 'Sys_Group',
    url: '/Sys_Group/',
    sortName: 'CreateDate',
    searchFormFields: { Name: '', Code: '', Enable: '' },
    columns: [
      { field: 'Id', title: 'Id', type: 'int', width: 90, hidden: true, readonly: true, require: true, align: 'left' },
      { field: 'Name', title: '名称', type: 'string', width: 150, require: true, align: 'left', sortable: true },
      { field: 'Code', title: '编码', type: 'string', width: 150, align: 'left' },
      { field: 'Description', title: '描述', type: 'string', width: 200, align: 'left' },
      { field: 'Sort', title: '排序', type: 'int', width: 80, align: 'left' },
      { field: 'Enable', title: '启用', type: 'byte', bind: { key: 'enable', data: [] }, width: 90, require: true, align: 'left' },
      { field: 'Creator', title: '创建人', type: 'string', width: 130, readonly: true, align: 'left' },
      { field: 'CreateDate', title: '创建时间', type: 'datetime', width: 150, readonly: true, align: 'left', sortable: true },
      { field: 'Modifier', title: '修改人', type: 'string', width: 130, readonly: true, align: 'left' },
      { field: 'ModifyDate', title: '修改时间', type: 'datetime', width: 150, readonly: true, align: 'left', sortable: true }
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
