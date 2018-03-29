let lines = ['key value', 'key eulav', 'test test','key'];

function printValueIfHaveKeyInTheLastLine(lines) {
    let result = {};

    for (let i = 0; i < lines.length; i++) {
       let line=lines[i].split(' ');

       if(i===lines.length-1){

           if(result[line]===undefined){
               console.log('None')
           }
           else{
                console.log(result[line]);
           }

           break;
       }

       result[line[0]]=line[1];
    }
}

printValueIfHaveKeyInTheLastLine(lines);