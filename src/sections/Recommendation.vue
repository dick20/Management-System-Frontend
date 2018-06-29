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
        hr
        h2 {{ recommendation.title }}
        p {{ recommendation.tag }}
        // TODO: fix image
        .image
          .recommendation-image(style="background-image: url({{recommendation.image}})")
        .detail(v-for="detail in recommendation.details")
          .detail-description {{ detail.description }}
          .detail-dish
            .detail-dish-text
              .detail-dish-name {{detail.dish.name}}
              .detail-dish-price ￥ {{detail.dish.price}}
            // TODO: fix imageURL capital
            .dish-image(style="background-image: url({{detail.dish.imageURL}})")


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
      console.log(res.data)
      this.$set('recommendation_list', res.data)
    })
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
