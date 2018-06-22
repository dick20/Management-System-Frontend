<template>
  <main class="menu">
    <div class="menu-header">
      <app-button primary={true} @click.native="itemPopupVisible = true">新增菜品</app-button>
    </div>

    <div class="category-container" v-for="(items, category) in menu.categories" :key="category">
      <span class="category-header">{{ category }}</span>
      <div class="item-container">
        <item v-for="item in items" :key="item.id" :item="item"></item>
      </div>
    </div>

    <transition name="slide-fade">
      <floating-window v-if="itemPopupVisible">
        <add-item-popup @itempopupvisible="itempopupvisible()"></add-item-popup>
      </floating-window>
    </transition>
  </main>

  <div class="management-menu">
    <div class="page-header">
      <h1>menu</h1>
      <div class = "dish-list">
        <div class = "category" v-for="category in categories">
          <h2>{{category.name}}</h2>
          <div class = "dish" v-for="dish in category.foods">
            <div class = "dish-name">{{dish.name}}</div>
            <div class="dish-description">{{dish.description}}</div>
            <div class="dish-price">￥ {{dish.price}}</div>
            <div class="dish-image" style=" background-image: url({{dish.image_url}})"></div>
          </div>
        </div>
      </div>
    </div>
  </div>

</template>

<script>
import api from '../service/api.js'
import { Item, AddItemPopup, Button, FloatingWindow } from './components'
import { bus } from './bus.js'

export default {
  name: 'Menu',
  components: {
    Item,
    AppButton: Button,
    FloatingWindow,
    AddItemPopup
  },
  data: function () {
    return {
      itemPopupVisible: false,
      categories: []
    }
  },
  methods: {
    itempopupvisible: function () {
      this.itemPopupVisible = false
      console.log(this.itemPopupVisible)
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

.menu-header {
  padding: 8px;
  display: flex;
  flex-direction: row-reverse;
}

.category-container {
  padding: 18px 0;
}

.category-header {
  margin-left: 8px;
  text-transform: uppercase;
  color: #FF5722;
}

.item-container {
  display: flex;
  flex-wrap: wrap;
}
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
