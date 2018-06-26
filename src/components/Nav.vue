<template lang="jade">
  navbar(placement='top', type='default', v-show='$route.auth')
    // Brand as slot
    a.navbar-brand(slot='brand', v-link="{ path: '/' }", title='Home') Hippo 管理系统
    li
      a(v-link="{ path: '/dashboard' }") 概况
    li
      a(v-link="{ path: '/menu' }") 菜品
    li
      a(v-link="{ path: '/order' }") 订单
    li
      a(v-link="{ path: '/about' }") 关于我们
    dropdown(:text='isAuthenticated() ? getUser().restaurantName : "None"', slot='right')
      li
        a(href='javascript:void(0)', v-on:click='logout') Logout
  navbar(placement='top', type='default', v-show='!$route.auth')
    a.navbar-brand(slot='brand', href='/', title='Home') Hippo 管理系统
</template>

<script>
import {navbar, dropdown} from 'vue-strap'
import auth from '../service/auth.js'

export default {
  name: 'monitornav',
  components: {
    navbar, dropdown
  },
  methods: {
    logout: function () {
      auth.logout(this)
    },
    isAuthenticated: function () {
      return auth.isAuthenticated()
    },
    getUser: function () {
      return auth.getUser()
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
