function solve() {
    let input = document.querySelector('#exercise input');
    let output = document.getElementById('output');
    let number;

    document.querySelector('#operations button:nth-child(1)')
        .addEventListener('click', chop);

    document.querySelector('#operations button:nth-child(2)')
        .addEventListener('click', dice);

    document.querySelector('#operations button:nth-child(3)')
        .addEventListener('click', spice);

    document.querySelector('#operations button:nth-child(4)')
        .addEventListener('click', bake);

    document.querySelector('#operations button:nth-child(5)')
        .addEventListener('click', fillet);

    function fillet(e) {
        getNumber();
        number *= 0.8;

        writeOutput();
    }

    function bake(e) {
        getNumber();

        number *= 3;

        writeOutput();
    }

    function spice(e) {
        getNumber();

        number += 1;

        writeOutput();
    }

    function dice(e) {
        getNumber();

        number = Math.sqrt(number);

        writeOutput();
    }

    function chop(e) {
        getNumber();

        number /= 2;

        writeOutput();
    }

    function getNumber() {
        number = +output.textContent || +input.value;
    }

    function writeOutput() {
        output.textContent = String(number);
    }
}