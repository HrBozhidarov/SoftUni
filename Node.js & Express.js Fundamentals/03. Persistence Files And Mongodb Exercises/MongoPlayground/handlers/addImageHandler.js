// const fs = require('fs')
// const Image = require('./../models/ImageSchema')
const Image = require('mongoose').model('Image')
const ObjectId = require('mongoose').Types.ObjectId
const formidable = require('formidable')

function addImage (req, res) {
  let form = new formidable.IncomingForm()

  form.parse(req, (err, fields, files) => {
    if (err) {
      res.write('500 Internel server error!')
      res.end()

      return
    }

    const tags = fields.tagsID.split(',').reduce((p, c, i, a) => {
      if (p.includes(c) || c.length === 0) {
        return p
      } else {
        p.push(c)
        return p
      }
    }, []).map(ObjectId)

    let imageModel = {
      imageUrl: fields.imageUrl,
      imageTitle: fields.imageTitle,
      description: fields.description,
      tags: tags
    }

    Image.create(imageModel).then((model) => {
      res.writeHead(302, { 'Location': '/' })
      res.end()
    }).catch(() => {
      res.write('500 Internel server error!')
      res.end()
    })
  })
}

function deleteImg (req, res) {
  let query = req.pathquery
  let imgId = query.id

  Image.find({ _id: imgId }, (err, currentImg) => {
    if (err) {
      res.write('404 Not found!')
      res.end()

      return
    }

    Image.deleteOne({ _id: imgId }, (err, deletedImg) => {
      if (err) {
        res.write('500 Internel error!')
        res.end()

        return
      }
      res.writeHead(302, { 'Location': '/' })
      res.end()
    })
  })
}

module.exports = (req, res) => {
  if (req.pathname === '/addImage' && req.method === 'POST') {
    addImage(req, res)
  } else if (req.pathname === '/delete' && req.method === 'GET') {
    deleteImg(req, res)
  } else {
    return true
  }
}
