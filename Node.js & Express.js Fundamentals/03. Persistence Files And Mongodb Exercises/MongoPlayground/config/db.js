const mongoose = require('mongoose')
const localhostUrl = 'mongodb://localhost:27017/mongoPlayground'

mongoose.Promise = global.Promise

module.exports = mongoose.connect(localhostUrl, { useNewUrlParser: true })
