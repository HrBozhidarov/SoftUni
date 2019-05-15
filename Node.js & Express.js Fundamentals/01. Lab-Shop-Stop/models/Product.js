const mongoose = require('mongoose')
const Schema = mongoose.Schema

let productSchema = new Schema({
  name: { type: String, required: true },
  description: { type: String },
  price: { type: Number, min: 0, max: Number.MAX_VALUE, default: 0 },
  image: { type: String },
  category: { type: Schema.Types.ObjectId, ref: 'Category' },
  isBought: { type: Boolean, default: false }
})

let Product = mongoose.model('Product', productSchema)

module.exports = Product
