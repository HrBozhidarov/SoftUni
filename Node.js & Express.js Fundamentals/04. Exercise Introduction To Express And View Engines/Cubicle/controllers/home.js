const Cube = require('./../models/Cube')

module.exports.index = (req, res) => {
    Cube.find()
        .then(cubes => {
            res.render('index', { cubes: cubes })
        })
}

module.exports.about = (req, res) => {
    res.render('about')
}