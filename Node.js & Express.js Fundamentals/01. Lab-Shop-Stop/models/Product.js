const mongoose = require('mongoose')
const Schema = mongoose.Schema
var ObjectId = Schema.Types.ObjectId;

let productSchema = new Schema({
  name: { type: String, required: true },
  description: { type: String },
  price: { type: Number, min: 0, max: Number.MAX_VALUE, default: 0 },
  image: { type: String },
  creator: { type: ObjectId, ref: 'User', required: true },
  category: { type: ObjectId, ref: 'Category', required: true },
  buyer: { type: ObjectId, ref: 'User' }
})

let Product = mongoose.model('Product', productSchema)

module.exports = Product
