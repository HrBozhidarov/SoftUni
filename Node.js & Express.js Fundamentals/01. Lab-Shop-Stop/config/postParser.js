const qs = require('querystring')

module.exports = (req) => {
  if (req.method === 'POST') {
    return new Promise((resolve, reject) => {
      let body = []
      req.on('data', (chunk) => {
        body.push(chunk)
      }).on('end', () => {
        body = qs.parse(Buffer.concat(body).toString())
        resolve(body)
      })
    })
  } else {
    return Promise.resolve()
  }
}
