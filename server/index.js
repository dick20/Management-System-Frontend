const express = require('express')
const request = require('request')
const app = express()
const qs = require('qs')

const apiRoot = 'http://111.230.31.38:8080'

app.all('*', function (req, res, next) {
  res.header('Access-Control-Allow-Origin', '*')
  res.header('Access-Control-Allow-Headers', 'X-Requested-With')
  res.header('Access-Control-Allow-Methods', 'PUT,POST,GET,DELETE,OPTIONS')
  res.header('X-Powered-By', ' 3.2.1')
  res.header('Content-Type', 'application/json')
  next()
})

// root test
app.get('/', function (req, res) {
  res.send('hello world')
})

app.get('/restaurant/category', function (req, res) {
  let url = apiRoot + '/restaurant/category'

  let options = {
    headers: {},
    url: url,
    method: 'GET',
    json: true,
    body: req.body
  }

  function callback (error, response, data) {
    if (!error && response.statusCode === 200) {
      res.json(data)
    }
  }

  request(options, callback)
})

app.put('/restaurant/dish/:dishId/:other', function (req, res) {
  let url = apiRoot + '/restaurant/dish/' + req.params.dishId
  console.log('PUT', url)
  let bodystring = req.params.other
  console.log(req.headers)

  let options = {
    headers: req.headers,
    url: url,
    method: 'PUT',
    json: true,
    body: qs.parse(bodystring)
  }

  function callback (error, response, data) {
    // console.log(response)
    if (!error && response.statusCode === 200) {
      console.log(data)
      res.json(data)
    }
  }

  request(options, callback)
})

app.listen(3000, () => console.log('listen on port 3000'))
