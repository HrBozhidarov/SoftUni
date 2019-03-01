class Kitchen {
    constructor(budget) {
        this.budget = budget;
        this.menu = {};
        this.productsInStock = {};
        this.actionsHistory = [];
    }

    loadProducts(products) {
        products.forEach(line => {
            let splitLine = line.split(' ');
            let productName = splitLine[0];
            let productQuantity = Number(splitLine[1]);
            let productPrice = Number(splitLine[2]);

            if (this.budget >= productPrice) {
                if (this.productsInStock.hasOwnProperty(productName)) {
                    this.productsInStock[productName] += productQuantity;
                }
                else {
                    this.productsInStock[productName] = productQuantity;
                }

                this.actionsHistory.push(`Successfully loaded ${productQuantity} ${productName}`);
                this.budget -= productPrice;
            }
            else {
                this.actionsHistory.push(`There was not enough money to load ${productQuantity} ${productName}`);
            }
        });

        return this.actionsHistory.join('\n');
    }

    addToMenu(meal, products, price) {
        if (!this.menu.hasOwnProperty(meal)) {
            this.menu[meal] = {
                products: products,
                price: price
            }

            let numberOfMealsInMenu = Object.keys(this.menu).length;

            return `Great idea! Now with the ${meal} we have ${numberOfMealsInMenu} meals in the menu, other ideas?`;
        }

        return `The ${meal} is already in our menu, try something different.`;
    }

    showTheMenu() {
        let result = '';

        if (Object.keys(this.menu).length > 0) {
            for (const key in this.menu) {
                result += `${key} - $ ${this.menu[key].price}\n`;
            }

            return result;
        }

        return 'Our menu is not ready yet, please come later...';
    }

    makeTheOrder(meal) {
        if (!this.menu.hasOwnProperty(meal)) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`;
        }

        for (const element of this.menu[meal]['products']) {
            let splitElement = element.split(' ');
            let name = splitElement[0];
            let quantity = Number(splitElement[1]);

            if (!this.productsInStock.hasOwnProperty(name) || 
            this.productsInStock[name] < quantity) {
                return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
            }
        };

        for (const element of this.menu[meal]['products']) {
            let splitElement = element.split(' ');
            let name = splitElement[0];
            let quantity = Number(splitElement[1]);

            this.productsInStock[name] -= quantity;
        };

        this.budget += this.menu[meal].price;
        return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${this.menu[meal].price}.`;
    }
}

let kitchen = new Kitchen(1000);
console.log(kitchen.loadProducts(['Banana 10 5', 'Banana 20 10', 'Strawberries 50 30', 'Yogurt 10 10', 'Yogurt 500 1500', 'Honey 5 50']));
console.log(kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99));
console.log(kitchen.addToMenu('Pizza', ['Flour 0.5', 'Oil 0.2', 'Yeast 0.5', 'Salt 0.1', 'Sugar 0.1', 'Tomato sauce 0.5', 'Pepperoni 1', 'Cheese 1.5'], 15.55));
console.log(kitchen.showTheMenu());