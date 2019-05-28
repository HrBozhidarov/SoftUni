const Product = require('../models/Product')

module.exports.index = (req, res) => {
   let query = req.query

  Product.find({}, (err, products) => {
    if (query.query) {
      products = products.filter(x => x.name.toLowerCase().includes(query.query.toLowerCase()))
    }
    
    res.render('home/index', { products: products })
  })
}
