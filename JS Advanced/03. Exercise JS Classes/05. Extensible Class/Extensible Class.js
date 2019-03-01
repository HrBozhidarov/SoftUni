let Extensible = (function () {
    let id = 0;

    class Extensible {
        constructor() {
            this.id = id;
            id++;
        }

        extend(template) {
            for (let parentProp in template) {
                if (typeof (template[parentProp]) == "function") {
                    Object.getPrototypeOf(this)[parentProp] = template[parentProp];
                }
                else {
                    this[parentProp] = template[parentProp];
                }
            }
        }
    }

    return Extensible;
})();

let obj1 = new Extensible();
let obj2 = new Extensible();
let obj3 = new Extensible();

console.log(obj1.name)
console.log(obj1.id);
console.log(obj2.id);
console.log(obj3.id);