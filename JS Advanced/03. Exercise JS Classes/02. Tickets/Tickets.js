function solve(arr, sortetParameter) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }

    let result = [];

    arr.forEach(line => {
        let data = line.split('|');
        result.push(new Ticket(data[0],data[1],data[2]));
    });
    
    result.sort((a,b) => {
        if(a[sortetParameter] > b[sortetParameter]) {
            return 1;
        }

        if(a[sortetParameter] > b[sortetParameter]) {
            return 1;
        }

        return 0;
    });

    return result;
}

console.log(solve(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination'
));