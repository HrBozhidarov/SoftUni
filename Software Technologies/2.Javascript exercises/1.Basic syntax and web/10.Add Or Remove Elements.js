let lines = ['add 3', 'add 5', 'remove 2','remove 0', 'add 7'];

function addAndRemoveElementsFromArray(lines) {
    let result = [];

    for (let i = 0; i < lines.length; i++) {
        let indexAndValue = lines[i].split(' ');
        let command = indexAndValue[0];

        if (command === 'add') {
            let value = indexAndValue[1];
            result.push(value);
        }
        else {
            let index = Number(indexAndValue[1]);
            if (index >= result.length) {
                continue;
            }

            result.splice(index, 1);

        }
    }

    console.log(result.join('\n'));
}

addAndRemoveElementsFromArray(lines);