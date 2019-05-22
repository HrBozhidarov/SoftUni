const fs = require('fs')
const path = require('path')
const Meme = require('./../models/meme')
const shortid = require('short-id')
const formidable = require('formidable')
const zlib = require('zlib')
const pictureFolder = path.normalize(path.join(__dirname, '../public/memeStorage'))

function viewAll (req, res) {
  let replacement = ''
  Meme.find({ privacy: 'on' }).then((data) => {
    data.sort((a, b) => a.dateStamp - b.dateStamp).forEach(item => {
      replacement += `<div class="meme">
                        <a href="/getDetails?id=${item.id}">
                        <img class="memePoster" src="${item.memeSrc}"/>          
                      </div>`
    })

    sendResponseFromGet(replacement, '../views/viewAll.html', res)
  })
}

function getDetails (req, res) {
  let id = req.query.id
  Meme.find({ _id: id })
    .then(currentMemes => {
      if (currentMemes.length === 0) {
        res.write('404 Not found!')
        res.end()
        return
      }

      let item = currentMemes[0]

      let replacement = `<div class="content">
      <img src="${item.memeSrc}" alt=""/>
      <h3>Title  ${item.title}</h3>
      <p> ${item.description}</p>
      <button><a href="${item.memeSrc}" download="${item.title}.png">Download Meme</a></button>
      </div>`

      sendResponseFromGet(replacement, '../views/details.html', res)
    })
}

function viewAddMeme (req, res) {
  sendResponseFromGet(undefined, '../views/addMeme.html', res)
}

function sendResponseFromGet (replacement, currentPath, res) {
  fs.readFile(path.normalize(path.join(__dirname, currentPath)), (err, data) => {
    if (err) {
      console.log(err)
      return
    }

    let result = data

    if (replacement) {
      result = data.toString().replace('<div id="replaceMe">{{replaceMe}}</div>', replacement)
    }

    res.writeHead(200, {
      'Content-Type': 'text/html',
      'Content-Encoding': 'gzip'
    })

    zlib.gzip(result, function (_, result) {
      res.end(result)
    })

    // res.write(result)
    // res.end()
  })
}

function findExistingFolderOrCreate (count, obj) {
  let currentPath = pictureFolder + `/${count}`

  if (!fs.existsSync(currentPath)) {
    fs.mkdirSync(currentPath)
  }

  let files = fs.readdirSync(currentPath)
  count++

  if (files.length > 1000) {
    findExistingFolderOrCreate(count, obj)
  } else {
    obj['path'] = currentPath
  }
}

function getPathPicture (count, obj) {
  return new Promise((resolve, reject) => {
    findExistingFolderOrCreate(count, obj)

    resolve(obj.path)
  })
}

function validateForm (description, title, res, files) {
  if (!description || !title) {
    res.write('Bad request')
    res.end()
    return true
  }

  if (!files.hasOwnProperty('meme') || files.meme.size === 0 || files.meme.type !== 'image/jpeg') {
    res.write('Bad request')
    res.end()
    return true
  }
}

function addMeme (req, res) {
  let form = new formidable.IncomingForm()

  form.parse(req, (err, fields, files) => {
    if (err) {
      console.log(err)
      return
    }

    let description = fields['memeDescription']
    let title = fields['memeTitle']

    if (validateForm(description, title, res, files)) { return }

    getPathPicture(0, {})
      .then(path => {
        let privacy = fields.hasOwnProperty('status') ? fields['status'] : 'off'
        let pictureName = shortid.generate()
        let newPicturePath = path + `/${pictureName}.jpg`
        let oldPicturePath = files.meme.path
        let memeSrc = `./public/memeStorage/${path[path.length - 1]}/${pictureName}.jpg`

        fs.renameSync(oldPicturePath, newPicturePath)

        let meme = {
          title: title,
          memeSrc: memeSrc,
          description: description,
          privacy: privacy
        }

        Meme.create(meme)
          .then((currentMeme) => {
            res.writeHead(302, { 'Location': '/' })
            res.end()
          })
      })
  })
}

module.exports = (req, res) => {
  if (req.pathname === '/viewAllMemes' && req.method === 'GET') {
    viewAll(req, res)
  } else if (req.pathname === '/addMeme' && req.method === 'GET') {
    viewAddMeme(req, res)
  } else if (req.pathname === '/addMeme' && req.method === 'POST') {
    addMeme(req, res)
  } else if (req.pathname.startsWith('/getDetails') && req.method === 'GET') {
    getDetails(req, res)
  } else {
    return true
  }
}
