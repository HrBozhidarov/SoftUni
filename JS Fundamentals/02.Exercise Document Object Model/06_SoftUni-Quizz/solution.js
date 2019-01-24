function solve() {
    let answers = 0;
    let counter = 0;

    let choose = {
        1:'2013',
        2:'Pesho',
        3:'Nakov'
    };

	Array.from(document.querySelectorAll('button')).forEach(function (elem) {
        elem.addEventListener('click', function (e) {
            let target = e.target;
            let next = target.parentElement.nextElementSibling;
            let name = target.parentElement.children[1].getAttribute('name');
            counter++;

            Array.from(document.querySelectorAll(`input[name="${name}"]`)).forEach(function (value) {
                if(value.checked) {
                    let currentAnswer = value.value === choose[counter];

                    if(currentAnswer) {
                        answers++;
                    }
                }
            });

            if(next === null) {
                let result = document.getElementById('result');

                if(answers === 3) {
                    result.textContent = 'You are recognized as top SoftUni fan!';
                }
                else {
                    result.textContent = `You have ${answers} right answers`;
                }
                return;
            }

            next.style.display = 'block';
        })
    })
}