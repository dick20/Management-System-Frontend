import axios from 'axios'
import qs from 'qs'

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
    axios.delete('/api/restaurant/dish/' + dishID)
    .then(function (response) {
      console.log(response)
    })
    .catch(function (error) {
      console.log(error)
    })
  },
  getOrder: function (pageSize, pageNum) {
    return axios.get('/api/restaurant/order?pageSize=5&pageNumber=2')
  },
  getRecommendation: function () {
    return axios.get('/api/restaurant/recommendation')
  }
}
