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
        <image-upload></image-upload>
      </div>
    </div>

    <div class="button-container">
      <app-button primary={true} @click.native="addItem">添加</app-button>
      <app-button primary={true} @click.native="dismiss">关闭</app-button>
    </div>

  </div>
  </div>
</template>

<script>
import { Button, ImageUploader, ImageUpload, CATEGORIES } from '.'
import Vue from 'vue'
import { mapMutations } from 'vuex'
import mapValues from 'lodash/mapValues'

export default {
  components: {
    AppButton: Button,
    ImageUploader,
    ImageUpload
  },
  data: function () {
    return {
      name: '',
      description: '',
      price: null,
      image: '',
      tags: CATEGORIES,
      selectedTags: mapValues(CATEGORIES, () => false)
    }
  },
  methods: {
    toggleTag (tag) {
      Vue.set(this.selectedTags, tag, !this.selectedTags[tag])
    },
    addItem: function () {
      const item = {
        name: this.name,
        description: this.description,
        price: this.price,
        image: '',
        category: { ...this.selectedTags }
      }
      this.addMenuItem(item)
      this.dismiss()
    },
    dismiss: function () {
      this.$emit('itempopupvisible')
    },
    ...mapMutations([
      'addMenuItem'
    ])
  }
}
</script>

<style scoped>
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
  margin-bottom: 8px;
}

.control-container.inline {
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.control {
  height: 32px;
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

</style>
