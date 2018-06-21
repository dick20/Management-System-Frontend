import Vue from 'vue'
import Resource from 'vue-resource'
import VueHighcharts from 'vue-highcharts'

import App from './App'

Vue.use(Resource)
Vue.use(VueHighcharts)

import router from './router.js'

// Start up app
router.start(App, 'body')
