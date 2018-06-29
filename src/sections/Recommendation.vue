<template lang="jade">
  .recommendation-page
    .page-header
      h1 Recommendation

    h2 新增推荐
    form.form-horizontal.new_recommendation
      .form-group
        label.col-sm-1.control-label 标题
        .col-sm-2
          input.form-control(type='text', placeholder='Title', v-model='title')
        label.col-sm-1.control-label 标签
        .col-sm-2
          input.form-control(type='text', placeholder='Tag', v-model='tag')
        label.col-sm-1.control-label 大图
        .col-sm-5
          input.form-control(type='text', placeholder='url', v-model='imageUrl')
      .form-group
        label.col-sm-1.control-label 描述1
        .col-sm-8
          input.form-control(type='text', placeholder='description', v-model='description1')
        label.col-sm-1.control-label 菜品ID1
        .col-sm-2
          input.form-control(type='text', placeholder='dishId', v-model='dishId1')
      .form-group
        label.col-sm-1.control-label 描述2
        .col-sm-8
          input.form-control(type='text', placeholder='description', v-model='description2')
        label.col-sm-1.control-label 菜品ID2
        .col-sm-2
          input.form-control(type='text', placeholder='dishId', v-model='dishId2')
        

    .recoommendation_list
      .recommendation(v-for="recommendation in recommendation_list")
        h2 {{ recommendation.title }}
        p {{ recommendation.tag }}
        .recommendation-image(style="background: url({{recommendation.image}})")
        .detail(v-for="detail in recommendation.details")
          .detail-description {{ detail.description }}
          .detail-dish
            .detail-dish-name {{detail.dish.name}}
            .detail-dish-price ￥ {{detail.dish.price}}
            .dish-image(style="background: url({{detail.dish.imageUrl}})")


</template>

<script>
import api from '../service/api.js'

export default {
  name: 'Recommendation',

  data: function () {
    return {
      recommendation_list: []
    }
  },

  ready: function () {
    api.getRecommendation().then((res) => {
      this.$set('recommendation_list', res.data.data)
    })
  }

}
</script>

<style scoped>

.new_recommendation {
  margin: 30px;
}

.recommendation-image {
  width: 300px;
  height: 300px;
  background-size: contain;
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
  background: lightgray;
}

.detail-dish-name {
  font-weight: bold;
}

.dish-image {
  width: 100px;
  height: 100px;
  background-size: cover;
  border-radius: 5%;
}

</style>
