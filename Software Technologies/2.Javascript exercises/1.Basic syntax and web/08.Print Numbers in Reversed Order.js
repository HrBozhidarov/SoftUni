let numbers = ['10','15','20'];

function reverseTheListOfNumbers(numbers) {
    let result=[];

    for (let i = numbers.length - 1; i >= 0; i--) {
        let number = Number(numbers[i]);
        result.push(number);
    }

   console.log(result.join('\n'));
}

reverseTheListOfNumbers(numbers);