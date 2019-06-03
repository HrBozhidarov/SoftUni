const bodyParser = require('body-parser');
const handlebars = require('express-handlebars');
const express = require('express');
const path = require('path');

module.exports = (app, config) => {
    app.engine('.hbs', handlebars({extname: '.hbs'}));
    app.set('view engine', '.hbs');
    app.use(bodyParser.urlencoded({ extended: true }));
    app.use(express.static(path.normalize(path.join(config.rootPath, 'public'))));
}