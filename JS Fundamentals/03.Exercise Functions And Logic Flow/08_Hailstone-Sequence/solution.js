function getNext() {
    let result = document.getElementById('result');
    let num = +document.getElementById('num').value;
    let arr = [];

    if (num === 1) {
        result.textContent = 1;
    }

    arr.push(num);

    while (num !== 1) {
        if (num % 2 === 0) {
            num = Math.floor(num / 2);
        }
        else {
            num = (num * 3) + 1;
        }

        arr.push(num);
    }

    result.textContent = arr.join(' ') + ' ';
}