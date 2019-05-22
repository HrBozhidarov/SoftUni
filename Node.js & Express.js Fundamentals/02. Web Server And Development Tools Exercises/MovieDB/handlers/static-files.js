const fs = require('fs')
const path = require('path')

module.exports = (req, res) => {
  let currentPath = req.url.pathname === '/favicon.ico' ? 'public/images/favicon.ico' : req.url.pathname
  fs.readFile(path.join(__dirname, '../', currentPath), (err, data) => {
    if (err) {
      res.writeHead(404, { 'Content-Type': 'text/plain' })
      console.log(__dirname)
      res.write('Not found!')
      res.end()
      return
    }

    let contentType = 'text/plain'

    if (req.method === 'GET' && currentPath.endsWith('.css')) {
      contentType = 'text/css'
    } else if (req.method === 'GET' && currentPath.endsWith('.js')) {
      contentType = 'text/javascript'
    } else if (req.method === 'GET' && currentPath.endsWith('.png')) {
      contentType = 'image/png'
    } else if (req.method === 'GET' && currentPath.endsWith('.jpg')) {
      contentType = 'image/jpeg'
    } else if (req.method === 'GET' && currentPath.endsWith('favicon.ico')) {
      contentType = 'image/x-icon'
    }

    res.writeHead(200, { 'Content-Type': contentType })
    res.write(data)
    res.end()
  })
}
