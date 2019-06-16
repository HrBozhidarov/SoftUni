const mongoose = require('mongoose');
const Schema = mongoose.Schema;
const carSchema = new Schema({
    model: {
        type: String,
        required: true
    },
    image: {
        type: String,
        required: true
    },
    pricePerDay: {
        type: String,
        required: true
    },
    isRented: {
        type: Boolean,
        required: true,
        default: false
    }
});

const Car = mongoose.model('Car', carSchema);

module.exports = Car;