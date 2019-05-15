const fs = require('fs')
const url = require('url')
const path = require('path')
const qs = require('querystring')
const Category = require('./../models/Category')

module.exports = (req, res) => {
  req.pathname = req.pathname || url.parse(req.url).pathname

  if (req.pathname === '/category/add' && req.method === 'GET') {
    fs.readFile(path.normalize(path.join(__dirname, '../views/category/add.html')), (err, data) => {
      if (!err) {
        res.writeHead(200, { 'Content-Type': 'text/html' })
        res.write(data)
        res.end()
        return
      }

      console.log(err)
    })
  } else if (req.pathname === '/category/add' && req.method === 'POST') {
    let category = []
    req.on('data', (chunk) => {
      category.push(chunk)
    }).on('end', () => {
      category = qs.parse(Buffer.concat(category).toString())
      Category.create(category).then(() => {
        res.writeHead(302, { 'Location': '/' })
        res.end()
      }).catch(err => console.log(err))
    })
  } else {
    return true
  }
}
