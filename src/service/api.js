import axios from 'axios'
let apiRoot = 'http://111.230.31.38:8080/'

export default {
  getMenu: function (context) {
    return axios.get(apiRoot + 'restaurant/category')
  },
  postDish: function (item) {
    // axios.post(apiRoot + 'restaurant/category', item, {
    //   headers: {
    //     'Access-Control-Allow-Origin': '*'
    //   }
    // })
    // .then(function (response) {
    //   console.log(response)
    // })
    // .catch(function (error) {
    //   console.log(error)
    // })
  },
  putDish: function (item) {
    console.log(apiRoot + 'restaurant/dish/' + item.dishId.toString())
    axios.put(apiRoot + 'restaurant/dish/' + item.dishId.toString(), item, {
      headers: {
        'Access-Control-Allow-Origin': '*'
      }
    })
      .then(function (response) {
        console.log(response)
      })
      .catch(function (error) {
        console.log(error)
      })
  },
  deleteDish: function (dishID) {
    console.log(dishID)
    axios.delete(apiRoot + 'restaurant/dish/' + dishID, {
      headers: {
        'Access-Control-Allow-Origin': '*'
      }
    })
      .then(function (response) {
        console.log(response)
      })
      .catch(function (error) {
        console.log(error)
      })
  },
  getOrder: function (pageSize, pageNum) {
    return axios.get(apiRoot + 'restaurant/order?pageSize=5&pageNumber=2', {
      headers: {
        'Access-Control-Allow-Origin': '*'
      }})
  }
}
