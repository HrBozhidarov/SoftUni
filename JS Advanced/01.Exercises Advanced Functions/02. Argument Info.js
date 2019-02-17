function solve() {
    let arg = arguments;
    let summary = {};

    for(let i = 0; i< arg.length; i++) {
        let value = arg[i];
        let type = typeof value;

        if(summary[type]) {
            summary[type]++;
        }
        else {
            summary[type] = 1;
        }

        console.log(`${type}: ${value}`)
    }

    let sortedTypes = [];

    for (let currentSummary in summary) {
        sortedTypes.push([currentSummary,summary[currentSummary]]);
    }

    sortedTypes.sort((a,b) =>  b[1] - a[1]);

    for (let type of sortedTypes) {
        console.log(`${type[0]} = ${type[1]}`)
    }
}

solve({ name: 'bob'}, 3.333, 9.999);