const env = process.env.NODE_ENV || 'development';
const app = require('express')();
const config = require('./config/config')[env];

require('./config/database.config')(config);  
require('./config/express')(app, config);
require('./config/routes')(app);

app.listen(config.port, () => console.log(`Listening on port ${config.port}...`));