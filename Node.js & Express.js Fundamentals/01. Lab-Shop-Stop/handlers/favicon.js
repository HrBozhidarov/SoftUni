const url = require('url')
const fs = require('fs')

module.exports = (req, res) => {
  let path = url.parse(req.pathname).pathname

  if (req.method === 'GET' && path === 'favicon.ico') {
    fs.readFile('../content/images/favicon.ico', (err, data) => {
      if (err) {
        console.log('404 not found!')
      }
      res.writeHead(200, {
        'Content-Type': 'image/x-icon'
      })
      res.write(data)
      res.edn()
    })
  } else {
    return true
  }
}
