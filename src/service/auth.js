import router from '../router.js'
import axios from 'axios'

let apiRoot = 'http://111.230.31.38:8080'

export default {
  getUser: function () {
    let user
    try {
      user = JSON.parse(window.localStorage.getItem('user'))
    } catch (e) {
      console.log(e)
      window.localStorage.removeItem('user')
      router.go('/login')
    }
    return user
  },
  isAuthenticated: function () {
    // return window.localStorage.getItem('user') != null
    return true
  },
  login (context, creds, redirect) {
    return axios.post(apiRoot + '/restaurant/session', creds).then((res) => {
      let user = {}
      if (res.status === 200) {
        user.data = res.data
        user.status = 200
      } else {
        return {
          data: null,
          msg: '请求失败',
          status: 0
        }
      }
      window.localStorage.setItem('user', JSON.stringify(user.data))
      context.$root.user = user.data
      return user
    })
  },
  logout: function (context) {
    axios.delete(apiRoot + '/restaurant/session').then((res) => {
      window.localStorage.removeItem('user')
      router.go('/login')
    })
  }
}
