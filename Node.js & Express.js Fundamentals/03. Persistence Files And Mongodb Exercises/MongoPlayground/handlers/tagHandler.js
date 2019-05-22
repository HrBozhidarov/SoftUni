const formidable = require('formidable')
const Tag = require('mongoose').model('Tag')

module.exports = (req, res) => {
  if (req.pathname === '/generateTag' && req.method === 'POST') {
    let form = new formidable.IncomingForm()

    form.parse(req, (err, fields, files) => {
      if (err) {
        res.write('500 Internel server error!')
        res.end()
        return
      }

      let model = {
        tagName: fields.tagName
      }

      Tag.create(model).then((tag, err) => {
        res.writeHead(302, { 'Location': '/' })
        res.end()
      })
    })
  } else {
    return true
  }
}
