import axios from 'axios'
let apiRoot = 'http://111.230.31.38:8080/'

export default {
  getMenu: function (context) {
    return axios.get(apiRoot + 'restaurant/category')
  },
  getOrder: function (context) {
    return axios.get(apiRoot + 'restaurant/order?pageSize=20&pageNumber=1')
  },
  postDish: function (item) {
    axios.post(apiRoot + 'restaurant/category', item)
      .then(function (response) {
        console.log(response)
      })
      .catch(function (error) {
        console.log(error)
      })
  },
  putDish:function (item) {
    axios.put(apiRoot + 'restaurant/dish/' + item.dishID, item)
      .then(function (response) {
        console.log(response)
      })
      .catch(function (error) {
        console.log(error)
      })
  },
  deleteDish:function (dishID) {
    console.log(dishID)
    axios.delete(apiRoot + 'restaurant/dish/' + dishID)
      .then(function (response) {
        console.log(response)
      })
      .catch(function (error) {
        console.log(error)
      })
  }
}
