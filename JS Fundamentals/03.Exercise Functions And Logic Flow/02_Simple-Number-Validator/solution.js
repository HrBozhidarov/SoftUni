function validate() {
    let input = document.querySelector('input[type="number"]');
    let result = document.getElementById('response');
    let weights = [2, 4, 8, 5, 10, 9, 7, 3, 6];

    document.querySelector('button').addEventListener('click', validate);

    function validate(e) {
        let lastNumber;
        let sum = 0;
        let remainder;
        let inputValue = input.value;

        lastNumber = +inputValue[inputValue.length - 1];

        for(let i = 0; i < weights.length; i++) {
            sum += weights[i] * inputValue[i];
        }

        remainder = sum % 11 === 10 ? 0 : sum % 11;

        if(remainder !== lastNumber) {
            result.textContent = 'This number is NOT Valid!';

            return;
        }

        result.textContent = 'This number is Valid!';
    }
}