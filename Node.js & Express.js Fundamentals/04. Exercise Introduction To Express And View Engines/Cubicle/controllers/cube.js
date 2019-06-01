const Cube = require('./../models/Cube')

function vizualizeErrors (err, res, cube) {
    let errors = []
    let allErrors = err.errors
    let keys = Object.keys(err.errors)
    
    for (const key of keys) {
        errors.push(`${key}: ${allErrors[key]}`)
    }
    
    res.locals.errors = errors.join('\n')
    res.render('create', cube)
}

module.exports.detailsGet = (req, res) => {
    let params = req.params
    let id = params.id

    Cube.findById(id)
        .exec((err, cube) => {
            if (err) {
                res.redirect('/')
            }

            res.render('details', cube)
        })
}

module.exports.createGet = (req, res) => {
    res.render('create')
}

module.exports.createPost = (req, res) => {
    let body = req.body
    let cube = {
        name: body.name,
        description: body.description,
        image: body.image,
        difficulty: body.difficulty
    }

    Cube.create(cube)
        .then((newCub) => {
            res.redirect('/')
        })
        .catch((err) => {
            vizualizeErrors(err, res, cube)
        })
}