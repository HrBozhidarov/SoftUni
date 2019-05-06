const homeHandler = require('./home')
const productHandler = require('./product')
const staticHandler = require('./static-files')
const faviconHandler = require('./favicon')

module.exports = [ homeHandler, productHandler, staticHandler, faviconHandler ]
