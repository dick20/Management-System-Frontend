<template>
  <div class="add-item-container">
    <header class="header">
     <span>Add Item</span>
    </header>

    <div class="form-container">
      <div class="control-container">
        <label for="name">菜名</label>
        <input type="text" class="control full" v-model="name" />
      </div>
      <div class="control-container">
        <label for="category">类别</label>
        <div class="tag-container">
          <div
            v-for="(title, tag) in selectedTag" :key="title"
            :class="{ tag: true, selected: selectedTag[title] }"
            @click='toggleTag(title)'>
            {{ title }}
          </div>
          <i class="iconfont icon-add add-icon tag"></i>
        </div>
        <div class="control-container">
          <label for="description">描述</label>
          <input type="text" class="control full" v-model="description" />
        </div>
        <div class="control-container">
          <label for="price">价格</label>
          <input type="number" class="control full" v-model.number="price" />
        </div>

        <div class="control-container">
          <label>上传图片</label>
          <label class="path-text">图片URL</label>
          <input type="text" class="control full" v-model="image" />
          <label class="path-text">本地图片</label>
          <image-upload v-bind:image="image"></image-upload>
        </div>
      </div>

      <div class="button-container">
        <app-button primary={true} @click.native="dismiss">取消</app-button>
        <app-button primary={true} @click.native="deleteItem" v-if="deletebtn">删除</app-button>
        <app-button primary={true} @click.native="addItem">确认</app-button>
      </div>
    </div>
  </div>
</template>

<script>
import { Button, ImageUpload } from '.'
import Vue from 'vue'
import mapValues from 'lodash/mapValues'
import api from '../service/api.js'

export default {
  components: {
    AppButton: Button,
    ImageUpload
  },
  props: {
    categories: {
      type: Array,
      required: true
    },
    deletebtn: {
      type: Boolean,
      required: true
    },
    clickitem: {
      type: Object,
      required: true
    }
  },
  data: function () {
    let d = {}
    this.categories.filter(function (type) {
      d[type.name] = false
    })
    return {
      name: '',
      dishId: 0,
      category: '',
      description: '',
      price: 0,
      image: '',
      selectedTag: d,
      deleteBtn: this.deletebtn
    }
  },
  methods: {
    toggleTag (tag) {
      Vue.set(this.selectedTag, tag, !this.selectedTag[tag])
      this.category = tag
    },
    addItem: function () {
      this.addMenuItem()
      this.dismiss()
    },
    dismiss: function () {
      this.$emit('itempopupvisible')
    },
    addMenuItem: function () {
      let json = {}
      let that = this
      this.categories.filter(function (type) {
        if (type.name === that.category) {
          json.categoryId = Number(type.categoryId)
        }
      })
      json.dishId = Number(this.dishId)
      json.name = this.name
      json.price = Number(this.price)
      json.imageUrl = this.image
      let json_ = {
        'dishId': this.dishId,
        'name': this.name,
        'categoryId': json.categoryId,
        'imageUrl': this.image,
        'price': Number(this.price)
      }
      console.log(json_)
      if (this.deletebtn === true) {
        api.putDish(json_)
      } else {
        api.postDish(json_)
      }
      this.$emit('updatemenu')
    },
    editItem: function () {
      this.name = this.clickitem.name
      this.dishId = this.clickitem.dishId
      this.price = this.clickitem.price
      this.image = this.clickitem.imageUrl
      let that = this
      this.categories.filter(function (type) {
        if (type.categoryId === that.clickitem.categoryId) {
          that.toggleTag(type.name)
          that.category = type.name
        }
      })
    },
    deleteItem: function () {
      api.deleteDish(this.clickitem.dishId)
      this.dismiss()
//      this.$emit('updatemenu')
    }
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
  .add-item-container {
    display: flex;
    flex-direction: column;
    height: 100%;
  }

  .header {
    height: 48px;
    padding: 0 12px;
    background: #009dff;
    color: #fff;
    margin-bottom: 24px;
  }

  .header > span {
    line-height: 48px;
  }

  .form-container {
    padding: 4px;
    flex-grow: 1;
  }

  .control-container {
    padding: 4px;
    margin-bottom: 6px;
  }

  .control-container.inline {
    display: flex;
    justify-content: space-between;
    align-items: center;
  }

  .control {
    height: 30px;
    box-sizing: border-box;
    border: 1px solid #ededed;
    border-radius: 4px;
    font-size: 16px;
    outline: none;
    padding: 0 12px;
  }

  .control.full {
    width: 100%;
    margin-top: 8px;
  }

  .control-container.inline .control {
    width: 15%;
    text-align: center;
  }
  .button-container {
    display: flex;
    flex-direction: row-reverse;
    padding: 8px;
  }
  .tag-container {
    display: flex;
    flex-wrap: wrap;
    margin-top: 8px;
  }

  .tag {
    font-size: 14px;
    border: 1px solid #ededed;
    border-radius: 4px;
    padding: 4px 8px;
    margin-right: 8px;
    margin-bottom: 4px;
    color: #9E9E9E;
    cursor: pointer;
    user-select: none;
  }

  .tag.selected {
    border: none;
    color: #fff;
    background: #009dff;
    border: 1px solid #009dff;
  }

  .button-container {
    display: flex;
    flex-direction: row-reverse;
    padding: 8px;
  }
  .path-text{
    width: 100%;
    font-size: smaller;
    margin: 4px;
  }
  .add-icon {
    width: 50px;
    vertical-align: middle;
    text-align: center;
    background: #ffdc66;
    font-weight: bold;
  }
</style>
