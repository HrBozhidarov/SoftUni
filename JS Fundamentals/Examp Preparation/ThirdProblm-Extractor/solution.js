function solve() {
    let input = document.getElementById('input');
    let output = document.getElementById('output');

    document.querySelector('#exercise button').addEventListener('click', function () {
        let inputValue = input.value;
        let numberStr = inputValue.match(/[0-9]+/g)[0];
        let position = Number(numberStr);
        let newValue = inputValue.substr(numberStr.length, position);
        let splitCh = newValue[newValue.length - 1];
        let splitValue = newValue.split(splitCh);
        let result = splitValue[1].replace(new RegExp(`[${splitValue[0]}]`,'g'),'');
        let final = result.replace(/#/g, ' ');

        output.value = final;
    })
}