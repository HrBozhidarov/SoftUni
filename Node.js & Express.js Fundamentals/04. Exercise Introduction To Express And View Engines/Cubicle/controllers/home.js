const Cube = require('./../models/Cube')

function vizualizeErrors (err, res, cubes) { 
    res.locals.errors = err
    res.render('index', { cubes: cubes })
}

module.exports.index = (req, res) => {
   let query = req.query
    let search = query.search
    let from = query.from
    let to = query.to
    
    Cube.find()
        .then(cubes => {
            let tempCubes = cubes

            if (search) {
                tempCubes = tempCubes
                    .filter(x => x.name.toLowerCase().includes(search.toLowerCase()))
            }     
            
            if (from) {
                let numFrom = Number(from)

                if (numFrom <= 0 || numFrom >= 7) {
                    vizualizeErrors("From have to be between 1 and 6 iclusive!", res, cubes)

                    return
                }

                tempCubes = tempCubes.filter(x => x.difficulty >= numFrom)
            }

            if (to) {
                let numTo = Number(to)

                if (numTo <= 0 || numTo >= 7) {
                    vizualizeErrors("To have to be between 1 and 6 iclusive!", res, cubes)

                    return
                }

                tempCubes = tempCubes.filter(x => x.difficulty <= numTo)
            }

            res.render('index', { cubes: tempCubes })
        })
}

module.exports.about = (req, res) => {
    res.render('about')
}