const handlers = require('../controllers')
const multer = require('multer')
const auth = require('./auth')

let upload = multer({ dest: './content/images' })

module.exports = (app) => {
  app.get('/', handlers.home.index)

  app.get('/product/delete/:id', auth.isAuthenticated, handlers.product.deleteProductGet)
  app.get('/product/buy/:id', auth.isAuthenticated, handlers.product.buyPost)
  app.get('/product/edit/:id', auth.isAuthenticated, handlers.product.editGet)
  app.get('/product/add', auth.isAuthenticated, handlers.product.addGet)
  app.post('/product/add', auth.isAuthenticated,
     upload.single('image'), handlers.product.addPost)
  app.post('/product/edit/:id', upload.single('image'), handlers.product.editPost)
  app.post('/product/delete/:id', handlers.product.deleteProductPost)

  app.get('/category/add', auth.isInRole('Admin'), handlers.category.addGet)
  app.get('/category/:category/products', handlers.category.productByCategory)
  app.post('/category/add', auth.isInRole('Admin'), handlers.category.addPost)

  app.get('/users/login', handlers.user.loginGet)
  app.get('/users/register', handlers.user.registerGet)
  app.post('/users/register', handlers.user.registerPost)
  app.post('/users/login', handlers.user.loginPost)
  app.post('/users/logout', auth.isAuthenticated, handlers.user.logout)
}
