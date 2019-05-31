const handlers = require('./../controllers')

module.exports = app => {
    app.get('/', handlers.home.index)
    app.get('/about', handlers.home.about)
    
    app.get('/create', handlers.cube.createGet)
    app.post('/create', handlers.cube.createPost)
};