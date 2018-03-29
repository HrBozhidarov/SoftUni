let lines = ['3', '0 - 5', '0 - 6', '0 - 7'];

function setValueInIndexPosition(lines) {
    let result = [];
    let n = Number(lines[0]);

    for (let i = 0; i < n; i++) {
        result.push(0);
    }

    for (let i = 1; i < lines.length; i++) {
        let indexAndValue=lines[i].split(' - ').map(x =>Number(x));
        result[indexAndValue[0]]=indexAndValue[1];
    }

    console.log(result.join('\n'));
}

setValueInIndexPosition(lines);