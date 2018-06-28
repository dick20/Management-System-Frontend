const express = require('express')
const app = express()
const request = require('request')

const apiRoot = 'http://111.230.31.38:8080'

// root test
app.get('/', function (req, res) {
  res.send('hello world')
})

app.get('/restaurant/category', function (req, res) {
  let url = apiRoot + '/restaurant/category'
  console.log('sending request to ' + url)

  let options = {
    headers: {},
    url: url,
    method: 'GET',
    json: true,
    body: req.body
  }

  function callback (error, response, data) {
    if (!error && response.statusCode === 200) {
      console.log(data)
      res.json(data)
    }
  }

  request(options, callback)
})

app.listen(3000, () => console.log('listen on port 3000'))
