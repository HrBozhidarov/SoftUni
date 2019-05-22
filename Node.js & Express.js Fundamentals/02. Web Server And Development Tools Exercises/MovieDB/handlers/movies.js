const fs = require('fs')
const path = require('path')
const db = require('../config/dataBase')
const placeholder = '<div id="replaceMe">{{replaceMe}}</div>'

function getRequest (res, pathHtml, placeholderReplace) {
  fs.readFile(path.join(__dirname, pathHtml), (err, data) => {
    if (!err) {
      data = data.toString().replace(placeholder, placeholderReplace)
      res.writeHead(200, { 'Content-Type': 'text/html' })
      res.write(data)
      res.end()

      return
    }

    return true
  })
}

module.exports = (req, res) => {
  let pathName = req.url.pathname

  if (pathName === '/viewAllMovies' && req.method === 'GET') {
    let movies = []

    db.forEach((x, i) => {
      let currentElementPlaceholder = `<div class="movie">
                                         <a href = "movies/details/${i + 1}">
                                           <img class="moviePoster" src="{{url}}"/>
                                         </a>          
                                       </div>`

      movies.push(currentElementPlaceholder.replace('{{url}}', decodeURIComponent(x.moviePoster)))
    })

    return getRequest(res, '../views/viewAll.html', movies.join(''))
  } else if (req.method === 'GET' && req.url.pathname === '/addMovie') {
    fs.readFile(path.join(__dirname, '../views/addMovie.html'), (err, data) => {
      if (!err) {
        res.writeHead(200, { 'Content-Type': 'text/html' })
        res.write(data)
        res.end()

        return
      }

      return true
    })
  } else if (req.method === 'GET' && req.url.pathname.startsWith('/movies/details/')) {
    let startIndex = req.url.pathname.lastIndexOf('/')
    let index = Number(req.url.pathname.substr(startIndex + 1))
    let movie = db[index - 1]
    let moviePlaceHolder = `<div class="content">
                              <img src="${decodeURIComponent(movie.moviePoster)}" alt=""/>
                              <h3>Title  ${decodeURIComponent(movie.movieTitle).replace(/\+/g, ' ')}</h3>
                              <h3>Year ${decodeURIComponent(movie.movieYear)}</h3>
                              <p> ${decodeURIComponent(movie.movieDescription).replace(/\+/g, ' ')}</p>
                            </div>`
    return getRequest(res, '../views/details.html', moviePlaceHolder)
  } else if (req.method === 'POST' && req.url.pathname === '/addMovie') {
    let bodyParse = req.bodyData
    if (!bodyParse.moviePoster) {
      let errPlaceholder = '<div id="errBox"><h2 id="errMsg">Please fill all fields</h2></div>'
      return getRequest(res, '../views/addMovie.html', errPlaceholder)
    }
    db.push(bodyParse)
    let successPlaceholder = '<div id="succssesBox"><h2 id="succssesMsg">Movie Added</h2></div>'
    return getRequest(res, '../views/addMovie.html', successPlaceholder)
  } else {
    return true
  }
}
