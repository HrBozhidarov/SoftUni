function greatestCommonDivisor(number1,number2) {
    let greatestDivisor=1;
    for(i = 2;i < 10;i++){
        if(+number1 % i == 0 && +number2 % i == 0){
            greatestDivisor = i;
        }
    }

    console.log(greatestDivisor);
}

greatestCommonDivisor(2154, 458)