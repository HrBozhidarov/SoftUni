const fs = require('fs')
const url = require('url')

module.exports = (req, res) => {
  let currentPath = url.parse(req.pathname).pathname

  fs.readFile('.' + currentPath, (err, data) => {
    if (err) {
      console.log(err)
      res.writeHead(404, {
        'Content-Type': 'text/plain'
      })
      res.write('404 not found!')
      res.end()
      return
    }

    let contentType = 'text/plain'

    if (req.method === 'GET' && currentPath.endsWith('css')) {
      contentType = 'text/css'
    } else if (req.method === 'GET' && currentPath.endsWith('js')) {
      contentType = 'text/javascript'
    }
    res.writeHead(200, {
      'Content-Type': contentType
    })
    res.write(data)
    res.end()
  })
}
