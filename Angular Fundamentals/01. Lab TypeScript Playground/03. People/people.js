"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
exports.__esModule = true;
var Employ = /** @class */ (function () {
    function Employ(name, age) {
        this.name = name;
        this.age = age;
        this.salary = 0;
        this.tasks = [];
    }
    Employ.prototype.work = function () {
        var currentTask = this.tasks.shift();
        this.tasks.push(currentTask);
        console.log(this.name + currentTask);
    };
    Employ.prototype.collectSalary = function () {
        console.log(this.name + ("received " + this.getSelary() + " this month."));
    };
    Employ.prototype.getSelary = function () {
        return this.salary;
    };
    return Employ;
}());
var Junior = /** @class */ (function (_super) {
    __extends(Junior, _super);
    function Junior(name, age) {
        var _this = _super.call(this, name, age) || this;
        _this.tasks.push(name + " is working on the simple task.");
        return _this;
    }
    return Junior;
}(Employ));
exports.Junior = Junior;
var Senior = /** @class */ (function (_super) {
    __extends(Senior, _super);
    function Senior(name, age) {
        var _this = _super.call(this, name, age) || this;
        _this.tasks.push(name + " is working on a complicated task.");
        _this.tasks.push(name + " is taking time off work.");
        _this.tasks.push(name + " is supervising junior workers.");
        return _this;
    }
    return Senior;
}(Employ));
exports.Senior = Senior;
var Manager = /** @class */ (function (_super) {
    __extends(Manager, _super);
    function Manager(name, age) {
        var _this = _super.call(this, name, age) || this;
        _this.divident = 0;
        _this.tasks.push(name + " is working on a complicated task.");
        _this.tasks.push(name + " is taking time off work.");
        return _this;
    }
    Manager.prototype.getSelary = function () {
        return this.salary + this.divident;
    };
    return Manager;
}(Employ));
exports.Manager = Manager;
