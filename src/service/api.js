import axios from 'axios'
let apiRoot = 'http://111.230.31.38:8080/'

export default {
  getMenu: function (context) {
    return context.$http.get(apiRoot)
  }
}
