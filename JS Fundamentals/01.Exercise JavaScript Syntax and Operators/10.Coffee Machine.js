function coffeMachine(arr) {
    let totalIncome = 0.0;

    for(let i = 0;i < arr.length; i++){
        let parts = arr[i].split(', ');
        let initialCoins = +parts[0];
        let currentPrice = 0.0;
        let drink = '';

        if(parts[1] == 'coffee') {
            drink = 'coffee';

            if(parts[2] == 'caffeine') {
                currentPrice = 0.8;
            }
            else {
                currentPrice = 0.9;
            }

            if(parts[3] == 'milk') {
                let addToCoffee = (currentPrice * 0.1).toFixed(1);
                currentPrice += +addToCoffee;

                if(+parts[4] > 0) {
                    currentPrice += +((currentPrice * 0.1).toFixed(1));
                }
            }
            else {
                if(+parts[3] > 0) {
                    currentPrice += +((currentPrice * 0.1).toFixed(1));
                }
            }
        }
        else {
            drink = 'tea';
            currentPrice = 0.8;

            if(parts[2] == 'milk') {
                let addToCoffee = (currentPrice * 0.1).toFixed(1);
                currentPrice += +addToCoffee;

                if(+parts[3] > 0) {
                    currentPrice += +((currentPrice * 0.1).toFixed(1));
                }
            }
            else {
                if(+parts[2] > 0) {
                    currentPrice += +((currentPrice * 0.1).toFixed(1));
                }
            }
        }

        let change = +((initialCoins - currentPrice).toFixed(1));

        if(change >= 0) {
            totalIncome += Math.round(currentPrice * 100)/100;

            console.log(`You ordered ${drink}. Price: ${currentPrice.toFixed(2)}$ Change: ${change.toFixed(2)}$`);
        }
        else {
            console.log(`Not enough money for ${drink}. Need ${(currentPrice - initialCoins).toFixed(2)}$ more.`);
        }
    }

    console.log(`Income Report: ${totalIncome.toFixed(2)}$`);
}

coffeMachine(['1.00, coffee, caffeine, milk, 4', '0.40, tea, milk, 2',
    '1.00, coffee, decaf, 0']);