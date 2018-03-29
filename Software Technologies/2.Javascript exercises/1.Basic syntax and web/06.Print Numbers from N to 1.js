let numbers = ['5'];

function PrintNumberFromNToOne(numbers) {
    let n = Number(numbers[0]);

    for (let i = n; i >= 1; i--) {
        console.log(i);
    }
}

PrintNumberFromNToOne(numbers);