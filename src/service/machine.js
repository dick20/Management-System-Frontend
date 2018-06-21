export default {
  getMachineList: function (context) {
    return context.$http.get('/api/machines/')
  },
  getOneMachineDetail: function (context, macId) {
    return context.$http.get('/api/machines/' + macId)
  }
}
