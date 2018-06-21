const apiRoot = 'http://111.230.31.38:8080'

export default {
  getMenu: function (context) {
    return context.$http.get(apiRoot)
  },

  getOrder: function (context, pageSize, pageNum) {
    return context.$http.get(apiRoot + '/restaurant/order?pageSize=' + pageSize + '?pageNum=' + pageNum)
  }
}
