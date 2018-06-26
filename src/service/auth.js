import router from '../router.js'

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
    // return window.localStorage.getItem('user') != null
    return true
  },

  // Send a request to the login URL and save the returned JWT
  login (context, creds, redirect) {
    return context.$http.post('/api/admin/login', creds).then((data) => {
      let user
      if (data.body) {
        user = data.body
      } else {
        return {
          data: null,
          msg: '请求失败',
          status: 0
        }
      }

      if (!user.status) {
        return {
          data: null,
          msg: user.msg,
          status: user.status
        }
      }

      window.localStorage.setItem('user', JSON.stringify(user.data))

      context.$root.user = user.data

      return user
    })
  },

    // To log out
  logout: function (context) {
    context.$http.get('/api/admin/logout').then((data) => {
      window.localStorage.removeItem('user')
      router.go('/login')
    })
  }
}
