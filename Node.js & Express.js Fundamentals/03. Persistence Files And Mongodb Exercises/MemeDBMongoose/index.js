const http = require('http')
const url = require('url')
var qs = require('querystring')
const handlers = require('./handlers/handlerBlender')
const db = require('./config/memeDb')
const port = 2323

db.then(() => {
  console.log('Connect to datbase...')
  http
    .createServer((req, res) => {
      for (let handler of handlers) {
        req.pathname = url.parse(req.url).pathname
        req.query = qs.parse(url.parse(req.url).query)
        let task = handler(req, res)
        if (task !== true) {
          break
        }
      }
    }).listen(port, () => {
      console.log('Im listening on ' + port)
    })
}).catch(() => {
  console.log('Failed to load DB')
})
