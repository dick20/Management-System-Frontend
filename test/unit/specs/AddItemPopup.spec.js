import Vue from 'vue'
import AddItemPopup from '../../../src/components/AddItemPopup.vue'
import api from '../../../src/service/api.js'

let json = {
  'dishId': 99,
  'name': '冰淇淋',
  'categoryId': '热销',
  'imageUrl': 'http://wx4.sinaimg.cn/mw690/006fVSiZgy1fsslnd5csaj30tp0w4107.jpg',
  'price': 20
}
let categories = [{
  'categoryId': 1,
  'dish': [{
    'categoryId': 1,
    'dishId': 1,
    'imageUrl': 'http://wx3.sinaimg.cn/mw690/006fVSiZgy1fsp440kepoj30dw0dwab7.jpg',
    'name': '熏肉卷配野菌',
    'price': 20.0
  }],
  'name': '热销'
}]
function initComponet (Component, propsData) {
  const Ctor = Vue.extend(Component)
  const vm = new Ctor({ propsData }).$mount()
  return vm
}
let deletebtn = true
describe('AddItemPopup.vue', () => {
  it('should render correct contents', () => {
    const vm = new Vue({
      template: "<div><add-item-popup :categories='categories' :deletebtn='deletebtn' :clickitem='clickitem'></add-item-popup></div>",
      components: {AddItemPopup},
      data: {
        categories: categories,
        clickitem: json,
        deletebtn: true
      }
    }).$mount()
    expect(vm.$el.querySelector('label').textContent).to.contain('菜名')
  })

  it('editItem is a function', () => {
    expect(typeof AddItemPopup.methods.editItem).to.equal('function')
  })

  it('fill label with clickitem s info', () => {
    let vm = new Vue({
      template: "<div><add-item-popup :categories='categories' :deletebtn='deletebtn' :clickitem='clickitem'></add-item-popup></div>",
      components: {AddItemPopup},
      data: {
        categories: categories,
        clickitem: json,
        deletebtn: true
      }
    }).$mount()
    // console.log(vm.$children[0].name)
    vm.$children[0].editItem()
    // console.log(vm.$children[0].name)
    expect(vm.$children[0].name).to.equal(json.name)
  })

  it('fill label with clickitem s info', () => {
    let vm = new Vue({
      template: "<div><add-item-popup :categories='categories' :deletebtn='deletebtn' :clickitem='clickitem'></add-item-popup></div>",
      components: {AddItemPopup},
      data: {
        categories: categories,
        clickitem: json,
        deletebtn: true
      }
    }).$mount()
    expect(vm.$children[0].$el.querySelectorAll('.button-container button')[1].textContent).to.contain('删除')
  })
})
