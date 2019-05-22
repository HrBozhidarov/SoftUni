const mongoose = require('mongoose')
const Schema = mongoose.Schema
const imageSchema = new Schema({
  imageUrl: { type: String, required: true },
  imageTitle: { type: String, required: true },
  creationDate: { type: Date, required: true, default: Date.now },
  description: { type: String, required: true },
  tags: [{ type: mongoose.SchemaTypes.ObjectId }]
})

let Image = mongoose.model('Image', imageSchema)

module.exports = Image
