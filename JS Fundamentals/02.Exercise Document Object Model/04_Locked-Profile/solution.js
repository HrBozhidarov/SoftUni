function solve() {
    let obj = {
        'user1Locked': 'user1HiddenFields',
        'user2Locked': 'user2HiddenFields',
        'user3Locked': 'user3HiddenFields',
    };

    Array.from(document.querySelectorAll('#exercise .profile input[type="radio"]'))
        .forEach(function (elem) {
            elem.addEventListener('click', function (e) {
                let target = e.target;
                let children = target.parentElement.children;
                children[2].removeAttribute('checked');
                children[4].removeAttribute('checked');
                target.setAttribute('checked', true);
            })
        });

    Array.from(document.querySelectorAll('#exercise .profile button'))
        .forEach(function (elem) {
            elem.addEventListener('click', show)
        });
   
    function show(e) {
        let target = e.target;
        let inputs = target.parentElement.children;

        if(Array.from(inputs[4].attributes).map(x => x.name).includes('checked')) {
            if(target.textContent === 'Show more') {
            let currentId = obj[inputs[4].getAttribute('name')];

            document.getElementById(currentId).style.display = "block";
            target.textContent = 'Hide it';
            }
            else {
                let currentId = obj[inputs[4].getAttribute('name')];

                document.getElementById(currentId).style.display = "none";
                target.textContent = 'Show more';
            }
        }
    }
} 