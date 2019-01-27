function validate() {
    let months = {
        'January': '01',
        'February': '02',
        'March': '03',
        'April': '04',
        'May': '05',
        'June': '06',
        'July': '07',
        'August': '08',
        'September': '09',
        'October': '10',
        'November': '11',
        'December': '12'
    };
    let maleNumber = 2;
    let femaleNumber = 1;
    let weights = [2, 4, 8, 5, 10, 9, 7, 3, 6];
    let inputYear = document.getElementById('year');
    let inputMonth = document.getElementById('month');
    let inputDate = document.getElementById('date');
    let inputMale = document.getElementById('male');
    let inputFemale = document.getElementById('female');
    let inputRegion = document.getElementById('region');
    let result = document.getElementById('egn');
    let formatRegion;

    document.getElementById('egn').previousElementSibling.addEventListener('click', validate);

    function validate(e) {
        let lastNumber;
        let sum = 0;
        let egn;
        let inputYearValue = inputYear.value;
        let inputMonthValue = inputMonth.value;
        let inputDateValue = inputDate.value;
        let inputRegionValue = inputRegion.value;
        let male;

        if (inputYearValue < 1900 || inputYearValue > 2100) {
            return;
        }

        if (inputRegionValue < 43 || inputRegionValue > 999) {
            return;
        }

        male =  inputMale.checked === true ? maleNumber : femaleNumber;

        formatRegion =
            inputRegionValue.length === 3 ?
                +inputRegionValue[2] % 2 === 0 ? inputRegionValue.substr(0,2) + male
                    : inputRegionValue.substr(0,2) + male :
                inputRegionValue.substr(0,2) + male;

        egn = inputYearValue[2] + inputYearValue[3];
        egn += months[inputMonthValue];
        egn += pad(inputDateValue,2);
        egn += formatRegion;

        for (let i = 0; i < weights.length; i++) {
            sum += weights[i] * egn[i];
        }

        lastNumber = sum % 11 === 10 ? 0 : sum % 11;
        egn += lastNumber;

        inputYear.value = '';
        inputMonth.value = '';
        inputDate.value = '';
        inputMale.checked = false;
        inputFemale.checked = false;
        inputRegion.value = '';

        result.textContent = 'Your EGN is: ' + egn;
    }

    function pad(num, size) {
        let s = num + "";
        while (s.length < size) s = "0" + s;
        return s;
    }
}