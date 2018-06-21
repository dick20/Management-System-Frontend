<template lang="jade">
  .management-menu
    .page-header
      h1 Menu
    .dishes-list
      .category(v-for="category in categories")
        h2 {{category.name}}
        .dish(v-for="dish in category.foods")
          .dish-name {{dish.name}}
          .dish-description {{dish.description}}
          .dish-price ￥ {{dish.price}}
          .dish-image(style="background-image: url({{dish.image_url}})")

</template>

<script>
import api from '../service/api.js'

export default {
  name: 'Menu',

  data: function () {
    return {
      categories: []
    }
  },

  ready: function () {
    api.getMenu(this).then((res) => {
      console.log(res.data[0].name)
      if (res.status === 200) {
        this.$set('categories', res.data)
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
