(function solve() {
    Array.prototype.last = function () {
        return this[this.length - 1];
    };

    Array.prototype.skip = function (n) {
        let index = this.indexOf(n);

        if (index < 0) {
            return undefined;
        }

        let result = this.slice(index + 1);

        return result;
    };

    Array.prototype.take = function (n) {
        let result = [];

        for (let i = 0; i < n; i++) {
            result.push(this[i]);
        }

        return result;
    };

    Array.prototype.sum = function () {
        let sum = 0;

        for (let num of this) {
            sum += num;
        }

        return sum;
    };

    Array.prototype.average = function () {
         return this.sum()/this.length;
    }
})();

let arr = [1,2,3];

console.log(arr.skip(1)[2]);