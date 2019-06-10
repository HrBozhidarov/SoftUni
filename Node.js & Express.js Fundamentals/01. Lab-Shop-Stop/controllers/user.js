const User = require('mongoose').model('User')
const encrypt = require('./../utilities/encryption')

module.exports.loginGet = (req, res) => {
    res.render('users/login');
}

module.exports.logout = (req, res) => {
    req.logout()
    res.redirect('/')
}

module.exports.loginPost = (req, res) => {
    let userToLogin = req.body

    User.findOne({ username: userToLogin.username })
        .then(user => {
            if(!user || !user.authenticate(userToLogin.password)) {
                res.render('users/login', { error: 'Invalid credentials!' })
            } else {
                req.logIn(user, (error, user) => {
                    if(error) {
                        res.render('users/register', {error: 'Authentication not working!'})
        
                        return
                    }
                    
                    res.redirect('/')
                })
            }
        })
}

module.exports.registerGet = (req, res) => {
    res.render('users/register')
}

module.exports.registerPost = (req, res) => {
    let user = req.body
    
    if (user.password && user.password != user.confirmedPassword) {
        let error = 'Password do not match.'
        res.render('users/register', {
            error: error
        })

        return
    }

    let salt = encrypt.generateSalt()
    user.salt = salt

    if (user.password) {
        let hashPassword = encrypt.generateHashPassword(salt, user.password)
        user.password = hashPassword
    }

    User.create(user).then(user => {
        req.logIn(user, (error, user) => {
            if(error) {
                res.render('user/register', {error: 'Authentication not working!'})

                return
            }
            
            res.redirect('/')
        })
    }).catch(error => {
            res.render('users/register', {
                user: user,
                error: error.errors.username
            })
        })
}