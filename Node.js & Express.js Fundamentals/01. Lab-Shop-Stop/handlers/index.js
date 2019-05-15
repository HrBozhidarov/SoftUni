const homeHandler = require('./home')
const productHandler = require('./product')
const staticHandler = require('./static-files')
const faviconHandler = require('./favicon')
const categoryHandler = require('./category')

module.exports = [ homeHandler, categoryHandler, productHandler, staticHandler, faviconHandler ]
