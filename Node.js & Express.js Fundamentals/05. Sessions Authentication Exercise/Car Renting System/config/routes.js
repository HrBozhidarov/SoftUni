const restrictedPages = require('./auth');
const homeController = require('../controllers/home');
const userController = require('../controllers/user');
const carController = require('../controllers/car');
const rentController = require('../controllers/rent');

module.exports = app => {
    app.get('/', homeController.index);
    app.get('/user/register', userController.registerGet);
    app.get('/user/login', userController.loginGet);
    app.get('/car/all', restrictedPages.isAuthed, carController.allGet);
    app.get('/search', carController.search);
    app.get('/car/add', restrictedPages.hasRole('Admin'), carController.addGet);
    app.get('/car/rent/:id', restrictedPages.isAuthed, rentController.rentGet);
    app.get('/user/rents', restrictedPages.isAuthed, rentController.historyRentGet);
    app.get('/car/edit/:id', restrictedPages.hasRole('Admin'), carController.eidtGet);

    app.post('/user/logout', userController.logout);
    app.post('/user/register', userController.registerPost);
    app.post('/user/login', userController.loginPost);
    app.post('/car/add', restrictedPages.hasRole('Admin'), carController.addPost);
    app.post('/car/rent/:id', restrictedPages.isAuthed, rentController.rentPost);
    app.post('/car/edit/:id', restrictedPages.hasRole('Admin'), carController.editPost);

    app.all('*', (req, res) => {
        res.status(404);
        res.send('404 Not Found');
        res.end();
    });
};