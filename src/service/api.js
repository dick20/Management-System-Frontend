import axios from 'axios'
let apiRoot = 'http://111.230.31.38:8080/'

export default {
  getMenu: function () {
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
      }
    })
  },
  getRecommendation: function () {
    return axios.get('https://easy-mock.com/mock/5afbe65c3e9a2302b68981e5/recommendation', {
      headers: {
        'Access-Control-Allow-Origin': '*'
      }
    })
  }
}
