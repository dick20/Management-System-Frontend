import axios from 'axios'
import qs from 'qs'
// let apiRoot = 'http://111.230.31.38:8080/'
let apiRoot = 'http://localhost:3000/'

export default {
  getMenu: function () {
    return axios.get('/api/restaurant/category')
  },
  postDish: function (item) {
    axios.post('/api/restaurant/category', item)
    .then(function (response) {
      console.log(response)
    })
    .catch(function (error) {
      console.log(error)
    })
  },
  putDish: function (item) {
    axios.put('/api/restaurant/dish/' + item.dishId, item)
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
