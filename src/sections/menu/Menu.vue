<template>
  <div class="menu-header">
    <app-button primary={true} @click.native="toggleBtn()">新增菜品</app-button>
  </div>

  <div class="floating-window" v-if="itemPopupVisible">
    <popup @itempopupvisible="itempopupvisible()" v-bind:categories="categories" v-bind:clickitem="clickitem" v-bind:deletebtn="deletebtn"></popup>
  </div>

  <div ref="popup" class="management-menu">
    <div class="page-header">
      <h1>menu</h1>
      <div class = "dish-list">
        <div class = "category" v-for="category in categories">
          <h2>{{category.name}}</h2>
          <div class = "dish" v-for="dish in category.dish">
            <div class = "dish-name">{{dish.name}}</div>
            <div class="dish-description">{{dish.description.comment}}</div>
            <div class="dish-price">￥ {{dish.price}}</div>
            <div class="dish-image" style=" background-image: url({{dish.imageURL}})"></div>
            <i class="iconfont icon-edit edit-icon" @click.native="editClick(dish)"></i>
          </div>
        </div>
      </div>
    </div>
  </div>

</template>

<script>
import api from '../../service/api.js'
import { Item, AddItemPopup, Button, FloatingWindow } from './components'
import Vue from 'vue'
export default {
  name: 'Menu',
  components: {
    Item,
    AppButton: Button,
    popup: AddItemPopup
  },
  data: function () {
    return {
      itemPopupVisible: false,
      categories: [],
      clickitem: null,
      deletebtn: false
    }
  },
  methods: {
    toggleBtn:function () {
      this.itemPopupVisible = true
      this.deletebtn = false
    },
    itempopupvisible: function () {
      this.itemPopupVisible = false
    },
    editClick:function (item) {
      this.deletebtn = true
      this.clickitem = item
      this.itemPopupVisible = true
      this.$nextTick(function () {
        this.$children[1].editItem(item)
      })
    }
  },
  ready: function () {
    api.getMenu(this).then((res) => {
      if (res.status === 200) {
        this.$set('categories', res.data)
      }
      console.log(this.categories)
    })
    this.$mount()
  }

}
</script>

<style scoped>
  .floating-window {
    position: absolute;
    right: 8px;
    top: 8px;
    bottom: 8px;
    width: 480px;
    background: #FAFAFA;
    box-shadow: 0 3px 6px rgba(0, 0, 0, 0.16), 0 3px 6px rgba(0, 0, 0, 0.23);
    border-radius: 2px;
  }
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
.edit-icon {
  /*visibility: hidden;*/
  float: right;
  margin-top:10px;
  margin-right:10px;
  /*width: 90px;*/
  /*height: 90px;*/
  color: #009dff;
  cursor: pointer;
}
.dish:hover>.edit-icon {
  visibility: visible;
}
</style>
