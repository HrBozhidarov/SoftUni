function solve(arr) {
    let elementRotation = +arr.pop();
    let rotation = elementRotation % arr.length;;

    for (let i = 0; i < rotation; i++) {
        let element = arr.pop();
        arr.unshift(element);
    }

    console.log(arr.join(' '));
}

let input = ['1',
    '2',
    '3',
    '4',
    '2'];


solve(input);