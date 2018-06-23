import Vue from 'vue'
import Router from 'vue-router'
import Login from './sections/Login'
import Dashboard from './sections/Dashboard'
import About from './sections/About'
import Menu from './sections/Menu'

Vue.use(Router)

var router = new Router({
  history: true
})

router.map({
  'dashboard': {
    name: 'Dashboard',
    component: Dashboard,
    auth: true
  },
  'menu': {
    name: 'Menu',
    component: Menu,
    auth: true
  },
  'about': {
    name: 'About',
    component: About,
    auth: true
  },
  'login': {
    name: 'login',
    component: Login
  }
})

import Auth from './service/auth.js'

router.beforeEach(function (transition) {
  if (transition.to.auth && !Auth.isAuthenticated()) {
    transition.redirect('/login')
  } else {
    transition.next()
  }
})

router.redirect({
  '*': '/dashboard'
})

export default router
