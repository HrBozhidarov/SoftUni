function solve() {
    let trucks = [];
    let backupTires = [];

    let fieldsets = Array.from(document.querySelectorAll('#exercise > section > fieldset'));

    fieldsets[0].lastElementChild.addEventListener('click', addNewTruck);
    fieldsets[1].lastElementChild.addEventListener('click', addNewTires);
    fieldsets[2].lastElementChild.addEventListener('click', goToWork);

    document.querySelector('#exercise > section > button').addEventListener('click', endOfTheShift);

    function addNewTruck() {
        let newTruckPlateNumber = document.getElementById('newTruckPlateNumber').value;
        let newTruckTiresConditional = document.getElementById('newTruckTiresCondition').value;

        let truck = {
            'plateNumber': newTruckPlateNumber,
            'tiresConditional': newTruckTiresConditional.split(' ').map(x => Number(x)),
            'distance': 0
        };

        trucks.push(truck);
        appendToTrucDiv(newTruckPlateNumber);
    }

    function addNewTires() {
        let tires = document.getElementById('newTiresCondition').value
            .split(' ').map(x => Number(x));

        backupTires.push(tires);
        appendToTiresDiv(tires);
    }

    function goToWork() {
        let workPlateNumber = document.getElementById('workPlateNumber').value;
        let distance = Number(document.getElementById('distance').value);

        let truck = trucks.find(x => x['plateNumber'] === workPlateNumber);

        if (!truck) {
            return;
        }

        let minTireCond = Math.min(...truck['tiresConditional']) * 1000;

        if (minTireCond < distance) {
            if (backupTires.length > 0) {
                let backupTiresMin = Math.min(...backupTires[0]) * 1000;
                let newTires = backupTires.shift();

                if (backupTiresMin < distance) {
                    return;
                }

                truck['tiresConditional'] = newTires;
            }
            else {
                return;
            }
        }

        let subtract = distance / 1000;

        truck['tiresConditional'] = truck['tiresConditional'].map(x => x - subtract);
        truck['distance'] += distance;
    }

    function endOfTheShift() {
        let textarea = document.querySelectorAll('section')[1].children[2];

        trucks.forEach((x) => {
            textarea.value += `Truck ${x['plateNumber']} has traveled ${x['distance']}.\n`;
        });

        textarea.value += `You have ${backupTires.length} sets of tires left.\n`;
    }

    function appendToTrucDiv(plateNumber) {
        let appendTires = document.querySelectorAll('section')[1].children[1];
        let divTruck = document.createElement('div');
        divTruck.setAttribute('class','truck');
        divTruck.textContent = plateNumber;
        appendTires.appendChild(divTruck);
    }

    function appendToTiresDiv(arr) {
        let appendTires = document.querySelectorAll('section')[1].children[0];
        let divTire = document.createElement('div');
        divTire.setAttribute('class','tireSet');
        divTire.textContent = arr.join(' ');
        appendTires.appendChild(divTire);
    }
}