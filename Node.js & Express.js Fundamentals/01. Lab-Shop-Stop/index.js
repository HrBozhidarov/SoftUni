const http = require('http')
const handlers = require('./handlers/index')
const config = require('./config/config')
const db = require('./config/database.config')

let environment = process.env.NODE_ENV || 'development'

db(config[environment])

http.createServer((req, res) => {
  for (let handler of handlers) {
    if (!handler(req, res)) {
      break
    }
  }
}).listen(3000)
