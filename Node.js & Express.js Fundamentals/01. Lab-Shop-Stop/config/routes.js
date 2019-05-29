const handlers = require('../handlers')
const multer = require('multer')

let upload = multer({ dest: './content/images' })

module.exports = (app) => {
  app.get('/', handlers.home.index)

  app.get('/product/edit/:id', handlers.product.editGet)
  app.get('/product/add', handlers.product.addGet)
  app.post('/product/add', upload.single('image'), handlers.product.addPost)
  app.post('/product/edit/:id', upload.single('image'), handlers.product.editPost)

  app.get('/category/add', handlers.category.addGet)
  app.get('/category/:category/products', handlers.category.productByCategory)
  app.post('/category/add', handlers.category.addPost)
}
