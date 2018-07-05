import Vue from 'vue'
import Button from '../../../src/components/Button.vue'

describe('Button.vue', () => {
  it('should render correct contents', () => {
    const vm = new Vue({
      template: '<div><button></button></div>',
      components: { Button }
    }).$mount()
    // expect(vm.$el.querySelector('.hello h1').textContent).to.contain('Hello World!')
  })
})
