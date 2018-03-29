let lines = ['Pesho -> 13 -> 6.00', 'Ivan -> 12 -> 5.57', 'Toni -> 13 -> 4.90'];

function printObjects(lines) {
    let result = [];

    for (let i = 0; i < lines.length; i++) {
        let line = lines[i].split(' -> ');
        let name = line[0];
        let age = Number(line[1]);
        let grade = line[2];
        let json = {
            name: name,
            age: age,
            grade: grade
        };

        result.push(json);
    }

    for(let json of result){
        console.log(`Name: ${json.name}`);
        console.log(`Age: ${json.age}`);
        console.log(`Grade: ${json.grade}`);
    }
}

printObjects(lines);