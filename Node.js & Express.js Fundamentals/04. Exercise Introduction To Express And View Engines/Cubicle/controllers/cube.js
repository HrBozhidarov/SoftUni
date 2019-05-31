const Cube = require('./../models/Cube')

function vizualizeErrors (err, res) {
    let errors = []
    let allErrors = err.errors
    let keys = Object.keys(err.errors)
    for (const key of keys) {
        errors.push(`${key}: ${allErrors[key]}`)
    }
    
    res.locals.errors = errors.join('\n')

    res.render('create')
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
            vizualizeErrors(err, res)
        })
}