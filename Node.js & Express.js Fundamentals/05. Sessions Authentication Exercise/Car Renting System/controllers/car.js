const Car = require('../models/Car');

module.exports = {
    addGet: (req, res) => {
        res.render('car/add');
    },
    addPost: (req, res) => {
        let body = req.body;

        let car = {
            model: body.model,
            image: body.image,
            pricePerDay: +body.pricePerDay
        }

        Car.create(car)
            .then(saveCar => {
                res.redirect('/car/all');
            })
            .catch(err => {
                car.error = err.message;
                res.render('car/add', car)
            })
    },
    allGet: (req, res) => {
        Car.find({ isRented: false })
            .then(cars => {
                res.render('car/all', { cars: cars });
            })
            .catch(err => {
                console.log(err);
            })
    },
    search: (req, res) => {
        let model = req.query.model;

        Car.find()
            .then(cars => {
                res.render('car/all', { cars: cars.filter(x => x.model.toLowerCase().includes(model.toLowerCase())) })
            });
    },
    eidtGet: (req, res) => {
        let carId = req.params.id;

        Car.findById(carId)
            .then(currentCar => {
                let car = {
                    id: currentCar._id.toString(),
                    model: currentCar.model,
                    image: currentCar.image,
                    pricePerDay: +currentCar.pricePerDay
                }

                res.render('car/edit', car);
            }).catch(err => {
                console.log(err);
            })
    },
    editPost: (req, res) => {
        let body = req.body;

        Car.findById(body.id)
            .then(car => {
                car.model = body.model;
                car.image = body.image;
                car.pricePerDay = body.pricePerDay;

                car.save()
                    .then(car => {
                        res.redirect('/car/all');
                    }).catch(err => {
                        console.log(err);
                    })
            })
    }
}