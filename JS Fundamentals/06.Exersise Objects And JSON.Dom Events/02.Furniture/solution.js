function solve() {
    let elementsInMainDiv = document.querySelector('#exercise').children;
    let result = document.getElementById('furniture-list');

    elementsInMainDiv[2].addEventListener('click', genereteFurnitures);
    elementsInMainDiv[5].addEventListener('click', buyFurnitures);

    function buyFurnitures() {
        let children = Array.from(result.children).filter(x => x.lastChild.checked);
        let totalPrice = 0;
        let averageFactor = 0;
        let furnituresNames = [];

        if (children.length <= 0) {
            return;
        }

        for (let child of children) {
            let childrenValues = child.children;
            let furnitureName = childrenValues[0].textContent.split(' ')[1];
            furnituresNames.push(furnitureName);
            totalPrice += Number(childrenValues[2].textContent.split(' ')[1]);
            averageFactor += Number(childrenValues[3].textContent.split(' ')[2]);
        }

        averageFactor = averageFactor / furnituresNames.length;

        document.getElementsByTagName('textarea')[1].value += `Bought furniture: ${furnituresNames.join(', ')}\n`;
        document.getElementsByTagName('textarea')[1].value += `Total price: ${totalPrice.toFixed(2)}\n`;
        document.getElementsByTagName('textarea')[1].value += `Average decoration factor: ${averageFactor}`;
    }

    function genereteFurnitures() {
        let furnituresArr = JSON.parse(document.getElementsByTagName('textarea')[0].value);

        furnituresArr.forEach(furniture => {
            let div = document.createElement('div');
            div.setAttribute('class', 'furniture');

            div.appendChild(createP(`Name: ${furniture['name']}`));

            let img = document.createElement('img');
            img.setAttribute('src', furniture['img']);
            div.appendChild(img);

            div.appendChild(createP(`Price: ${furniture['price']}`));
            div.appendChild(createP(`Decoration factor: ${furniture['decFactor']}`));

            let checkBox = document.createElement('input');
            checkBox.setAttribute('type', 'checkbox');
            div.appendChild(checkBox);

            result.appendChild(div);
        });

        function createP(content) {
            let p = document.createElement('p');
            p.textContent = content;

            return p;
        }
    }
}