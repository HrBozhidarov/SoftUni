const url = require('url')
const fs = require('fs')
const path = require('path')
const Product = require('../models/Product')
const multiparty = require('multiparty')
const shortid = require('shortid')
const Category = require('./../models/Category')

module.exports = (req, res) => {
  req.pathname = req.pathname || url.parse(req.url).pathname

  if (req.method === 'GET' && req.pathname === '/product/add') {
    fs.readFile(path.join(__dirname, '../views/products/add.html'), (err, data) => {
      if (!err) {
        Category.find().then((categories) => {
          let replacment = '<select class="input-field" name="category">'
          for (const category of categories) {
            replacment += `<option value="${category._id}">${category.name}</option>`
          }
          replacment += '</select>'

          let html = data.toString().replace('{categories}', replacment)
          res.writeHead(200, {
            'Content-Type': 'text/html'
          })
          res.write(html)
          res.end()
        })

        return
      }

      console.log(err)
    })
  } else if (req.method === 'POST' && req.pathname === '/product/add') {
    let form = new multiparty.Form()
    let product = {}

    form.on('part', (part) => {
      if (part.filename) {
        let dataString = ''

        part.setEncoding('binary')
        part.on('data', (data) => {
          dataString += data
        })

        part.on('end', () => {
          let extension = part.filename.split('.').pop()
          let fileName = shortid.generate()
          let filePath = `./content/images/${fileName}.${extension}`

          product.image = filePath
          fs.writeFile(filePath, dataString, { encoding: 'ascii' }, (err) => {
            if (err) {
              console.log(err)
            }
          })
        })
      } else {
        part.setEncoding('utf-8')
        let field = ''
        part.on('data', (data) => {
          field += data
        })

        part.on('end', () => {
          product[part.name] = field
        })
      }
    })

    form.on('close', () => {
      Product.create(product).then((inserProduct) => {
        Category.findById(product.category).then(category => {
          category.products.push(inserProduct._id)
          category.save()

          res.writeHead(302, {
            'Location': '/'
          })

          res.end()
        })
      })
    })

    form.parse(req)
  } else {
    return true
  }
}
