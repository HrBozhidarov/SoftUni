function attachEventsListeners() {
    let obj = {
        'km': 1000,
        'm': 1,
        'cm': 0.01,
        'mm': 0.001,
        'mi': 1609.34,
        'yrd': 0.9144,
        'ft': 0.3048,
        'in': 0.0254
    };
    
    let inputUnits = $('#inputUnits');
    let outputUnits = $('#outputUnits');
    let inputDistance = $('#inputDistance');
    let outputDistance = $('#outputDistance');

    $('#convert').on('click', convert)

    function convert() {
        let fromKey = inputUnits.find(":selected").val();
        let toKey = outputUnits.find(":selected").val();
    
        let inputToM = getInputResult(fromKey, 0);
        let result = getOutputResult(toKey, 0, inputToM);
    
        outputDistance.val(result);
    }

    function getOutputResult(toKey, result, inputToM) {
        if (toKey === 'm') {
            result = inputToM;
        }
        else {
            result = Number(inputToM) / obj[toKey];
        }

        return result;
    }

    function getInputResult(fromKey, inputToM) {
        if (fromKey === 'm') {
            inputToM = Number(inputDistance.val());
        }
        else {
            inputToM = Number(inputDistance.val()) * obj[fromKey];
        }

        return inputToM;
    }
}