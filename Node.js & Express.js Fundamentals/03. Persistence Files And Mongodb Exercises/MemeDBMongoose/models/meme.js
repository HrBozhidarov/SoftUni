const mongoose = require('mongoose')
const Schema = mongoose.Schema
const memeSchema = new Schema({
  title: { type: String, required: true },
  memeSrc: { type: String, required: true },
  description: { type: String, required: true },
  privacy: { type: String, required: true, default: 'off' },
  dateStamp: { type: Date, default: Date.now }
})

let memeModel = mongoose.model('Meme', memeSchema)

module.exports = memeModel
