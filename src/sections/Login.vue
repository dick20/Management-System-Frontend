<template lang="jade">
  .monitor-page-login
    alert(:show.sync='error', placement='top', duration='3000', type='danger', width='400px', dismissable='')
      strong 登录失败!
      p {{message}}

    #login-container.container
      .page-header
        h1
          | 请登录
      form.form-horizontal
        .form-group
          label.col-sm-2.control-label(for='inputEmail3') Username
          .col-sm-10
            input.form-control(type='text', placeholder='Username', v-model='username')
        .form-group
          label.col-sm-2.control-label(for='inputPassword3') Password
          .col-sm-10
            input#inputPassword3.form-control(type='password', placeholder='Password', v-model='password')
        .form-group
          .col-sm-offset-2.col-sm-10
            .checkbox
              label
                input(type='checkbox', v-model='remember')
                |  Remember me
              br
        .form-group
          .col-sm-offset-2.col-sm-10
            button.btn.btn-default(type='button', v-on:click='login(username, password)') Sign in
</template>

<script>
import { navbar, alert } from 'vue-strap'
import auth from '../service/auth.js'
import router from '../router.js'

export default {
  name: 'Login',
  data: function () {
    return {
      username: '',
      password: '',
      remember: false,
      error: false,
      message: ''
    }
  },
  beforeMount: function () {
    if (auth.isAuthenticated()) {
      router.go('/dashboard')
    }
  },
  methods: {
    login: function (username, password) {
      var self = this
      self.showError = function (message) {
        self.$set('error', true)
        self.$set('message', message)
      }

      if (!username || username === '') {
        self.showError('请输入用户名！'); return false
      }

      if (!password || password === '') {
        self.showError('请输入密码！'); return false
      }

      auth.login(this, {
        phone: username,
        password: password
      }).then((res) => {
        console.log(res)
        if (res.status === 200) {
          router.go('/dashboard')
        } else {
          self.showError(res.msg)
        }
      }).catch((res) => {
        this.showError('服务器发生错误！')
      })
    }
  },
  components: {
    navbar, alert
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  #login-container {
    margin-top: 5%;
    width: 50%;
  }
  .alert-icon {
    margin: 3px;
  }
</style>
