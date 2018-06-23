<template>
  <div class="floating-window">
    <slot></slot>
  </div>
</template>

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
</style>
