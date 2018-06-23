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
            v-for="(title, tag) in tags" :key="tag"
            :class="{ tag: true, selected: selectedTags[tag] }"
            @click='toggleTag(tag)'>
            {{ tag }}
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
import { Button, ImageUploader, ImageUpload, CATEGORIES } from '.'
import Vue from 'vue'
import { mapMutations } from 'vuex'
import mapValues from 'lodash/mapValues'
import api from '../../../service/api.js'

export default {
  components: {
    AppButton: Button,
    ImageUploader,
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
    }
  },
  data: function () {
    return {
      name: '',
      description: '',
      price: null,
      image: '',
      tags: CATEGORIES,
      selectedTags: mapValues(CATEGORIES, () => false),
      item: {},
      deleteBtn: this.deletebtn
    }
  },
  methods: {
    toggleTag (tag) {
      Vue.set(this.selectedTags, tag, !this.selectedTags[tag])
      this.item.category = tag
      console.log(this.item.category)
    },
    addItem: function () {
      this.item.name = this.name
      this.item.description = this.description
      this.item.price = this.price
      this.item.image = this.image
      this.addMenuItem(this.item)
      this.dismiss()
    },
    dismiss: function () {
      this.$emit('itempopupvisible')
    },
    addMenuItem: function (item) {
      let json = {}
      let _type
      this.categories.filter(function (type) {
        if (type.name === item.category) {
          json.CategoryID = type.CategoryID
        }
      })
      json.description = []
      json.description.comment = item.description
      json.description.hot = 5
      json.description.monthlySales = 0
      json.dishID = this.categories[json.CategoryID-1].dish.length+1
      json.name = item.name
      json.price = Number(item.price)
      json.imageURL = item.image
      console.log(json)
      if (this.deletebtn === true) {
        api.postMenu(json)
      } else {
        api.postMenu(json)
      }
    },
    editItem: function(item) {
      console.log(item)
      this.deleteBtn = true
      this.name = item.name
      this.description = item.description.comment
      this.price = item.price
      this.image = item.imageURL
      let that = this
      this.categories.filter(function (type) {
        if (type.CategoryID === item.CategoryID) {
          that.toggleTag(type.name)
        }
      })
    },
    reset: function() {
      this.name =  '',
      this.description = '',
      this.price = null,
      this.image = '',
      this.tags = CATEGORIES,
      this.selectedTags = mapValues(CATEGORIES, () => false),
      this.deleteBtn = false
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
