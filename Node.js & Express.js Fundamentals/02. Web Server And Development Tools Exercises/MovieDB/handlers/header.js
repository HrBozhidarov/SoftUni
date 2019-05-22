const fs = require('fs')
const path = require('path')
const db = require('../config/dataBase')

module.exports = (req, res) => {
  if (req.headers.statusheader === 'Full') {
    fs.readFile(path.join(__dirname, '../views/status.html'), (err, data) => {
      if (!err) {
        let count = db.length
        data = data.toString().replace('<h1>{{replaceMe}}</h1>', count)
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
