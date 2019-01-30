function solve(arr) {
    let result = [];
    let count = 1;

    for (let item of arr) {
        if (item === 'add') {
            result.push(count)
        }
        else {
            result.pop();
        }
        count++;
    }

    if (0 === result.length) {
        console.log('Empty')
    }
    else {
        console.log(result.join('\n'));
    }
}

let arr = ['remove',
    'remove',
    'remove'];

solve(arr);
