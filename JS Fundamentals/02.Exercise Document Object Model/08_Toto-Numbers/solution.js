function solve() {
	document.querySelector('#myNumbers button').addEventListener('click',click);

    function click(e) {
        let target = e.target;
        let input = target.previousElementSibling;
        let inputValue = input.value;
        let splitInputValue = inputValue.split(' ');

        if(splitInputValue.length !== 6
            || splitInputValue.some(x => +x < 1 || +x > 49)
            || splitInputValue.some(isNaN)
            ) {
            return;
        }

        Array.from(createDivElements().children).forEach(function (elem) {
            if(splitInputValue.includes(elem.textContent)) {
                elem.style.backgroundColor = 'orange';
            }
        });

        input.setAttribute('disabled', true);
        target.setAttribute('disabled', true);
    }

    function createDivElements() {
        let allNumbers = document.getElementById('allNumbers');

        for(let i = 1; i <= 49; i++) {
            let createDiv = document.createElement('div');

            createDiv.textContent = i;
            createDiv.setAttribute('class', 'numbers');

            allNumbers.appendChild(createDiv);
        }

        return allNumbers;
    }
}