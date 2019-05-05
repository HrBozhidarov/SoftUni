let fs = require('fs')
let path = require('path')

const databasePath = path.join(__dirname, '/database/database.json')

let storage = {}

function throwIfKeyIsDiffrenceFromString (key) {
  if (typeof key !== 'string') {
    throw new Error('Invalid key!')
  }
}

function throwIfKeyNotExists (key) {
  if (!storage.hasOwnProperty(key)) {
    throw new Error('Key doesn`t exists!')
  }
}

module.exports = {
  put: function (key, value) {
    throwIfKeyIsDiffrenceFromString(key)
    if (storage.hasOwnProperty(key)) {
      throw new Error('Key already exists!')
    }
    storage[key] = value
  },
  get: function (key) {
    throwIfKeyIsDiffrenceFromString(key)
    throwIfKeyNotExists(key)
    return storage[key]
  },
  getAll: function () {
    if (Object.entries(storage).length === 0) {
      return 'There are no items in the storage.'
    }
    return storage
  },
  update: function (key, newValue) {
    throwIfKeyIsDiffrenceFromString(key)
    throwIfKeyNotExists(key)
    storage[key] = newValue
  },
  delete: function (key) {
    throwIfKeyIsDiffrenceFromString(key)
    throwIfKeyNotExists(key)
    delete storage[key]
  },
  clear: function () {
    storage = {}
  },
  saveSync: function () {
    fs.writeFileSync(databasePath, JSON.stringify(storage, null, 2))
  },
  loadSync: function () {
    if (fs.existsSync(databasePath)) {
      storage = JSON.parse(fs.readFileSync(databasePath))
    }
  },
  saveAsync: function () {
    return new Promise((resolve, reject) => {
      fs.writeFile(databasePath, JSON.stringify(storage, null, 2), (err) => {
        if (err) {
          reject(err)

          return
        }
        resolve('data was writed correctly!')
      })
    })
  },
  loadAsync: function () {
    return new Promise((resolve, reject) => {
      if (fs.existsSync(databasePath)) {
        storage = JSON.parse(fs.readFileSync(databasePath))

        resolve(storage)
      }
    })
  }
}
