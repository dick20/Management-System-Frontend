<template>
  <h1>Order</h1>
  <hr>
  <div class = "order-list">
    <div class = "order" v-for="order in orders">
      <div class = "order-orderId">{{order.orderId}}</div>
      <div class = "order-table">{{order.table}}</div>
      <div class = "dish" v-for="dish in order.dish">
        <div class = "dish-name">{{dish.name}}</div>
      </div>
      <div class = "order-requirement-description">{{order.requirement.description}}</div>
      <div class = "order-totalPrice">{{order.totalPrice}}</div>
      <div class = "order-time">{{order.time}}</div>
      <div class = "order-paymentStatus">{{order.paymentStatus}}</div>
      <div class = "order-cookingStatus">{{order.cookingStatus}}</div>
    </div>
  </div>
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
  .order-list {

  }
  .order {

  }
  .order-orderId {

  }
  .order-table {

  }
  .dish {

  }
  .dish-name {

  }
  .order-requirement-number {

  }
  .order-requirement-description {

  }
  .order-totalPrice {

  }
  .order-time {

  }
  .order-paymentStatus {

  }
  .order-cookingStatus {

  }
</style>
