const config = require('./config/config')
const db = require('./config/database.config')
const express = require('express')
const port = 3000

let environment = process.env.NODE_ENV || 'development'
let app = express()

db(config[environment])
require('./config/express')(app, config[environment])
require('./config/routes')(app)

app.listen(port, () => console.log(`Listening on port ${port}...`))
