abstract class Employ {
    public name: string;
    public age: number;
    public salary: number;
    public tasks: Array<string>;

    constructor(name: string, age: number) {
        this.name = name;
        this.age = age;
        this.salary = 0;
        this.tasks = [];
    }

    public work(): void {
        const currentTask = this.tasks.shift();
        this.tasks.push(currentTask);

        console.log(this.name + currentTask)
    }

    public collectSalary(): void {
        console.log(this.name + `received ${this.getSelary()} this month.`)
    }

    public getSelary(): number {
        return this.salary;
    } 
}

export class Junior extends Employ {
    constructor(name: string, age: number) {
        super(name, age)
        this.tasks.push(`${name} is working on the simple task.`)
    }
}

export class Senior extends Employ {
    constructor(name: string, age: number) {
        super(name, age)
        this.tasks.push(`${name} is working on a complicated task.`);
        this.tasks.push(`${name} is taking time off work.`);
        this.tasks.push(`${name} is supervising junior workers.`);
    }
}

export class Manager extends Employ {
    public divident: number;

    constructor (name: string, age: number) {
        super(name, age);
        this.divident = 0;
        this.tasks.push(`${name} is working on a complicated task.`);
        this.tasks.push(`${name} is taking time off work.`);
    }

    public getSelary(): number {
        return this.salary + this.divident;
    }
}