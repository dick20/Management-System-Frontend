<template>
  <button :class="{ btn: true, primary: primary, disabled: disabled }">
    <slot></slot>
  </button>
</template>

<script>
export default {
  props: ['primary', 'disabled']
}
</script>

<style scoped>
.btn {
  text-transform: uppercase;
  margin-right:12px;
  padding: 6px 12px;
  border: none;
  outline: none;
  background: none;
  color: #009dff;
}

.btn.primary {
  box-shadow: 0 1px 3px rgba(0,0,0,0.12), 0 1px 2px rgba(0,0,0,0.24);
  color: #fff;
  background: #009dff;
}

.btn.disabled {
  background: #E0E0E0;
  pointer-events: none;
}
</style>
