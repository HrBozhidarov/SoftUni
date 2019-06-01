const mongoose = require('mongoose')
const Schema = mongoose.Schema

let CubeSchema = new Schema({
    name: { type: String, required: true },
    description: {type: String, required: true  },
    image: { type: String, required: true  },
    difficulty: { type: Number, required: true  }
})

CubeSchema.path('name')
    .validate(function () {
        return this.name.length >= 3 && this.name.length <= 15
    }, 'Name must be between 3 and 15 symbols!')

CubeSchema.path('description')
    .validate(function () {
        return this.description.length >= 20 && this.description.length <= 200
    }, 'Description must be between 20 and 300 symbols')

CubeSchema.path('image')
    .validate(function () {
        return this.image.startsWith('https://') && (this.image.endsWith('.jpg') || this.image.endsWith('.png'))
    }, "Image URL must start with https://' or 'Image URL must end with .jpg or .png")

CubeSchema.path('difficulty')
    .validate(function () {
        return this.difficulty >= 1 && this.difficulty <= 6
    }, 'difficulty have to be between 1 and 6')

let CubeModel = mongoose.model('Cube', CubeSchema)

module.exports = CubeModel