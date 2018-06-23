<template lang="jade">
  .monitor-page-dashboard
    .page-header
      h1 Dashboard

</template>

<script>
import api from '../service/api.js'

export default {
  name: 'Dashboard',

  ready: function () {
    let param = {
      'pageSize': 10,
      'pageNumber': 1
    }
    api.getOrder(param.pageSize, param.pageNumber).then((res) => {
    })
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
