const fs = require('fs')
const path = require('path')

const Product = require('../models/Product')
const Category = require('./../models/Category')

module.exports.addGet = (req, res) => {
  Category.find()
    .then(categories => {
      res.render('products/add', { categories: categories })
    })
}

module.exports.addPost = (req, res) => {
  let product = req.body
  product.image = '\\' + req.file.path

  Product.create(product).then((inserProduct) => {
    Category.findById(product.category).then(category => {
      category.products.push(inserProduct._id)
      category.save()
    })

    res.redirect('/')
  })
}
