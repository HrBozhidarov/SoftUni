function attachEvents() {
    let authorInput = $('#author');
    let contentInput = $('#content');
    let submitBtn = $('#submit');
    let refreshBtn = $('#refresh');
    let messages = $('#messages');

    submitBtn.on('click', submit);
    refreshBtn.on('click',all);

    function submit(e) {
        let obj = {
            author: authorInput.val(),
            content: contentInput.val(),
            timestamp: Date.now()
        };

        $.ajax({
            method: 'POST',
            data: JSON.stringify(obj),
            url: `https://messanger-6eff2.firebaseio.com/messenger/.json`,
            success: (data) => {
                all();

                authorInput.val('');
                contentInput.val('');
            },
        });
    }

    function all() {
        messages.empty();
        $.ajax({
            method: 'GET',
            url: `https://messanger-6eff2.firebaseio.com/messenger/.json`,
            success: (data) => {
                let orderedMessages = {};
                data = Object.keys(data).sort((a,b) => a.timestamp - b.timestamp).forEach(k => orderedMessages[k] = data[k]);
                for(let message of Object.keys(orderedMessages)){
                    $('#messages').append(`${orderedMessages[message]['author']}: ${orderedMessages[message]['content']}\n`);
                }
            }
        });
    }

    all();
}