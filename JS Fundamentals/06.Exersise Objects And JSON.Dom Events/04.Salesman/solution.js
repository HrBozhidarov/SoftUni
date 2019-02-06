function solve() {
    let objs = [];
    let profited = 0;

    let textareas = Array.from(document.querySelectorAll('textarea'));
    let loadInput = textareas[0];
    let logInput = textareas[2];
    let buyInput = textareas[1];

    let buttons = Array.from(document.querySelectorAll('button'));
    let loadButton = buttons[0];
    let buyButton = buttons[1];
    let endButton = buttons[2];

    loadButton.addEventListener('click', load);
    buyButton.addEventListener('click', buy);
    endButton.addEventListener('click', end);

    function end() {
        logInput.value += `Profit: ${profited.toFixed(2)}.\n`;

        loadButton.removeEventListener('click',load);
        buyButton.removeEventListener('click',buy);
        endButton.removeEventListener('click',end);
    }

    function buy(e) {
        let buyObj = JSON.parse(buyInput.value);
        let objFromObjArr = objs.find(x => x['name'] === buyObj['name']);

        if (!objFromObjArr || objFromObjArr['quantity'] === 0) {
            logInput.value += `Cannot complete order.\n`;
        }

        if (objFromObjArr['quantity'] >= buyObj['quantity']) {
            objFromObjArr['quantity'] -= buyObj['quantity'];

            let currentProfited = buyObj['quantity'] * objFromObjArr['price'];

            profited += currentProfited;

            logInput.value += `${buyObj['quantity']} ${buyObj['name']} sold for ${currentProfited}.\n`;
        }
        else {
            logInput.value += `Cannot complete order.\n`;
        }
    }

    function load(e) {
        let currentObjs = JSON.parse(loadInput.value);

        for (let obj of currentObjs) {
            let existsObj = objs.find(x => obj['name'] === x['name']);

            if (existsObj === undefined) {
                existsObj = {
                    'name': obj['name'],
                    'quantity': obj['quantity'],
                    'price': obj['price']
                };

                objs.push(existsObj);
            }
            else {
                existsObj['quantity'] += obj['quantity'];
                existsObj['price'] = obj['price'];
            }

            logInput.value += `Successfully added ${obj['quantity']} ${obj['name']}. Price: ${obj['price']}\n`
        }
    }
}