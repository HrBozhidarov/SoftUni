const Product = require('../models/Product')
const Category = require('./../models/Category')

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
