<template>
  <div class="menu-item">
    <div class="flex-column">
      <span class="item-title">{{ item.title }}</span>
    </div>
    <app-icon class="edit-icon" name="edit"></app-icon>
  </div>
</template>

<script>
export default {
  props: ['item']

}
</script>

<style scoped>
.menu-item {
  width: 240px;
  height: 56px;
  margin: 8px;
  padding: 12px;
  background: #fff;
  box-shadow: 0 3px 6px rgba(0, 0, 0, 0.16), 0 3px 6px rgba(0, 0, 0, 0.23);
  display: flex;
  align-items: center;
  justify-content: space-between;
}

.flex-column {
  display: flex;
  flex-direction: column;
}

.item-title {
  font-size: 20px;
  margin-bottom: 4px;
}

.edit-icon {
  visibility: hidden;
  color: #757575;
}

.menu-item:hover>.edit-icon {
  visibility: visible;
}

</style>
