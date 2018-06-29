import router from '../router.js'
import axios from 'axios'

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
    return window.localStorage.getItem('user') != null
  },
  login (context, creds, redirect) {
    return axios.post('/api/restaurant/session', creds).then((res) => {
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
    axios.delete('/api/restaurant/session').then((res) => {
      window.localStorage.removeItem('user')
      router.go('/login')
    })
  }
}
