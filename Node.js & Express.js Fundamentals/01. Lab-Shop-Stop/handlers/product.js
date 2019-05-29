const Product = require('../models/Product')
const Category = require('./../models/Category')
const fs = require('fs')

module.exports.addGet = (req, res) => {
  Category.find()
    .then(categories => {
      res.render('products/add', { categories: categories })
    })
}

module.exports.editGet = (req, res) => {
  let params = req.params
  let id = params.id

  Product.findById(id)
    .then((product) => {
      if (!product) {
        res.status(404)

        return
      }

      Category.find()
        .then((categories) => {
          res.render('products/edit', {
            product: product,
            categories: categories
          })
        })
    })
}

module.exports.editPost = async (req, res) => {
  let params = req.params
  let id = params.id
  let editedProduct = req.body
  let product = await Product.findById(id)

  if (!product) {
    res.redirect(`/?error=${encodeURIComponent('Product was not found!')}`)
    return
  }

  product.name = editedProduct.name
  product.description = editedProduct.description
  product.price = editedProduct.price

  if (req.file) {
    product.image = req.file.destination + '\\' + req.file.originalname
  }

  if (product.category.toString() !== editedProduct.category) {
    Category.findById(product.category)
      .then((currentCategory) => {
        Category.findById(editedProduct.category)
          .then((nextCategory) => {
            let index = currentCategory.products.indexOf(product._id)
            if (index >= 0) {
              currentCategory.products.splice(index, 1)
            }

            currentCategory.save()
            nextCategory.products.push(product._id)
            nextCategory.save()
            product.category = editedProduct.category

            product.save()
              .then(() => {
                res.redirect('/?success=' + encodeURIComponent('Product was edit successfully!'))
              })
          })
      })
  } else {
    product.save()
    .then(() => {
      res.redirect(`/?success=${encodeURIComponent('Product was edit successfully!')}`)
    })
  }
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

module.exports.deleteProductGet = (req, res) => {
  let params = req.params
  let id = params.id

  Product.findById(id)
    .then((product) => {
      if (!product) {
        res.redirect(`/?error=${encodeURIComponent('Product was not found!')}`)
        return
      }

      res.render('products/delete', { product: product })
    })
}

module.exports.deleteProductPost = (req, res) => {
  let params = req.params
  let id = params.id

  Product.findById(id)
    .populate('category')
    .then((product) => {
      if (!product) {
        res.redirect(`/?error=${encodeURIComponent('Product was not found!')}`)
        return
      }

      let categoryId = product.category.id
      Category.findById(categoryId)
        
        .then((category) => {
          let index = category.products.indexOf(product.id)
          category.products.splice(index, 1)
          category.save()

          Product.deleteOne({ _id: product.id })
            .then(() => {
              let imgPath = './' + product.image
              fs.unlink(imgPath, (err) => {
                if (err) {
                  console.log(err)
                }
              })
            })

          res.redirect(`/?success=${encodeURIComponent('Product was deleted!')}`)
        })
    })
}

module.exports.buyProduct = (req, res) => {
  let params = req.params
  let id = params.id

  Product.findById(id)
    .then((product) => {
      if (!product) {
        res.redirect(`/?error=${encodeURIComponent('Product was not found!')}`)
        return
      }

      res.render('products/buy', { product: product })
    })
}
