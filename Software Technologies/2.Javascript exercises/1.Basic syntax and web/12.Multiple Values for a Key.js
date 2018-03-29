let lines = ['key value', 'key eulav', 'test test','key'];

function printValuesIfHaveKeyInTheLastLine(lines) {
    let result = {};

    for (let i = 0; i < lines.length; i++) {
        let line=lines[i].split(' ');

        if(i===lines.length-1){

            if(result[line]===undefined){
                console.log('None')
            }
            else{
                console.log(result[line].split(' ').join('\n'));
            }

            break;
        }

        if(result[line[0]]===undefined){
            result[line[0]]='';
        }

        result[line[0]]+=line[1]+ ' ';
    }
}

printValuesIfHaveKeyInTheLastLine(lines);