import axios from 'axios'
let apiRoot = 'http://111.230.31.38:8080/'

export default {
  getMenu: function (context) {
    return axios.get(apiRoot + 'restaurant/category')
  },
  postDish: function (item) {
    axios.post(apiRoot + 'restaurant/category', item, {
      headers: {
        'Access-Control-Allow-Origin': '*'
        // 'Access-Control-Allow-Methods':'POST',
        // 'Access-Control-Allow-Headers':'x-requested-with,content-type'
      }
    })
    .then(function (response) {
      console.log(response)
    })
    .catch(function (error) {
      console.log(error)
    })
  },
  putDish: function (item) {
    axios.put(apiRoot + 'restaurant/dish/' + item.dishID, item)
      .then(function (response) {
        console.log(response)
      })
      .catch(function (error) {
        console.log(error)
      })
  },
  deleteDish: function (dishID) {
    console.log(dishID)
    axios.delete(apiRoot + 'restaurant/dish/' + dishID)
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
