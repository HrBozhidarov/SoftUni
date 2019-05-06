const url = require('url')
const fs = require('fs')
const path = require('path')
const qs = require('querystring')
const db = require('./../config/database')

module.exports = (req, res) => {
  req.pathname = req.pathname || url.parse(req.url).pathname

  if (req.pathname === '/' && req.method === 'GET') {
    let filepath = path.normalize(path.join(__dirname, '../views/home/index.html'))
    fs.readFile(filepath, (err, data) => {
      if (!err) {
        res.writeHead(200, {
          'Content-Type': 'text/html'
        })

        let queryData = qs.parse(url.parse(req.url).query)
        let products = db.products.getAll()

        if (queryData.query) {
          products = products.filter(x => x.name.includes(queryData.query))
        }

        let dinamycContent = ''

        products.forEach(x => {
          dinamycContent += `<div class="product-card">
                              <img src="${x.image}">
                              <h2>${x.name}</h2>
                              <p>${x.description}</p>
                             </div>`
        })

        let result = data.toString().replace('{content}', dinamycContent)
        res.write(result)
        res.end()
        return
      }

      console.log(err)
    })
  } else {
    return true
  }
}
