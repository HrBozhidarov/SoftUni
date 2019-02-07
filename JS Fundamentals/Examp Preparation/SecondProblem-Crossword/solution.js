function solve() {
    let input = document.getElementById('input');
    let output = document.querySelector('#output p');

    document.querySelector('#filter > button').addEventListener('click', filter);
    document.querySelector('#sort > button').addEventListener('click', sort);
    document.querySelector('#rotate > button').addEventListener('click', rotate);
    document.querySelector('#get > button').addEventListener('click', get);

    function get() {
        let inputValue = input.value;
        let position = Number(document.getElementById('getPosition').value);

        output.textContent += inputValue[position - 1];
    }

    function rotate() {
        let rotateNumber = Number(document.getElementById('rotateSecondaryCmd').value);
        let inputValue = input.value;
        let position = Number(document.getElementById('rotatePosition').value);
        let newStr = inputValue.split('');

        for (let i = 0; i < rotateNumber; i++) {
            let pop = newStr.pop();
            newStr.unshift(pop);
        }

        output.textContent += newStr.join('')[position - 1];
    }

    function sort() {
        let optionValue = getOptionValue("sortSecondaryCmd");
        let inputValue = input.value;
        let position = Number(document.getElementById('sortPosition').value);
        let newStr = '';

        switch (optionValue) {
            case 'A':
                newStr = inputValue.split('').sort().join('');
                break;
            case 'Z':
                newStr = inputValue.split('').sort((a, b) => {
                    if (a < b) {
                        return 1;
                    }
                    if (a > b) {
                        return -1;
                    }

                    return 0;
                }).join('');
                break;
        }

        output.textContent += newStr[position - 1];
    }

    function filter() {
        let optionValue = getOptionValue("filterSecondaryCmd");
        let inputValue = input.value;
        let position = Number(document.getElementById('filterPosition').value);

        if (!optionValue || position > inputValue.length) {
            return;
        }

        let newStr = '';

        switch (optionValue) {
            case 'uppercase':
                for (let value of inputValue) {
                    if (value === value.toUpperCase() && isNaN(value)) {
                        newStr += value;
                    }
                }

                break;
            case 'lowercase':
                for (let value of inputValue) {
                    if (value === value.toLowerCase() && isNaN(value)) {
                        newStr += value;
                    }
                }

                break;
            case 'nums':
                for (let value of inputValue) {
                    if (!isNaN(value)) {
                        newStr += value;
                    }
                }

                break;
        }

        output.textContent += newStr[position - 1];
    }

    function getOptionValue(selectId) {
        let filterSelect = document.getElementById(selectId);
        let optionValue = filterSelect.options[filterSelect.selectedIndex].value;

        return optionValue;
    }
}