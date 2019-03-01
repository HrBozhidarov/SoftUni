class SortedList {
    constructor() {
        this.size = 0;
        this.elements = [];
    }

    add(element) {
        this.elements.push(element);

        this.elements.sort((a,b) => a - b);

        this.size++;
    }

    remove(index) {
        if(index < 0 || index >= this.elements.length) {
            throw new Error();
        }

        let element = this.elements[index];

        this.elements.splice(index, 1);
        this.size --;
        
        return element;
    }

    get(index) {
        if(index < 0 || index >= this.elements.length) {
            throw new Error();
        }

        return this.elements[index];
    }

}

var myList = new SortedList();

var expectedArray = [];
for (let i = 0; i < 20; i++) {
    expectedArray.push(Math.floor(Math.random() * 200) - 100);
}

for (let i = 0; i < expectedArray.length; i++) {
    myList.add(expectedArray[i]);
}

expectedArray.sort((a, b) => a - b);

for (let i = 0; i < expectedArray.length; i++) {
    console.log(myList.get(i) + '=>' + expectedArray[i]);
}