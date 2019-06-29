var Box = /** @class */ (function () {
    function Box() {
        this.boxs = [];
    }
    Box.prototype.add = function (element) {
        this.boxs.push(element);
    };
    Box.prototype.remove = function () {
        this.boxs.pop();
    };
    Object.defineProperty(Box.prototype, "count", {
        get: function () {
            return this.boxs.length;
        },
        enumerable: true,
        configurable: true
    });
    return Box;
}());
var box = new Box();
box.add("Pesho");
box.add("Gosho");
console.log(box.count);
box.remove();
console.log(box.count);
