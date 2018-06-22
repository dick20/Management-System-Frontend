import axios from 'axios'
let apiRoot = 'http://111.230.31.38:8080/'

export default {
  getMenu: function (context) {
    return context.$http.get(apiRoot + 'restaurant/category')
    // return axios.get(apiRoot)
  },
  postMenu: function (context, item) {
    context.$http.post(apiRoot + 'restaurant/category', item)
      .then(function (response) {
        console.log('hello')
        console.log(response)
      })
      .catch(function (error) {
        console.log(error)
      })
  }
}
