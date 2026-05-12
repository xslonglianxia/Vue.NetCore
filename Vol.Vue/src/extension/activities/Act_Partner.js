export default {
  table: {
    key: 'Id',
    footer: 'Foots',
    cnName: '活动合作方',
    name: 'Act_Partner',
    url: '/Act_Partner/',
    sortName: 'CreateDate',
    searchFormFields: { ActivityId: '', Name: '' },
    columns: [
      { field: 'Id', title: 'Id', type: 'int', width: 90, hidden: true, readonly: true, require: true, align: 'left' },
      { field: 'ActivityId', title: '活动Id', type: 'int', bind: { key: 'act_activity', data: [] }, width: 100, require: true, align: 'left' },
      { field: 'Name', title: '名称', type: 'string', width: 150, require: true, align: 'left', sortable: true },
      { field: 'Link', title: '链接', type: 'string', width: 200, align: 'left' },
      { field: 'Sort', title: '排序', type: 'int', width: 80, align: 'left' },
      { field: 'Visible', title: '是否可见', type: 'byte', bind: { key: 'enable', data: [] }, width: 90, align: 'left' },
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
