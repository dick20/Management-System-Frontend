<template lang="jade">

</template>

<script>
  import api from '../service/api.js'
  export default {
    name: 'Order',
    data: function () {
      return {
        orders: []
      }
    },
    ready: function () {
      api.getOrder(this).then((res) => {
        console.log(res.data)
        if (res.status === 200) {
          this.$set('orders', res.data)
        }
      })
    }
  }
</script>

<style scoped>
  .category {
    width: 100%;
    display: inline-block;
  }
  .dish {
    width: 200px;
    height: 200px;
    background-color: #f0efef;
    display: inline-block;
    padding: 5px;
    margin: 20px;
  }
  .dish-name {
    font-weight: bold;
  }
  .dish-description {
    font-size: 10px;
  }
  .dish-price {
    color: red
  }
  .dish-image {
    height: 100px;
    background-size: cover;
  }
</style>
