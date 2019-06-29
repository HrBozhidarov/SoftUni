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
var Melon = /** @class */ (function () {
    function Melon(weigth, melonSort) {
        this.weigth = weigth;
        this.melonSort = melonSort;
    }
    Object.defineProperty(Melon.prototype, "elementIndex", {
        get: function () {
            return this.weigth * this.melonSort.length;
        },
        enumerable: true,
        configurable: true
    });
    Melon.prototype.toString = function () {
        return "Element: " + this.element + "\n" +
            ("Sort: " + this.melonSort + "\n") +
            ("Element Index: " + this.elementIndex);
    };
    return Melon;
}());
var Watermelon = /** @class */ (function (_super) {
    __extends(Watermelon, _super);
    function Watermelon(weigth, melonSort) {
        var _this = _super.call(this, weigth, melonSort) || this;
        _this.element = 'Watermelon';
        return _this;
    }
    return Watermelon;
}(Melon));
var Firemelon = /** @class */ (function (_super) {
    __extends(Firemelon, _super);
    function Firemelon(weigth, melonSort) {
        var _this = _super.call(this, weigth, melonSort) || this;
        _this.element = 'Firemelon';
        return _this;
    }
    return Firemelon;
}(Melon));
var Earthmelon = /** @class */ (function (_super) {
    __extends(Earthmelon, _super);
    function Earthmelon(weigth, melonSort) {
        var _this = _super.call(this, weigth, melonSort) || this;
        _this.element = 'Earthmelon';
        return _this;
    }
    return Earthmelon;
}(Melon));
var Airmelon = /** @class */ (function (_super) {
    __extends(Airmelon, _super);
    function Airmelon(weigth, melonSort) {
        var _this = _super.call(this, weigth, melonSort) || this;
        _this.element = 'Airmelon';
        return _this;
    }
    return Airmelon;
}(Melon));
var Melolemonmelon = /** @class */ (function () {
    function Melolemonmelon(weigth, melonSort) {
        this.melon = new Watermelon(weigth, melonSort);
        this.melons = [];
        this.melons.push(new Watermelon(weigth, melonSort));
        this.melons.push(new Firemelon(weigth, melonSort));
        this.melons.push(new Earthmelon(weigth, melonSort));
        this.melons.push(new Airmelon(weigth, melonSort));
        this.index = 0;
    }
    Melolemonmelon.prototype.morph = function () {
        this.index++;
        if (this.index === this.melons.length) {
            this.index = 0;
        }
        this.melon = this.melons[this.index];
        return this.melon;
    };
    Melolemonmelon.prototype.toString = function () {
        return this.melon.toString();
    };
    return Melolemonmelon;
}());
var melon = new Melolemonmelon(23, 'cato');
console.log(melon.toString());
melon.morph();
console.log(melon.toString());
melon.morph();
console.log(melon.toString());
melon.morph();
console.log(melon.toString());
