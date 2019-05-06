const url = require('url')
const fs = require('fs')
const path = require('path')
const postParser = require('./../config/postParser')
const db = require('./../config/database')

module.exports = (req, res) => {
  req.pathname = req.pathname || url.parse(req.url).pathname

  if (req.method === 'GET' && req.pathname === '/product/add') {
    fs.readFile(path.join(__dirname, '../views/products/add.html'), (err, data) => {
      if (!err) {
        res.write(data)
        res.end()
        return
      }

      console.log(err)
    })
  } else if (req.method === 'POST' && req.pathname === '/product/add') {
    postParser(req)
      .then((data) => {
        db.products.add(data)
        res.writeHead(302, { Location: '/' })
        res.end()
      })
  } else {
    return true
  }
}
