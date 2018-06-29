<template lang="jade">
  .recommendation-page
    .page-header
      h1 Recommendation

    h2 新增推荐
    form.form-horizontal.new_recommendation
      .form-group
        label.col-sm-1.control-label 标题
        .col-sm-2
          input.form-control(type='text', placeholder='标题', v-model='newtitle')
        label.col-sm-1.control-label 标签
        .col-sm-2
          input.form-control(type='text', placeholder='标签', v-model='newtag')
        label.col-sm-1.control-label 大图
        .col-sm-5
          input.form-control(type='text', placeholder='URL', v-model='newimageUrl')
      .form-group
        label.col-sm-1.control-label 描述1
        .col-sm-8
          input.form-control(type='text', placeholder='描述', v-model='newdescription1')
        label.col-sm-1.control-label 菜品1
        .col-sm-2
          input.form-control(type='text', placeholder='菜品名称', v-model='newdishName1')
      .form-group
        label.col-sm-1.control-label 描述2
        .col-sm-8
          input.form-control(type='text', placeholder='描述', v-model='newdescription2')
        label.col-sm-1.control-label 菜品2
        .col-sm-2
          input.form-control(type='text', placeholder='菜品名称', v-model='newdishName2')
      .form-group
        .col-sm-offset-5.col-sm-2
          button.btn.btn-default(type='button', v-on:click='updateRecommendation(newtitle, newtag, newimageUrl, newdishName1, newdescription1, newdishName2, newdescription2)') Submit
        

    .recoommendation_list
      .recommendation(v-for="recommendation in recommendation_list")
        hr
        h2 {{ recommendation.title }}
        p {{ recommendation.tag }}
        // TODO: fix image
        .image
          .recommendation-image(style="background-image: url({{recommendation.imageUrl}})")
        .detail(v-for="detail in recommendation.details")
          .detail-description {{ detail.description }}
          .detail-dish
            .detail-dish-text
              .detail-dish-name {{detail.dish.name}}
              .detail-dish-price ￥ {{detail.dish.price}}
            // TODO: fix imageURL capital
            .dish-image(style="background-image: url({{detail.dish.imageUrl}})")


</template>

<script>
import api from '../service/api.js'

export default {
  name: 'Recommendation',

  data: function () {
    return {
      recommendation_list: [],
      newtitle: '',
      newtag: '',
      newimageUrl: '',
      newdishName1: '',
      newdescription1: '',
      newdishName2: '',
      newdescription2: ''
    }
  },

  ready: function () {
    api.getRecommendation().then((res) => {
      console.log(res.data)
      this.$set('recommendation_list', res.data)
    })
  },

  methods: {
    updateRecommendation: function (newtitle, newtag, newimageUrl, newdishName1, newdescription1, newdishName2, newdescription2) {
      var self = this
      api.updateRecommendation({
        title: newtitle,
        tag: newtag,
        imageUrl: newimageUrl,
        details: [
          {
            dishName: newdishName1,
            description: newdescription1,
          },
          {
            dishName: newdishName2, 
            description: newdescription2
          }
        ]
      })
    }
  }

}
</script>

<style scoped>

.new_recommendation {
  margin: 30px;

}

.recommendation-image {
  height: 300px;
  width: 300px;
  background-size: cover;
  margin-left: auto;
  margin-right: auto;
}

.detail {
  margin: 20px;
  height: 100%;
}

.detail-dish {
  margin-left: auto;
  margin-right: auto;
  margin-top: 10px;
  width: 50%;
  height: 150px;
  display: inline-block;
}

.detail-dish-text {
  float: left;
}

.detail-dish-name {
  font-weight: bold;
}

.dish-image {
  width: 150px;
  height: 150px;
  background-size: cover;
  border-radius: 5%;
}

</style>
