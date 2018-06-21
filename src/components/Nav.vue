<template lang="jade">
  navbar(placement='top', type='default', v-show='$route.auth')
    // Brand as slot
    a.navbar-brand(slot='brand', v-link="{ path: '/' }", title='Home') Hippo Management
    li
      a(v-link="{ path: '/dashboard' }") 概况
    li
      a(v-link="{ path: '/menu' }") 菜品
    li
      a(v-link="{ path: '/About' }") About
  navbar(placement='top', type='default', v-show='!$route.auth')
    a.navbar-brand(slot='brand', href='/', title='Home') Hippo Management
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
