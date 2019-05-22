const fs = require('fs')
const path = require('path')
const Tag = require('mongoose').model('Tag')
const Image = require('mongoose').model('Image')

function getImagesAndResponse (params, res, take, sortBy) {
  let result = ''
  Image.find(params)
    .sort(sortBy)
    .limit(take)
    .then((data) => {
      data.forEach(image => {
        result += `<fieldset id => <legend>${image.imageTitle}:</legend> 
        <img src="${image.imageUrl}">
        </img><p>${image.description}<p/>
        <button onclick='location.href="/delete?id=${image._id}"'class='deleteBtn'>Delete
        </button> 
        </fieldset>`
      })

      fs.readFile(path.normalize(path.join(__dirname, '../views/results.html')), (err, dataBuffer) => {
        if (err) {
          res.write('500 Internel server error!')
          res.end()
          return
        }

        let data = dataBuffer.toString().replace(`<div class='replaceMe'></div>`, result)

        res.write(data)
        res.end()
      })
    })
}

module.exports = (req, res) => {
  if (req.pathname === '/search') {
    let tagNames = req.pathquery['tagName'].trim()
    let afterDate = req.pathquery['afterDate']
    let beforDate = req.pathquery['beforeDate']
    let limit = req.pathquery['Limit'] ? Number(req.pathquery['Limit']) : 10
    let params = {}
    let ifInSearch = false

    if (tagNames) {
      ifInSearch = true
      let tags = tagNames.split(',')
      Tag.find({ tagName: { $in: tags } }, (err, tagsCollection) => {
        if (err) {
          res.write('404 Not found!')
          res.end()
          return
        }

        params.tags = tagsCollection.map(x => x._id)
        let sortBy = { creationDate: 'descending' }

        getImagesAndResponse(params, res, null, sortBy)
      })
    }

    if ((afterDate || beforDate) && !ifInSearch) {
      let checkDate = {}

      if (beforDate) {
        checkDate.$gte = new Date(beforDate)
      }

      if (afterDate) {
        checkDate.$lte = new Date(afterDate)
      }

      params.creationDate = checkDate

      getImagesAndResponse(params, res, limit, null)
    }

    if (!ifInSearch) {
      getImagesAndResponse(params, res, null, null)
    }
  } else {
    return true
  }
}
