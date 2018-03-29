let numbers = ['2', '3'];

function multiplyOrDeleteNumbers(numbers) {
    let n = Number(numbers[0]);
    let x = Number(numbers[1]);
    let result = 0;

    if (x >= n) {
        console.log(x * n);
    }
    else {
        console.log(n / x);
    }
}

multiplyOrDeleteNumbers(numbers);