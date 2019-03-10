function subtract() {
    let firstNum = $('#firstNumber').eq(0);
    let secondNum = $('#secondNumber').eq(0);
    let result = $('#result').eq(0);

    let sum = Number(firstNum.val()) - Number(secondNum.val());

    result.append(sum);
}