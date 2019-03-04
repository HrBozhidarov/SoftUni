function solve(obj) {
    let result = {
        model: obj.model
    };

    let engine = {
        90: 1800,
        120: 2400,
        200: 3500
    };

    let horse = Number.MAX_SAFE_INTEGER;
    let power;

    for (let eng in engine) {
        let currentValue = Math.abs(eng - obj.power);

        if(currentValue < horse) {
            horse = currentValue;
            power = Number(eng);
        }
    }

    result.engine = {
        power: power,
        volume: engine[power.toString()]
    };

    result.carriage = {
        type: obj.carriage,
        color: obj.color
    };

    let wheelSize = obj.wheelsize % 2 === 0 ? obj.wheelsize - 1 : obj.wheelsize;
    let wheels = [];

    for(let i = 0; i< 4; i++) {
        wheels.push(wheelSize);
    }

    result.wheels = wheels;

    return result;
}

console.log(solve({ model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17 }
));