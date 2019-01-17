function sameNumber(number) {
    let isTheSame = true;
    let sum = 0;
    let numberLikeString= number.toString();

    for(let i = 0; i < numberLikeString.length - 1;i++) {
        let firstNumber = +numberLikeString[i];
        let secondNumber = +numberLikeString[i + 1];

        if(firstNumber != secondNumber){
            isTheSame = false;
        }

        sum += firstNumber;
    }

    sum += +numberLikeString[numberLikeString.length - 1];

    console.log(isTheSame);
    console.log(sum);
}

sameNumber(1234);