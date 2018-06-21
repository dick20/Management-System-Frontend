<template lang="jade">
  .management-menu
    .page-header
      h1
        | Menu
</template>

<script>
import api from '../service/api.js'

export default {
  name: 'Menu',

  ready: function () {
    api.getMenu(this).then((res) => {
      console.log(res)
    })
  }

}
</script>

<style scoped>

</style>
