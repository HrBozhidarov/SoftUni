function solve() {
    let obj = {
        extend: function (template) {
            for (let key in template) {
                 if(typeof template[key] === 'function') {
                    Object.getPrototypeOf(this)[key] = template[key];
                 }
                 else {
                    this[key] = template[key];
                 }
            }
        }
    };

    return obj;
}

let obj = solve();
obj.extend({
    name: 'name',
    asd: function () {
        return 1;
    }
});

console.log(obj);