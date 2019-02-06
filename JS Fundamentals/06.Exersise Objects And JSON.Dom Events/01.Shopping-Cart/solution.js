function solve() {
    let textarea = document.querySelector('textarea');
    let productLists = [];
    let products = {
        Tomatoes: [],
        Bread: [],
        Milk: [],
    };

    document.querySelector('#exercise>button').addEventListener('click',function (element) {
        let totalPrice = 0;

        for (let productKey in products) {
            if (products[productKey].length > 0) {
                totalPrice += products[productKey].reduce((a, b) => a + b);
            }
        }

        if (products.Milk.length > 0 ||
            products.Bread.length > 0 ||
            products.Tomatoes.length > 0) {
            textarea.value += `You bought ${productLists.join(', ')} for ${totalPrice.toFixed(2)}.\n`;
        }

        products.Milk = [];
        products.Bread = [];
        products.Tomatoes = [];
        productLists = [];
    });

    Array.from(document.querySelectorAll('#exercise div.product>button')).forEach(function (element) {
        element.addEventListener('click',function (e) {
            let target = e.target;
            let price = parseFloat(target.previousElementSibling.textContent.split(' ')[1]);
            let product = target.previousElementSibling.previousElementSibling.textContent;

            if(productLists.indexOf(product) < 0)
            {
                productLists.push(product);
            }

            products[product].push(price);

            textarea.value += `Added ${product} for ${price.toFixed(2)} to the cart.\n`
        })
    });
}