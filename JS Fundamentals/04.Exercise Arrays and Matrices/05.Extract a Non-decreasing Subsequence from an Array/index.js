function solve(arr) {
    let min = Number.MIN_SAFE_INTEGER;

    let result = arr.reduce((acc,value) => {
        if(value >= min) {
            min = value;
            acc.push(value);
        }
        return acc;
    },[]);

    console.log(result.join('\n'));
}

let input = [20,
    3,
    2,
    15,
    6,
    1];


solve(input);