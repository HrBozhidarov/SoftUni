handlers.getAllPets = function (ctx) {
    ctx.isAuth = userService.isAuth();
    ctx.username = sessionStorage.getItem('username');
    if (!ctx.isAuth) {
        ctx.redirect('#/login');
    }
    petService.getAllPets()
        .then(function (res) {
            ctx.pets = res;
            ctx.loadPartials({
                header: '../templates/common/header.hbs',
                footer: '../templates/common/footer.hbs'
            }).then(function () {
                this.partial('../../templates/dashboard.hbs');
            }).catch(function (err) {
                console.log(err);
            });
        });
}

handlers.filterPets = function (ctx) {
    ctx.isAuth = userService.isAuth();
    ctx.username = sessionStorage.getItem('username');
    if (!ctx.isAuth) {
        ctx.redirect('#/login');
    }

    let filter = '';

    switch (ctx.path) {
        case '/#/cats': filter = 'cat'; break;
        case '/#/dogs': filter = 'dog'; break;
        case '/#/parrots': filter = 'parrot'; break;
        case '/#/reptiles': filter = 'reptile'; break;
        case '/#/other': filter = 'other'; break;
    }

    petService.getAllPets()
        .then(function (res) {
            res = res.filter(x => x.category.toLowerCase() === filter.toLowerCase());
            ctx.pets = res;
            ctx.loadPartials({
                header: '../templates/common/header.hbs',
                footer: '../templates/common/footer.hbs'
            }).then(function () {
                this.partial('../../templates/dashboard.hbs');
            }).catch(function (err) {
                console.log(err);
            });
        });
}

handlers.addPet = function (ctx) {
    ctx.isAuth = userService.isAuth();
    ctx.username = sessionStorage.getItem('username');
    if (!ctx.isAuth) {
        ctx.redirect('#/login');
    }

    ctx.loadPartials({
        header: '../templates/common/header.hbs',
        footer: '../templates/common/footer.hbs'
    }).then(function () {
        this.partial('../../templates/addPet.hbs');
    }).catch(function (err) {
        console.log(err);
    });
}

handlers.createPet = function (ctx) {
    var data = { ...ctx.params,likes: 0 };

    petService.postPet(data)
        .then(function (result) {
            notify.showInfo('Pet created.');
            ctx.redirect('#/home');
        }).catch(function (err) {
            console.log(err);
        });
}

handlers.myPets = function (ctx) {
    ctx.isAuth = userService.isAuth();
    ctx.username = sessionStorage.getItem('username');
    if (!ctx.isAuth) {
        ctx.redirect('#/login');
    }
    petService.getAllPets()
        .then(function (res) {
            res = res.filter(x => x._acl.creator == sessionStorage.getItem('creator'));
            ctx.pets = res;

            ctx.loadPartials({
                header: '../templates/common/header.hbs',
                footer: '../templates/common/footer.hbs'
            }).then(function () {
                this.partial('../../templates/myPets.hbs');
            })

        }).catch(function (err) {
            console.log(err);
        });
}

handlers.getDelete = function (ctx) {
    ctx.isAuth = userService.isAuth();
    ctx.username = sessionStorage.getItem('username');

    if (!ctx.isAuth) {
        ctx.redirect('#/login');
    }

    petService.getAllPets()
        .then(function (res) {
            let result = {...res.find(x => x._id === ctx.params.id)};

            ctx.details = result;

            ctx.loadPartials({
                header: '../templates/common/header.hbs',
                footer: '../templates/common/footer.hbs'
            }).then(function () {
                this.partial('../../templates/deletePet.hbs');
            })
        });
}

handlers.delete=function(ctx) {
    ctx.isAuth = userService.isAuth();
    ctx.username = sessionStorage.getItem('username');

    if (!ctx.isAuth) {
        ctx.redirect('#/login');
    }

    petService.removePet(ctx.params._id)
    .then(function(res) {
        notify.showInfo("Pet removed successfully!");
        ctx.redirect('#/home');
    }).catch(function(err) {
        console.log(err);
    });
}

//increase