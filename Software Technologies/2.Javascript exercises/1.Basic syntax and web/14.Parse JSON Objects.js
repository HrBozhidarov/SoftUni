let lines = ['{"name":"Gosho","age":10,"date":"19/06/2005"}', '{"name":"Tosho","age":11,"date":"04/04/2005"}'];

function printJsonObjects(lines) {
    let result = lines.map(x=>JSON.parse(x));

    for(let json of result){
        console.log(`Name: ${json['name']}`);
        console.log(`Age: ${json['age']}`);
        console.log(`Date: ${json['date']}`);
    }
}

printJsonObjects(lines);