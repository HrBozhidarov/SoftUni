function solve() {
    document.getElementById('exercise')
        .firstElementChild
        .lastElementChild
        .addEventListener('click', function (e) {
            let target = e.target;
            let textarea = target.parentElement.children[1];
            let textareaValue = textarea.value;
            let textareaDecote = document.getElementById('exercise').lastElementChild.children[1];
            let encodingMessage = '';

            for(let ch of textareaValue)
            {
                let asciiNumber = ch.charCodeAt() + 1;
                encodingMessage += String.fromCharCode(asciiNumber);
            }

            textarea.value = '';
            textareaDecote.value = encodingMessage;
        });

    document.getElementById('exercise')
        .lastElementChild
        .lastElementChild
        .addEventListener('click', function (e) {
            let target = e.target;
            let textarea = target.parentElement.children[1];
            let textareaValue = textarea.value;
            let decodingMessage = '';

            for(let ch of textareaValue)
            {
                let asciiNumber = ch.charCodeAt() - 1;
                decodingMessage += String.fromCharCode(asciiNumber);
            }

            textarea.value = decodingMessage;
        });
}