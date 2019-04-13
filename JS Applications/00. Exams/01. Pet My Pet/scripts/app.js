const handlers = {}

$(() => {
  const app = Sammy('#container', function () {
    this.use('Handlebars', 'hbs');
    // home page routes
    this.get('/index.html', handlers.getHome);
    this.get('/', handlers.getHome);
    this.get('#/home', handlers.getHome);

    // user routes
    this.get('#/register', handlers.getRegister);
    this.get('#/login', handlers.getLogin);
    this.get('#/logout', handlers.logoutUser);
    
    this.post('#/register', handlers.registerUser);
    this.post('#/login', handlers.loginUser);

    // ADD YOUR ROUTES HERE
    this.get('#/dashboard',handlers.getAllPets);
    this.get('#/all',handlers.getAllPets);
    this.get('#/cats',handlers.filterPets);
    this.get('#/dogs',handlers.filterPets);
    this.get('#/parrots',handlers.filterPets);
    this.get('#/reptiles',handlers.filterPets);
    this.get('#/other',handlers.filterPets);
    this.get('#/increasePet/:id',handlers.icreasePet);
    this.get('#/addPet',handlers.addPet);
    this.get('#/myPets',handlers.myPets);
    this.get('#/delete/:id',handlers.getDelete);
    this.get('#/details/:id',handlers.details);

    this.post('#/delete/:_id',handlers.delete);
    this.post('#/createPet',handlers.createPet);
  });
  
  app.run();
});