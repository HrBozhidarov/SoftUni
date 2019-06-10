const mongoose = require('mongoose')
const encrypt = require('./../utilities/encryption')
const propertyIsRequired = '{0} is required.'
const Schema = mongoose.Schema
const placeholderSymbol = '{0}'
const errorMessageForAge = 'Age must be between 0 and 120'
const ObjectId = Schema.Types.ObjectId

let userShcema = new Schema({
    username: {
        type: String,
        required: propertyIsRequired.replace(placeholderSymbol, 'Username'),
        unique: true
    },
    password: {
        type: String,
        required: propertyIsRequired.replace(placeholderSymbol, 'Password')
    },
    salt: {
        type: String,
        required: true
    },
    firstName: {
        type: String,
        required: propertyIsRequired.replace(placeholderSymbol, 'First name')
    },
    lastName: {
        type: String,
        required: propertyIsRequired.replace(placeholderSymbol, 'Last name')
    },
    age: {
        type: Number,
        min: [0, errorMessageForAge],
        max: [120, errorMessageForAge]
    },
    gender: {
        type: String,
        enum: {
            values: ['Male', 'Female'],
            message: 'Gender should be either "Male" or "Female".'
        }
    },
    roles: [{ type: String }],
    boughtProducts: [{ type: ObjectId, ref: 'Product' }],
    createProducts: [{ type: ObjectId, ref: 'Product' }],
    createCategories: [{ type: ObjectId, ref: 'Category' }]
});

userShcema.method({
    authenticate: function (password) {
        let hashedPassword = encrypt.generateHashPassword(this.salt, password)

        if (hashedPassword === this.password) {
            return true
        }

        return false
    }
})

const User = mongoose.model('User', userShcema)

module.exports = User

module.exports.seedAdminUser = () => {
    User.find({ username: 'admin' })
        .then(users => {
            if (users.length === 0) {
                let salt = encrypt.generateSalt()
                let hashedPassword = encrypt.generateHashPassword(salt, 'admin123')

                User.create({
                    username: 'admin',
                    firstName: 'H',
                    lastName: 'B',
                    salt: salt,
                    password: hashedPassword,
                    age: 27,
                    gender: 'Male',
                    roles: ['Admin']
                })
            }
        })
}