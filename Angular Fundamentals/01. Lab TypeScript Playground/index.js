var User = /** @class */ (function () {
    function User(name) {
        this.name = name;
    }
    User.prototype.sayHello = function () {
        return this.name + " say hi!";
    };
    return User;
}());
var user = new User("ico");
console.log(user.sayHello());
