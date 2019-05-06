const http = require('http')
const handlers = require('./handlers/index')

http.createServer((req, res) => {
  for (let handler of handlers) {
    if (!handler(req, res)) {
      break
    }
  }
}).listen(3000)
