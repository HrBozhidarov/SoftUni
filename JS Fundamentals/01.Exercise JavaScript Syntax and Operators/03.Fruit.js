function fruit(fruit,weigthInGrams,pricePerKg) {
    let getKgmsFromGrams= (+weigthInGrams/1000);
    let needMoney=(getKgmsFromGrams*(+pricePerKg));

    console.log(`I need ${needMoney.toFixed(2)} leva to buy ${getKgmsFromGrams.toFixed(2)} kilograms ${fruit}.`)
}

fruit('apple', 1563, 2.35)

