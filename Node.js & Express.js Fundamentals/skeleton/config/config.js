const path = require('path')

module.exports = {
    development: {
        port: process.env.port || 3000,
        connectionString: 'mongodb://localhost:27017/myapp',
        rootPath: path.normalize(path.join(__dirname, '../'))
    },
    production: {}
}