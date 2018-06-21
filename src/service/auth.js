import router from '../router.js'

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

  // authentication status
  isAuthenticated: function () {
    return window.localStorage.getItem('user') != null
  },

  // Send a request to the login URL and save the returned JWT
  login (context, creds, redirect) {
    return context.$http.post(apiRoot + '/restaurant/session', creds).then((res) => {
      let user
      if (res.status === 200) {
        user = res.body
      } else {
        return {
          data: null,
          msg: '请求失败',
          status: 0
        }
      }
      window.localStorage.setItem('user', JSON.stringify(user.data))
      context.$root.user = user.data
      return res
    })
  },

    // To log out
  logout: function (context) {
    context.$http.get(apiRoot + '/restaurant/session').then(() => {
      window.localStorage.removeItem('user')
      router.go('/login')
    })
  }
}
