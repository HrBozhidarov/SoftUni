module.exports = {
    index: (req, res) => {
        let object = {
            isAdmin : res.locals.isAdmin,
            user: res.locals.user
        }
        res.render('home/index', object);
    }
};