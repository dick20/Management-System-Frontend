import Vue from 'vue'
import Resource from 'vue-resource'
import VueHighcharts from 'vue-highcharts'
import App from './App'
import router from './router'
import store from './store/index'
// Start up app
Vue.use(Resource)
Vue.use(VueHighcharts)

var vRouter = new Vue({
  el: '#app',
  router,
  store,
  template: '<App/>',
  components: { App }
})
Vue.use({
  vRouter
})
router.start(App, 'body')
