let lines = ['name -> Angel', 'surname -> Georgiev', 'age -> 20', 'grade -> 6.00', 'date -> 23/05/1995', 'town -> Sofia',];

function strinifyJson(lines) {
    let result = {};

    for (let i = 0; i < lines.length; i += 1) {
        let currentLine = lines[i].split(' -> ');

        if (currentLine[0] === 'grade') {
            result[currentLine[0]] = Number(currentLine[1]);
        }
        else if (currentLine[0] === 'age') {
            result[currentLine[0]] = Number(currentLine[1]);
        }
        else {
            result[currentLine[0]]=currentLine[1];
        }

    }

    console.log(JSON.stringify(result));
}

strinifyJson(lines);