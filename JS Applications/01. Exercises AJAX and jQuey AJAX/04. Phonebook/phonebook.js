function attachEvents() {
    let phoneContainer = $('#phonebook');
    let baseUrl = 'https://phonebook-nakov.firebaseio.com/phonebook';
    let suffix = '.json';
    let loadPhonesBtn = $('#btnLoad');
    let btnCreate = $('#btnCreate');
    let personInp = $('#person');
    let phoneInp = $('#phone');

    btnCreate.on('click', create);
    loadPhonesBtn.on('click', load);

    function create(e) {
        let person = personInp.val();
        let phone = phoneInp.val();

        let obj = {
            person,
            phone
        };

        $.ajax({
            method: 'POST',
            url: baseUrl+suffix,
            data: JSON.stringify(obj),
            success: () => {
                load();
                personInp.val('');
                phoneInp.val('');
            }
        })
    }

    function load(e) {
        $.ajax({
            method: 'GET',
            url: baseUrl + suffix,
            success: (data) => {
                phoneContainer.empty();

                if (data) {
                    let entries = Object.entries(data);

                    entries.forEach(x => {
                        let value = x[1];
                        let li = $(`<li>${value.person}: ${value.phone}</li>`);
                        let btn = $('<button type="button">Delete</button>');
                        let span = $(`<span style="display: none;">${x[0]}</span>`);
                        li.append(span);
                        li.append(btn);
                        phoneContainer.append(li);
                    });

                    if (entries.length > 0) {
                        $('#phonebook').on('click', 'li', function (e) {
                            let target = $(e.target).parent();
                            let key = '/' + target.children().eq(0).text();

                            $.ajax({
                                method: 'DELETE',
                                url: baseUrl + key + suffix,
                                success: () => {
                                    load();
                                }
                            })
                        });
                    }
                }
            }
        });
    }
}