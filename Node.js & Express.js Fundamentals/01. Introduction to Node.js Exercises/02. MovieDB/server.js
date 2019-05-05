const http = require('http')
const url = require('url')
const port = 3000
const handlers = require('./handlers')
const postParserMiddleware = require('./config/postParser')

/**
 *
 * @param {http.ClientRequest} req
 * @param {http.ClientResponse} res
 */
http.createServer((req, res) => {
  req.url = url.parse(req.url)

  postParserMiddleware(req, res)
    .then(() => {
      for (const handler of handlers) {
        if (!handler(req, res)) {
          break
        }
      }
    })
}).listen(port)

console.log(`Server listening on port ${port}`)
