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
    axios.put(apiRoot + 'restaurant/dish/' + item.DishID.toString(), item, {
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
    axios.delete(apiRoot + 'restaurant/dish/' + dishID.toString(), {
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
    return axios.get(apiRoot + 'restaurant/order?pageSize=2&pageNumber=2', {
      headers: {
        'Access-Control-Allow-Origin': '*'
      }})
  }
}
