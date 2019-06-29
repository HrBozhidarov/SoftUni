class Box<T> {
    private boxs: Array<T>

    constructor() {
        this.boxs = [];
    }

    public add(element: T): void {
        this.boxs.push(element);
    }

    public remove(): void {
        this.boxs.pop();
    }

    public get count() {
        return this.boxs.length;
    }
}

let box = new Box<String>();
box.add("Pesho");
box.add("Gosho");
console.log(box.count);
box.remove();
console.log(box.count);
