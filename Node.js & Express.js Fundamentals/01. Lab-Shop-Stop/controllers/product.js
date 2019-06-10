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
      
      if (product.creator.equals(req.user._id) || req.user.roles.indexOf('Admin') >= 0) {
      Category.find()
        .then((categories) => {
          res.render('products/edit', {
            product: product,
            categories: categories
          })
        })
      } else {
        res.redirect(`/?error=${encodeURIComponent('You cannot edit this product!')}`);
      }
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
  if(product.creator.equals(req.user._id) || req.user.roles.indexOf('Admin') >= 0) {
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
  } else {
    res.redirect(`/?error=${encodeURIComponent('You cannot edit this product!')}`);
  }
}

module.exports.addPost = (req, res) => {
  let product = req.body
  product.image = '\\' + req.file.path
  product.creator = req.user._id

  Product.create(product).then((inserProduct) => {
    Category.findById(product.category).then(category => {
      category.products.push(inserProduct._id)
      category.save()
    })
    
    res.redirect('/')
  }).catch(error => {
    res.render('products/add', { error: error.message }) // pass model

    return
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
        
        if (product.creator.equals(req.user._id) || req.user.roles.indexOf('Admin') >= 0) {
          res.render('products/delete', { product: product })
        } else {
          res.redirect(`/?error=${encodeURIComponent('You cannot delete this product!')}`)
        }
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

      if (product.creator.equals(req.user._id) || req.user.roles.indexOf('Admin') >= 0) {
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
      } else {
        res.redirect(`/?error=${encodeURIComponent('You cannot delete this product!')}`)
      }
    })
}

module.exports.buyPost = (req, res) => {
  let params = req.params
  let id = params.id

  Product.findById(id)
    .then((product) => {
      if (product.buyer) {
        let error = `error=${encodeURIComponent('Product was already bought!')}`
        res.redirect(`/?${error}`)
        return
      }

      product.buyer = req.user._id
      product.save()
        .then(() => {
          req.user.boughtProducts.push(id)
          req.user.save()
            .then(() => {
              res.redirect('/')
            })
        })

      res.render('products/buy', { product: product })
    })
}
