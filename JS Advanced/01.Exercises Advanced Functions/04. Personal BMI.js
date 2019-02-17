function personInfoBMI(name, age, weight, heightInCm) {
    let heightInMeters = heightInCm / 100;
    let privateBMI = weight/Math.pow(heightInMeters,2);
    let status = getBMIStatus(privateBMI);
    let personInfo = {
        name: name,
            personalInfo: {
            age: age,
                weight: weight,
                height: heightInCm
        },
        BMI: Math.round(privateBMI)
    };

    personInfo.status = status;

    if(status === 'obese') {
        personInfo.recommendation = 'admission required';
    }

    return personInfo;

    function getBMIStatus(privateBMI) {
        let status;

        if(privateBMI < 18.5) {
            status = 'underweight';
        }
        else if(privateBMI < 25) {
            status = 'normal';
        }
        else if(privateBMI < 30) {
            status = 'overweight';
        }
        else {
            status = 'obese';
        }

        return status;
    }
}

console.log(personInfoBMI('Peter', 29, 75, 182));