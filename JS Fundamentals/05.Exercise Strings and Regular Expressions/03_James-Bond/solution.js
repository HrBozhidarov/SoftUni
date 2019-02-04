function solve() {
    let input = JSON.parse(document.getElementById('arr').value);
    let result = document.getElementById('result');
    let decodeObjSymbols = {
        '!': '1',
        '%': '2',
        '#': '3',
        '$': '4'
    };
    let specialKey = input[0];
    let regex = new RegExp(`( ${specialKey}\\s+|^${specialKey}\\s+)([a-z!%#$]{8,}\\s+|[a-z!%#$]{8,}$)`, 'gi');

    for (let i = 1; i < input.length; i++) {
        let regexMatch;
        let line = input[i];

        while ((regexMatch = regex.exec(line)) !== null) {
            let message = regexMatch[2];

            if (checkIfAllLettersAreCapital(message)) {
                let decodeMessage = `${regexMatch[1]}${decodeText(message)}`;
                let oldValue = `${regexMatch[1]}${regexMatch[2]}`;

                line = line.replace(oldValue, decodeMessage)
            }
        }

        let p = document.createElement('p');
        p.textContent = line;
        result.appendChild(p);
    }

    function decodeText(text) {
        let newText = '';

        for (let i = 0; i < text.length; i++) {
            let ch = text[i].toLowerCase();
            let specialSymbol = decodeObjSymbols[ch];

            if (specialSymbol !== undefined) {
                newText += specialSymbol;

                continue;
            }

            newText += ch;
        }

        return newText;
    }

    function checkIfAllLettersAreCapital(text) {
        for (let i = 0; i < text.length; i++) {
            let ch = text[i];

            if (ch.toUpperCase() !== ch) {
                return false;
            }
        }

        return true;
    }
}