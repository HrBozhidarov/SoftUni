let numbers = ['2', '3', '-1'];

function checkIfNumberIsPositivOrNegativeByMultiply(numbers) {
    let num1 = Number(numbers[0]);
    let num2 = Number(numbers[1]);
    let num3 = Number(numbers[2]);
    let count = 0;

    if (num1 < 0) {
        count += 1;
    }

    if (num2 < 0) {
        count += 1;
    }

    if (num3 < 0) {
        count += 1;
    }

    if (count % 2 === 0) {
        console.log('Positive')
    }
    else {
        console.log('Negative')
    }

}

multiplyOrDeleteNumbers(numbers);