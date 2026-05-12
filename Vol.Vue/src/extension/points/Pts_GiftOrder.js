export default {
  table: {
    key: 'Id',
    footer: 'Foots',
    cnName: '积分兑换订单',
    name: 'Pts_GiftOrder',
    url: '/Pts_GiftOrder/',
    sortName: 'CreateDate',
    searchFormFields: { OrderNo: '', Username: '', Status: '' },
    columns: [
      { field: 'Id', title: 'Id', type: 'int', width: 90, hidden: true, readonly: true, require: true, align: 'left' },
      { field: 'OrderNo', title: '订单号', type: 'string', link: true, width: 180, align: 'left', sortable: true },
      { field: 'Username', title: '用户名', type: 'string', width: 120, align: 'left' },
      { field: 'GiftName', title: '礼品名称', type: 'string', width: 150, align: 'left' },
      { field: 'Points', title: '积分', type: 'int', width: 90, align: 'left' },
      { field: 'Quantity', title: '数量', type: 'int', width: 80, align: 'left' },
      { field: 'TotalPoints', title: '总积分', type: 'int', width: 90, align: 'left' },
      { field: 'Status', title: '状态', type: 'int', bind: { key: 'gift_order_status', data: [] }, width: 90, align: 'left' },
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
