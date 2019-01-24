function solve() {
    let select = document.getElementById('selectMenuTo');
select.innerHTML = '<option value="binary">binary</option> <option value="hexadecimal">hexadecimal</option>';

document.querySelector('#menus button').addEventListener('click', (e) => {
    let input  = +document.getElementById('input').value;
    let options = document.getElementById('selectMenuTo').value;

    if (options === 'binary') {

        let binaryResult = input.toString(2);
        document.getElementById('result').value = binaryResult;

    } else if (options === 'hexadecimal') {

        let hexadecimalResult = input.toString(16).toUpperCase();
        document.getElementById('result').value = hexadecimalResult;
    }
});
}