import Vue from 'vue'
import Vuex from 'vuex'
import { getMenu } from '../service/api'

Vue.use(Vuex)

/* eslint-disable no-param-reassign */
export default new Vuex.Store({
  state: {
    categories: []
  },
  mutations: {
    // setData (state, payload) {
    //   state.categories = payload
    // },
    addMenuItem (state, payload) {
      console.log(state)
      // state.categories.push(payload)
      // Vue.set(state.menu.items, payload.id, payload);
    }
  }
  // actions: {
  //   async fetchData ({ commit }) {
  //     const [menu] = await Promise.all([
  //       getMenu()
  //     ])
  //
  //     commit({
  //       type: 'setData',
  //       menu
  //     })
  //   }
  // }
})
