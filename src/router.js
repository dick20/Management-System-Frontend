import Vue from 'vue'
import Router from 'vue-router'
import Login from './sections/Login'
import Dashboard from './sections/Dashboard'
import About from './sections/About'
<<<<<<< HEAD

import Menu from './sections/menu/Menu'
=======
import Menu from './sections/Menu'
import Order from './sections/Order'
>>>>>>> c8934cff29738623d226988fa169929b1a06321d

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
  'order': {
    name: 'Order',
    component: Order,
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
<<<<<<< HEAD
    transition.redirect('/login')
=======
    transition.redirect('/menu')
>>>>>>> c8934cff29738623d226988fa169929b1a06321d
  } else {
    transition.next()
  }
})

router.redirect({
  '*': '/dashboard'
})

export default router
