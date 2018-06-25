<template lang="jade">
  h1 Dashboard
  .blocks
    .block
      img(src='assets/image/restaurant1.jpg')
    .block
      img(src='assets/image/restaurant2.jpg')
    .block
      img(src='assets/image/restaurant3.jpg')

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
  h1 {
    margin-bottom:50px;
  }
  .blocks {
    /*position: relative;*/
    /*display: -webkit-box;*/
    /*display: -ms-flexbox;*/
    display: flex;
    -webkit-box-align: center;
    -ms-flex-align: center;
    align-items: center;
    -webkit-box-pack: center;
    -ms-flex-pack: center;
    justify-content: center;
  }
  .blocks .block {
    position: relative;
    display: block;
    width: 300px;
    height: 400px;
    margin: 20px;
    -webkit-transform: perspective(800px) rotateY(-20deg);
    transform: perspective(800px) rotateY(-20deg);
    -webkit-transition: -webkit-transform .3s;
    transition: -webkit-transform .3s;
    transition: transform .3s, -webkit-transform .3s;
  }
  .blocks .block img {
    width: auto;
    max-width: 100%;
  }
  body .blocks .block.hover, body .blocks .block:hover {
    -webkit-transform: rotateY(0);
    transform: rotateY(0);
    cursor: pointer;
  }

</style>
