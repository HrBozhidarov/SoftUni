function solve(obj) {
    if (obj['handsShaking'] === true) {
        let weight = obj['weight'];
        let experience = obj['experience'];
        let alcohol = Math.round((weight * experience) * 0.1);
        obj['bloodAlcoholLevel'] += alcohol;
        obj['handsShaking'] = false;
    }

    return obj;
}

console.log(solve({ weight: 120,
    experience: 20,
    bloodAlcoholLevel: 200,
    handsShaking: true
}));