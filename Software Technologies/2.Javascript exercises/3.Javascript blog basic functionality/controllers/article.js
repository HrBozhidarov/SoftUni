const Article = require('../models').Article;
const User=require('../models').User;
module.exports = {
    createGet: (req, res) => {
        res.render('article/create')
    },
    createPost: (req, res) => {
        let articleArgs = req.body;
        console.log(articleArgs);
        let errorMessage = '';

        if (!req.isAuthenticated()) {
            errorMessage = 'You should be logged to make articles!';
        } else if (!articleArgs.title) {
            errorMessage = 'Invalid title!';
        } else if (!articleArgs.content) {
            errorMessage = 'Invalid content!';
        }

        if (errorMessage) {
            res.render('article/create', {error: errorMessage});
            return;
        }

        articleArgs.authorId = req.user.id;

        Article.create(articleArgs).then(article => {
            res.redirect('/');
        }).catch(err => {
            console.log(err.message);
            res.render('article/create', {err: err.message})
        })
    },
    details: (req, res) => {
        let id = req.params.id;

        Article.findById(id, {include: [{model: User}]})
            .then(article => {
                res.render('article/details',article.dataValues)
            })
    }
};