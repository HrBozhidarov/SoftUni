let solution1 = function solve() {
    let storage = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    };
    return function (input) {
        let inputSplit = input.split(' ');
        let command = inputSplit[0];
        let micorElementNotEnough;
        let microElements = {
            protein: 0,
            carbohydrate: 0,
            fat: 0,
            flavour: 0
        };

        if (command === 'restock') {
            let element = inputSplit[1];
            let quantity = Number(inputSplit[2]);

            storage[element] += quantity;

            return 'Success';
        }
        else if (command === 'prepare') {
            let recipe = inputSplit[1];
            let quantity = Number(inputSplit[2]);

            fufillMicroElementsObject(recipe, quantity);

            if (enoughResources()) {
                removeResoursesFromStorage();

                return 'Success';
            }
            else {
                return `Error: not enough ${micorElementNotEnough} in stock`;
            }
        }
        else {
            return `protein=${storage.protein} carbohydrate=${storage.carbohydrate} fat=${storage.fat} flavour=${storage.flavour}`;
        }

        function fufillMicroElementsObject(recipe, quantity) {
            switch (recipe) {
                case 'apple':
                    microElements.carbohydrate = 1 * quantity;
                    microElements.flavour = 2 * quantity;
                    break;
                case 'coke':
                    microElements.carbohydrate = 10 * quantity;
                    microElements.flavour = 20 * quantity;
                    break;
                case 'burger':
                    microElements.carbohydrate = 5 * quantity;
                    microElements.fat = 7 * quantity;
                    microElements.flavour = 3 * quantity;
                    break;
                case 'omelet':
                    microElements.protein = 5 * quantity;
                    microElements.fat = 1 * quantity;
                    microElements.flavour = 1 * quantity;
                    break;
                case 'cheverme':
                    microElements.carbohydrate = 10 * quantity;
                    microElements.flavour = 10 * quantity;
                    microElements.fat = 10 * quantity;
                    microElements.protein = 10 * quantity;
                    break;
            }
        }

        function enoughResources() {
            for (let me in storage) {
                if (storage[me] < microElements[me]) {
                    micorElementNotEnough = me;
                    return false;
                }
            }

            return true;
        }

        function removeResoursesFromStorage() {
            for (let me in storage) {
                storage[me] -= microElements[me];
            }
        }
    };
};

let solution = solution1();

console.log(solution('restock protein 100'));
console.log(solution('restock carbohydrate 100'));
console.log(solution('restock fat 100'));
console.log(solution('restock flavour 100'));

console.log(solution('prepare omelet 2'));
console.log(solution('prepare omelet 1'));
console.log(solution('report'));
