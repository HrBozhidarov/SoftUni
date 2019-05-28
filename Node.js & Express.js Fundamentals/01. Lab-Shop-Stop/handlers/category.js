const Category = require('./../models/Category')

module.exports.addGet = (req, res) => {
  res.render('category/add', {category: ''})
}

module.exports.addPost = (req, res) => {
  let category = req.body

  Category.create(category).then(() => {
    res.redirect('/')
  })
}
