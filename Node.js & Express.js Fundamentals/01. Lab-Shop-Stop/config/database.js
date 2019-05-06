let products = []
let count = 1

module.exports.products = {}

module.exports.products.add = (product) => {
  product.id = count
  count++
  products.push(product)
}

module.exports.products.getAll = () => {
  return products
}

module.exports.products.findByName = (productName) => {
  let product = products.find(x => x.name.includes(productName))

  return product
}
