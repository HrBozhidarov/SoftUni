function gcd(num1, num2) {
    if (num2 === 0) {
        return num1;
    }
    else {
        return gcd(num2, num1 % num2);
    }
}

console.log(gcd(252, 105));