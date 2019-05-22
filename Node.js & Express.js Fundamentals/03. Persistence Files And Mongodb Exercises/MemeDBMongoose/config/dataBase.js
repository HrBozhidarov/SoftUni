const fs = require('fs')

let db = []
let dbPath = './db/db.json'

let load = () => {
  return new Promise((resolve, reject) => {
    fs.readFile(dbPath, (err, data) => {
      if (err) {
        console.log(err)
        return
      }
      console.log('loading')
      db = JSON.parse(data)
      resolve()
    })
  })
}

let save = () => {
  return new Promise((resolve, reject) => {
    fs.writeFile(dbPath, JSON.stringify(db), (err) => {
      if (err) {
        console.log(err)
        return
      }
      resolve()
    })
  })
}

let add = (movie) => {
  db.push(movie)
}

let dbCopy = () => {
  return db.slice(0)
}

module.exports = {
  load: load,
  save: save,
  getDb: dbCopy,
  add: add
}
