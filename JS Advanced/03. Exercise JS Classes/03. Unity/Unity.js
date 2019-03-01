class Rat {
    constructor(name) {
        this.name = name;
        this.rates = [];
    }

    getRats() {
        return this.rates;
    }

    toString() {
        let result = [];
        result.push(this.name);

        this.rates.forEach(rate => {
            result.push('##' + rate.name);
        });

        return result.join('\n');
    }

    unite(otherRat) {
        if(!(otherRat instanceof Rat)) {
            return;
        }

        this.rates.push(otherRat);
    }
}

let test = new Rat("Pesho");
console.log(test.toString()); //Pesho

console.log(test.getRats()); //[]

test.unite(new Rat("Gosho"));
test.unite(new Rat("Sasho"));
console.log(test.getRats());
//[ Rat { name: 'Gosho', unitedRats: [] },
//  Rat { name: 'Sasho', unitedRats: [] } ]

console.log(test.toString());
// Pesho
// ##Gosho
// ##Sasho
