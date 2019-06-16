const Car = require('../models/Car');
const Rent = require('../models/Rent');
const User = require('../models/User');
const mongoose = require('mongoose');

module.exports = {
    rentGet: (req, res) => {
        let id = req.params.id;

        Car.findById(id)
            .then(car => {
                if (car.isRented) {
                    res.redirect('/car/all');
                    return;
                };

                let carObj = {
                    model: car.model,
                    image: car.image,
                    _id: car._id
                };

                res.render('car/rent', carObj);
            }).catch(err => {
                console.log(err);
            })
    },
    rentPost: (req, res) => {
        let body = req.body;
        let days = Number(body.days);

        // check if car id is valid...

        if (days < 1) {
            res.redirect('/car/all');
            return;
        }

        let carId = mongoose.Types.ObjectId(req.params.id);

        Car.findById(carId)
            .then(car => {
                if (car.isRented) {
                    res.redirect('/car/all');
                    return;
                }

                car.isRented = true;

                car.save()
                    .then(currentCar => {
                        let rentCar = {
                            days: days,
                            car: carId,
                            owner: mongoose.Types.ObjectId(req.user.id)
                        }
                
                        Rent.create(rentCar).then(takenCar => {
                            res.redirect('/');
                        }).catch(err => {
                            console.log(err);
                        })
                    }).catch(err => {
                        console.log(err);
                    })
            })  
    },
    historyRentGet: (req, res) => {
        let userId = req.user.id;

        Rent.find({ owner: userId })
            .populate('car')
            .then(cars => {
                let rentCars = [];
                cars.forEach(element => {
                    rentCars.push({
                        car: {
                        model: element.car.model,
                        pricePerDay: element.car.pricePerDay,
                        expiresOn: element.days
                    }
                    });
                });

                res.render('user/rented',{ cars: rentCars });
            }).catch(err => {
                console.log(err);
            })
    }
}