import axios from 'axios'
let apiRoot = 'http://111.230.31.38:8080/'

export default {
  getMenu: function (context) {
    axios.get(apiRoot + 'restaurant/category')
      .then(function (response) {
        console.log(response)
      })
      .catch(function (error) {
        console.log(error)
      }).then(function (response) {
        console.log(response)
      })
      .catch(function (error) {
        console.log(error)
      })
    return axios.get(apiRoot + 'restaurant/category')
  },
  postMenu: function (item) {
    axios.post(apiRoot + 'restaurant/category', {item})
      .then(function (response) {
        console.log(response)
      })
      .catch(function (error) {
        console.log(error)
      })
  },
  putMenu: function (item) {
    axios.put(apiRoot + 'restaurant/dish/' + item.dishID, item)
      .then(function (response) {
        console.log(response)
      })
      .catch(function (error) {
        console.log(error)
      })
  },
  getOrder: function (pageSize, pageNum) {
    return axios.get(apiRoot + '/restaurant/order?pageSize=' + pageSize + '?pageNum=' + pageNum)
  }
}
