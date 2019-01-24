function solve() {
    let imgs = Array.from(document.querySelectorAll('#exercise img'));
    let topElement;
    let downElement;

    imgs.forEach(function (elem) {
        elem.addEventListener('click',click);
    });

    function click(e) {
        let elem = e.target;
        let number = elem.getAttribute('name');
        let leftOrRightPart = elem.parentElement.getAttribute('id');
        let leftPart = document.querySelector('#result').firstElementChild;
        let rightPart = document.querySelector('#result').lastElementChild;
        let currentImg = elem;

        currentImg.setAttribute('src', 'images/whiteCard.jpg');
        currentImg.removeEventListener('click',click);

        if(leftOrRightPart === 'player1Div') {
            topElement = elem;
            leftPart.textContent = number;
        }
        else {
            downElement = elem;
            rightPart.textContent = number;
        }

        if(leftPart.textContent && rightPart.textContent) {
            let leftNumber = +leftPart.textContent;
            let rightNumber = +rightPart.textContent;
            let history = document.querySelector('#history');

            let text = history.textContent;
            text += `[${leftNumber} vs ${rightNumber}] `;

            history.textContent = text;

            if(leftNumber > rightNumber) {
                topElement.style.border = "2px solid green";
                downElement.style.border = "2px solid darkred";
            }
            else {
                downElement.style.border = "2px solid green";
                topElement.style.border = "2px solid darkred";
            }

            setTimeout(() => {
            leftPart.textContent = '';
            rightPart.textContent = '';
            },2000);
        }
    }
}