import Vue from 'vue'
import Resource from 'vue-resource'
import VueHighcharts from 'vue-highcharts'
import App from './App'
import router from './router'
import './sections/assets/iconfont/iconfont.css'
// Start up app
Vue.use(Resource)
Vue.use(VueHighcharts)
router.start(App, 'body')
