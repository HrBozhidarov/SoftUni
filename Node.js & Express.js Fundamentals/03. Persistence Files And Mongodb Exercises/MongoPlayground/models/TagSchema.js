const mongoose = require('mongoose')
const Schema = mongoose.Schema
const TagSchema = new Schema({
  tagName: { type: String, required: true },
  creationDate: { type: Date, default: Date.now, required: true },
  images: [{ type: mongoose.SchemaTypes.ObjectId }]
})

TagSchema.methods.turnTagNameToLowercase = function () {
  return this.name.toLowercase()
}

let Tag = mongoose.model('Tag', TagSchema)

module.exports = Tag
