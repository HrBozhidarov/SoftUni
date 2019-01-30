function solve(arr) {
    arr.sort(compare);

    console.log(arr.join('\n'));

    function compare(a, b) {
        if (a.length > b.length) {
            return 1;
        }
        if (a.length < b.length) {
            return -1;
        }

        return a.toLowerCase() >= b.toLowerCase()
    }
}

let input = ['test',
    'Deny',
    'omen',
    'Default'];


solve(input);