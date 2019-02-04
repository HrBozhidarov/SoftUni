function solve() {
    let resultHtml = document.getElementById('result');
    let input = document.getElementById('str').value;
    let sumRem = 0;

    for (let i = 0; i < input.length; i++) {
        sumRem += +input[i];
    }

    let remove = sumRem.toString();

    if (sumRem > 9) {
        convertSumInOneDigitLikeDividedByTwo();
    }

    let str = removeEquelSymbolsFromStartAndEnd((sumRem), input);
    let parts = [];
    let splitPartsLength = Math.round(str.length / 8);

    for (let i = 0; i < splitPartsLength*8; i += 8) {
        parts.push(str.substr(i, 8));
    }

    let asciNumbers = parts.map(x => parseInt(x, 2));

    let result = asciNumbers.filter(x=> (x>=97 && x<=122) || (x>=65 && x<=90) || x===32).map(x => String.fromCharCode(x));

    resultHtml.textContent = result.join('');

    function removeEquelSymbolsFromStartAndEnd(start, str) {
        return str.substr(start, str.length - (2 * start))
    }

    function convertSumInOneDigitLikeDividedByTwo() {
        sumRem = 0;

        while (remove.length > 1) {
            let currentIndex = remove.length / 2;
            let firstPart = +remove.substr(0, currentIndex);
            let secondPart = +remove.substr(currentIndex);
            let allParts = Number(firstPart) + Number(secondPart);

            remove = allParts.toString();
        }

        sumRem = +remove;
    }
}