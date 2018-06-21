import { Doughnut } from 'vue-chartjs'

export default Doughnut.extend({
  props: ['data', 'options'],
  ready: function () {
    this.render(this.data, this.options)
  }
})
