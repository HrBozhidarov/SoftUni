let lines = ['Line 1', 'Line 2', 'Line 3', 'Stop'];

function multiplyOrDeleteNumbers(lines) {
    let result = [];

    for (let line of lines) {
        if (line === "Stop") {
            break;
        }

        result.push(line)
    }

    console.log(result.join('\n'));
}

multiplyOrDeleteNumbers(lines);