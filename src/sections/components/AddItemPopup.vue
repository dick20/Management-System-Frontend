<template>
  <div class="add-item-container">
    <header class="header">
     <span>Add Item</span>
    </header>

    <div class="form-container">
      <div class="control-container">
        <label for="name">菜名</label>
        <input type="text" class="control full" v-model="title" />
      </div>
      <div class="control-container">
        <label for="category">类别</label>
        <input type="text" class="control full" v-model="category" />
      </div>
      <div class="control-container">
        <label for="description">描述</label>
        <input type="text" class="control full" v-model="description" />
      </div>
      <div class="control-container">
        <label for="price">价格</label>
        <input type="number" class="control full" v-model.number="price" />
      </div>
      <!--<div class="hello">-->
        <!--<image-uploader @onChange="imgChange" ></image-uploader>-->
      <!--</div>-->
      <div class="hello">
        <image-upload @onChange="imgChange" ></image-upload>
      </div>
    </div>

    <div class="button-container">
      <app-button primary={true} @click.native="addItem">Add</app-button>
      <app-button @click.native="dismiss">Discard</app-button>
    </div>

  </div>
</template>

<script>
import { buildMenuItem } from '../../utils/order'
// import { Button, ImageUploader } from '.'
import { Button, ImageUploader, ImageUpload } from '.'

export default {
  components: {
    AppButton: Button,
    ImageUploader,
    ImageUpload
  },
  data: function () {
    return {
      name: '',
      category: '',
      description: '',
      price: null,
      image: '',
      maxSize: 3072
    }
  },
  methods: {
    addItem: function () {
      const item = buildMenuItem({
        name: this.name,
        category: this.category,
        description: this.description,
        price: this.price,
        image: ''
      })
      this.addMenuItem(item)
      this.dismiss()
    },
    dismiss: function () {
      this.$emit('itempopupvisible')
    },
    imgChange (files) {
      if (files) {
        console.log(files)
      }
    }
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
  background: #F4511E;
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
  margin-right: 4px;
  margin-bottom: 4px;
  color: #9E9E9E;
  cursor: pointer;
  user-select: none;
}

.tag.selected {
  border: none;
  color: #fff;
  background: #F4511E;
  border: 1px solid #F4511E;
}

.button-container {
  display: flex;
  flex-direction: row-reverse;
  padding: 8px;
}
.hello {
  width: 650px;
  margin-left: 34%;
}
</style>
