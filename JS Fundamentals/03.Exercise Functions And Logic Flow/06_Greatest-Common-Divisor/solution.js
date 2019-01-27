function greatestCD() {
    let num1 = Number(document.getElementById('num1').value);
    let num2 = Number(document.getElementById('num2').value);
    let result = document.getElementById('result');

    let gcd = gcdTwoNumbers(num1, num2);

    if(gcd) {
        result.textContent = gcdTwoNumbers(num1, num2);
    }

    function gcdTwoNumbers(num1, num2) {
        if ((typeof num1 !== 'number') || (typeof num2 !== 'number'))
            return false;

        num1 = Math.abs(num1);
        num2 = Math.abs(num2);

        while(num2) {
            let temp = num2;
            num2 = num1 % num2;
            num1 = temp;
        }
        return num1;
    }
}