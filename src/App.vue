<template lang="jade">
  link(href='//cdn.bootcss.com/bootstrap/3.3.6/css/bootstrap.min.css', rel='stylesheet')
  #app
    monitornav
    #monitor-container.continer
      router-view
    footer#monitor-footer
      .container
        .row
          .col-md-12
            center Copyright (c) 2018 Copyright Tiny Hippo All Rights Reserved.
            br
</template>

<script>
import monitornav from './components/Nav'

export default {
  name: 'app',
  components: {
    monitornav
  },
  replace: false
}
</script>

<style>
  html, body, #app {
    height: 100%;
    width: 100%;
  }
  body {
    padding-top: 0px !important;
  }
  #app {
    overflow: scroll;
  }
  #monitor-container {
    width: 75%;
    margin: 0 auto;
    margin-top: 6%;
  }
  #monitor-footer {
    font-size: 10pt;
    color: #ccc;
    margin-top: 20px;
    margin-bottom: 20px;
  }
</style>
