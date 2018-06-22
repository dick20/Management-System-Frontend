<template>
  <div class="chip" :style="{ backgroundColor: color }">
    <slot></slot>
  </div>
</template>

<script>
export default {
  props: {
    color: {
      type: String,
      default: '#388E3C'
    }
  },
  data: function () {
    return {
    }
  }
}
</script>

<style scoped>
.chip {
  color: #fff;
  font-size: 12px;
  padding: 4px 12px;
  margin: 4px;
  max-width: fit-content;
  text-transform: uppercase;
  border-radius: 2px;
}
</style>
