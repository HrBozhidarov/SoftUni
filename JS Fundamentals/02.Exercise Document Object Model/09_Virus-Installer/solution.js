function solve() {
    let step = 1;
    let buttons = document.getElementById('buttons').children;
    let firstStepDivElement =  document.getElementById('firstStep');
    let secondStepDivElement = document.getElementById('secondStep');

    buttons[1].addEventListener('click',function (ev) {
        document.querySelector('#exercise section').style.display = 'none';
    });

    buttons[0].addEventListener('click', click);

    function click(e) {

        switch (step) {
            case 1: firstStep(); break;
            case 2: if(!secondStep()) { return; } break;
            case 3: thirthStep(); break;
        }

        step++;
    }

    function firstStep() {
        let contentDiv = document.getElementById('content');
        let firstStepDiv= firstStepDivElement;

        contentDiv.style.background = 'none';
        firstStepDiv.style.display = 'block';
    }

    function secondStep() {
        let checkedButtonValue = Array.from(document.getElementById('firstStep').getElementsByTagName('input'))
            .filter(x => x.checked)[0];

        if(checkedButtonValue.value === 'disagree') {
           return false;
        }
        else {
            let button = buttons[0];
            button.style.display = 'none';
            setTimeout(function () {
                button.style.display = 'inline-block';
            },3000);

            firstStepDivElement.style.display = 'none';
            secondStepDivElement.style.display = 'block';

            return true;
        }
    }

    function thirthStep() {
        let finishBtn = buttons[1];
        finishBtn.textContent = 'Finish';
        let button = buttons[0];
        button.style.display = 'none';
        secondStepDivElement.style.display = 'none';
        document.getElementById('thirdStep').style.display = 'block';
    }
}