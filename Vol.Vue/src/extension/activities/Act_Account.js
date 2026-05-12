export default {
  table: {
    key: 'Id',
    footer: 'Foots',
    cnName: '活动参与记录',
    name: 'Act_Account',
    url: '/Act_Account/',
    sortName: 'CreateDate',
    searchFormFields: { ActivityId: '', Username: '' },
    columns: [
      { field: 'Id', title: 'Id', type: 'int', width: 90, hidden: true, readonly: true, require: true, align: 'left' },
      { field: 'ActivityId', title: '活动Id', type: 'int', bind: { key: 'act_activity', data: [] }, width: 100, align: 'left' },
      { field: 'Username', title: '用户名', type: 'string', width: 120, align: 'left', sortable: true },
      { field: 'ParticipateTime', title: '参与时间', type: 'datetime', width: 150, align: 'left' },
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
  formFields: {},
  methods: {
    onInit() {
      this.editFormFields = {};
      this.editFormOptions = [];
    }
  }
}
