const encryption = require('../util/encryption');
const User = require('mongoose').model('User');

module.exports = {
    registerGet: (req, res) => {
        res.render('user/register');
    },
    registerPost: async (req, res) => {
        let reqUser = req.body;

        if (!reqUser.password || !reqUser.repeatPassword) {
            reqUser.error = 'Psswords fields have to be fuffiled!'
            res.render('user/register', reqUser);
            
            return;
        }

       if (reqUser.password !== reqUser.repeatPassword) {
            reqUser.error = 'Passwords don`t match!';
            res.render('user/register', reqUser);

            return;
       }

       let existsUser = await User.findOne({ username: reqUser.username });

       if (existsUser) {
            reqUser.error = 'Username is already taken!'
            res.render('user/register', reqUser);

            return;
       }

       let salt = encryption.generateSalt();
       let hashedPass = encryption.generateHashedPassword(salt, reqUser.password);

       try {
        let newUser = await User.create({
            username: reqUser.username,
            hashedPass: hashedPass,
            salt: salt,
            firstName: reqUser.firstName,
            lastName: reqUser.lastName,
            roles: ['User']
        });

        req.logIn(newUser, function(err) {
            if (err) { 
                reqUser.error = err;
                res.render('user/register', reqUser);

                return;
            }

            res.redirect('/');
          });
        
       } catch(err) {
           reqUser.error = err;
           res.render('user/register', reqUser);
       }
    },
    logout: (req, res) => {
        req.logout();
        res.redirect('/');
    },
    loginGet: (req, res) => {
        if (req.user) {
            res.redirect('/');
        }

        res.render('user/login');
    },
    loginPost: async (req, res) => {
        if (req.user) {
            res.redirect('/');
        }

        let reqUser = req.body;
        let user = await User.findOne({ username: reqUser.username });
        if (!user) {
            reqUser.error = 'Invalid attempt!';
            res.render('user/register', reqUser);

            return;
        }

        let userSalt = user.salt;
        let userHashedPassword = user.hashedPass;
        let reqUserHashedPassword = encryption.generateHashedPassword(userSalt, reqUser.password);

        if (userHashedPassword !== reqUserHashedPassword) {
            reqUser.error = 'Invalid attempt!';
            res.render('user/register', reqUser);

            return;
        }

        try {
            req.logIn(user, function(err) {
                if (err) { 
                    reqUser.error = err;
                    res.render('user/register', reqUser);
    
                    return;
                }
    
                res.redirect('/');
              });
            
           } catch(err) {
               reqUser.error = err;
               res.render('user/login', reqUser);
           }
    }
};