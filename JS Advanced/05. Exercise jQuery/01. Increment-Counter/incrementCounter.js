function increment(selector) {
    createInitialPage(selector);

    function createInitialPage(selector) {
        let container = $(selector);
        let fragment = document.createDocumentFragment();

        let textarea = $('<textarea>');
        textarea.addClass('counter');
        textarea.attr('disabled', 'true');
        textarea.val(0);

        let incrementBtn = $('<button>').on('click',incrementValue);
        incrementBtn.addClass('btn');
        incrementBtn.text('Increment');
        incrementBtn.attr('id', 'incrementBtn');

        let addBtn = $('<button>').on('click', addToList);
        addBtn.addClass('btn');
        addBtn.text('Add');
        addBtn.attr('id', 'addBtn');

        let ul = $('<ul>');
        ul.addClass('results');

        textarea.appendTo(fragment);
        incrementBtn.appendTo(fragment);
        addBtn.appendTo(fragment);
        ul.appendTo(fragment);
        container.append(fragment);
    }

    function addToList() {
        let value = $('textarea').eq(0).val();

        $('ul').eq(0).append(`<li>${value}</li>`);
    }

    function incrementValue() {
        let textarea = $('textarea').eq(0);
        let currentValue = Number(textarea.val());
        textarea.val(currentValue + 1);
    }
}
