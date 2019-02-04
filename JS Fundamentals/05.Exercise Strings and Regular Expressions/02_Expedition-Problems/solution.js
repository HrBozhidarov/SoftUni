function solve() {
    let startAndEndSymbol = document.getElementById('str').value;
    let result = document.getElementById('result');
    let text = document.getElementById('text').value;
    let messageRegex = new RegExp(`${startAndEndSymbol}(.+?)${startAndEndSymbol}`, "gim");
    let regex = new RegExp(`(east|north).*?(\\d{2})[^,]*?,[^,]*?(\\d{6})`, "gim");
    let saveCoordinate = {};
    let r;

    while ((r = regex.exec(text)) !== null) {
        if(r[1].toLowerCase() === 'east') {
            saveCoordinate['e'] = `${r[2]}.${r[3]} E`
        }
        else {
            saveCoordinate['n'] = `${r[2]}.${r[3]} N`
        }
    }

    createAndAppendToResult(saveCoordinate['n']);
    createAndAppendToResult(saveCoordinate['e']);
    createAndAppendToResult('Message: ' + messageRegex.exec(text)[1]);

    function createAndAppendToResult(content) {
        let p = document.createElement('p');
        p.textContent = content;
        result.appendChild(p);
    }
}