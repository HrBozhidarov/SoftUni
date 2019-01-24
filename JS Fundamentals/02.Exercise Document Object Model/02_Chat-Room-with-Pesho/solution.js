function solve() {
    let buttons = Array.from(document.querySelectorAll('div button'));

    buttons.forEach(function (elem) {
        elem.addEventListener('click',click);
    });

    function click(e) {
        let currentBtn = e.target;

        let nameBtn = currentBtn.getAttribute('name');
        let chatChronology = document.getElementById('chatChronology');
        let newDiv = document.createElement('div');
        let span = document.createElement('span');
        let pharagraph = document.createElement('p');

        if(nameBtn === 'myBtn') {
            let currentInput = document.getElementById('myChatBox');
            span.textContent = 'Me';
            pharagraph.textContent = currentInput.value;
            currentInput.value = '';
            newDiv.style.textAlign = 'left';
        }
        else {
            let currentInput = document.getElementById('peshoChatBox');
            span.textContent = 'Pesho';
            pharagraph.textContent = currentInput.value;
            currentInput.value = '';
            newDiv.style.textAlign = 'right';
        }

        newDiv.appendChild(span);
        newDiv.appendChild(pharagraph);
        chatChronology.appendChild(newDiv);
    }
}