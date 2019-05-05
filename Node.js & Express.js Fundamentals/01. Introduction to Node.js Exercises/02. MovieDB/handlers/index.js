const homeHandler = require('./home')
const staticHandler = require('./static-files')
const moviesHandler = require('./movies')
const headerHandler = require('./header')

module.exports = [headerHandler, homeHandler, moviesHandler, staticHandler]
