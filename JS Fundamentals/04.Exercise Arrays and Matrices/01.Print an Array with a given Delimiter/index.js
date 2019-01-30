function solve(arr) {
    let delimiter = arr.pop();

    console.log(arr.join(delimiter));
}

let input = ['One', 'Two', 'Three', 'Four', 'Five', '-'];

solve(input);