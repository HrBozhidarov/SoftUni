const Product = require('../models/Product')

module.exports.index = (req, res) => {
   let query = req.query

  Product.find()
    .populate('category')
    .then(products => {
      if (query.query) {
        products = products.filter(x => x.name.toLowerCase().includes(query.query.toLowerCase()))
      }
    
      let data = {
        products
      }
    
      if (query.error) {
        data.error = query.error
      } else if (query.success) {
        data.success = query.success
      }
      
      res.render('home/index', { 
        products: data.products,
        error: data.error,
        success: data.success
      })
  })
}
