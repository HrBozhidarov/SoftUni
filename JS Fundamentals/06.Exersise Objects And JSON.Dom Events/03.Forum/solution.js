function solve() {
    let submitButton = document.querySelector('form > button');
    let searchButton = document.querySelector('#exercise > button');
    let userFieldsInfo = document.querySelectorAll('.user-info > input');
    let userFieldsTopics = document.querySelectorAll('.topics input[type = "checkbox"]');
    let tableBody = document.querySelector('tbody');
    let inputSearch = document.querySelector('#exercise > input');
    let users = [];

    submitButton.addEventListener('click', createUser);
    searchButton.addEventListener('click', searchUser);

    function createUser(e) {
        e.preventDefault();

        let userInfoArr = Array.from(userFieldsInfo);
        let userTopics = Array.from(userFieldsTopics).filter(x => x.checked).map(x => x.value);

        if (userTopics.length <= 0) {
            return;
        }

        if (userInfoArr.some(x => !x.value)) {
            return;
        }

        let user = {
            username: userInfoArr[0].value,
            password: userInfoArr[1].value,
            email: userInfoArr[2].value,
            topics: userTopics
        };

        users.push(user);

        createRow(user);
    }

    function searchUser(e) {
        e.preventDefault();

        let search = inputSearch.value;

        Array.from(tableBody.children).forEach(tr => {
            let searchFound = false;
            let trChildren = tr.children;
            Array.from(trChildren).forEach(td => {
                if(td.textContent.includes(search)) {
                    searchFound = true;
                }
            });

            if(searchFound) {
                tr.style.visibility = 'visible';
            }
            else {
                tr.style.visibility = 'hidden';
            }
        });
    }

    function createRow(user) {
        let tr = document.createElement('tr');

        for (let userKey in user) {
            if (userKey !== 'password') {
                let td = document.createElement('td');

                if (Array.isArray(user[userKey])) {
                    td.textContent = user[userKey].join(' ');
                }
                else {
                    td.textContent = user[userKey];
                }

                tr.appendChild(td);
            }
        }

        tableBody.appendChild(tr);
    }
}