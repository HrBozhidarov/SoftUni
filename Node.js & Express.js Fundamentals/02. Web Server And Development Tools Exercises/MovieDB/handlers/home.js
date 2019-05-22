const fs = require('fs')
const path = require('path')

module.exports = (req, res) => {
  if (req.url.pathname === '/' && req.method === 'GET') {
    fs.readFile(path.join(__dirname, '../views/home.html'), (err, data) => {
      if (!err) {
        res.writeHead(200, { 'Content-Type': 'text/html' })
        res.write(data)
        res.end()
        return
      }

      return true
    })
  } else {
    return true
  }
}
