export default {
  table: {
    key: 'Id',
    footer: 'Foots',
    cnName: '会员重复IP',
    name: 'Mkt_MemberDuplicateIp',
    url: '/Mkt_MemberDuplicateIp/',
    sortName: 'CreateDate',
    searchFormFields: { Ip: '' },
    columns: [
      { field: 'Id', title: 'Id', type: 'int', width: 90, hidden: true, readonly: true, require: true, align: 'left' },
      { field: 'Ip', title: 'IP地址', type: 'string', width: 150, align: 'left', sortable: true },
      { field: 'MemberCount', title: '会员数', type: 'int', width: 100, align: 'left' },
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
