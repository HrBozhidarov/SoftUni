let storage = require('./storage')

storage.loadSync()
storage.put('first', 'firstValue')
storage.put('second', 'secondValue')
storage.put('third', 'thirdValue')
storage.put('fouth', 'fourthValue')
console.log(storage.get('first'))
console.log(storage.getAll())
storage.delete('second')
storage.update('first', 'updatedFirst')
storage.saveSync()
storage.clear()
console.log(storage.getAll())
storage.loadSync()
console.log(storage.getAll())
// storage.loadAsync().then(function (data) {
//   console.log(data)
// })
// console.log('first')
