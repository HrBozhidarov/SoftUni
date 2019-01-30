function solve(arr) {
    let step = +arr.pop();

    for (let i = 0; i < arr.length; i+=step) {
        console.log(arr[i]);
    }
}

let input = ['5', '20', '31', '4', '20', '2'];


solve(input);