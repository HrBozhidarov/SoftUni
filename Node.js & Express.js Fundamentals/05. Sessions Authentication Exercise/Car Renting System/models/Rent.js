const mongoose = require('mongoose');
const Schema = mongoose.Schema;
const rentSchema = new Schema({
    days: {
        type: Number,
        required: true
    },
    car: {
        required: true,
        type: mongoose.Schema.Types.ObjectId,
        ref: 'Car'
    },
    owner: {
        required: true,
        type: mongoose.Schema.Types.ObjectId,
        ref: 'User'
    }
})

const Rent = mongoose.model('Rent', rentSchema);

module.exports = Rent;