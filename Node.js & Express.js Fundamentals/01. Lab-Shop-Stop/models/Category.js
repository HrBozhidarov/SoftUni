const mongoose = require('mongoose')
const Schema = mongoose.Schema
const ObjectId = Schema.Types.ObjectId

const categorySchema = new Schema({
  name: { type: String, require: true, unique: true },
  creator: { type: ObjectId, ref: 'User', required: true },
  products: [{ type: ObjectId, ref: 'Product' }]
})

let Category = mongoose.model('Category', categorySchema)

module.exports = Category
