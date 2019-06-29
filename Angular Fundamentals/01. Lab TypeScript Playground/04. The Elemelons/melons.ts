abstract class Melon {
    public weigth: number;
    public melonSort: string;
    protected element: string;

    constructor(weigth: number, melonSort: string){
        this.weigth = weigth;
        this.melonSort = melonSort;
    }

    public get elementIndex(): number {
        return this.weigth * this.melonSort.length;
    }

    public toString(): string {
        return `Element: ${this.element}\n` +
        `Sort: ${this.melonSort}\n` +
        `Element Index: ${this.elementIndex}`;
        
    }
}

class Watermelon extends Melon {
    constructor(weigth: number, melonSort: string) {
        super(weigth, melonSort);
        this.element = 'Watermelon';
    }
}

class Firemelon extends Melon {
    constructor(weigth: number, melonSort: string) {
        super(weigth, melonSort);
        this.element = 'Firemelon';
    }
}

class Earthmelon extends Melon {
    constructor(weigth: number, melonSort: string) {
        super(weigth, melonSort);
        this.element = 'Earthmelon';
    }
}

class Airmelon extends Melon {
    constructor(weigth: number, melonSort: string) {
        super(weigth, melonSort);
        this.element = 'Airmelon';
    }
}

class Melolemonmelon {
    private melon : Melon
    private index: number;
    private melons : Array<Melon>

    constructor (weigth: number, melonSort: string) {
        this.melon = new Watermelon(weigth, melonSort);
        this.melons = [];
        this.melons.push(new Watermelon(weigth, melonSort));
        this.melons.push(new Firemelon(weigth, melonSort));
        this.melons.push(new Earthmelon(weigth, melonSort));
        this.melons.push(new Airmelon(weigth, melonSort));
        this.index = 0;
    }

    public morph(): Melon {
        this.index++;

        if (this.index === this.melons.length) {
            this.index = 0;
        }
        
        this.melon = this.melons[this.index];

        return this.melon;
    }

    public toString() {
        return this.melon.toString();
    }
}

var melon = new Melolemonmelon(23, 'cato');

console.log(melon.toString());
melon.morph();
console.log(melon.toString());
melon.morph();
console.log(melon.toString());
melon.morph();
console.log(melon.toString());
