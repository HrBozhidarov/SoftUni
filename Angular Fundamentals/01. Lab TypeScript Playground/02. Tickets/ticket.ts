class Ticket {
    constructor(private tickets: Array<string>, private sortBy: string) {

    }

    toString() {
        var result = [];

        this.tickets.forEach(x => {
            let arr = x.split('|');
            let currentTicket = {
                   "destination": arr[0],
                   "price": Number(arr[1]),
                   "status": arr[2]
            };
            
            result.push(currentTicket);
           });

        if (this.sortBy === 'status') {
            return result.sort((a, b) => sortBy(a, b, 'status')).map(x => {
                return 'Ticket ' + `{ destination: "${x.destination}", price: "${x.price}", status: "${x.status}" }`
            });
        }
        else if (this.sortBy === 'price') {
            return result.sort((a, b) => sortBy(a, b, 'price')).map(x => {
                return 'Ticket ' + `{ destination: "${x.destination}", price: "${x.price}", status: "${x.status}" }`
            });
        }
        else {
            return result.sort((a, b) => sortBy(a, b, 'destination')).map(x => {
                return 'Ticket ' + `{ destination: "${x.destination}", price: "${x.price}", status: "${x.status}" }`
            });
        }

        function sortBy(objA: object, objB: object,property: string): number {
            if (objA[property] < objB[property]) {
                return -1;
            }
            
            if (objA[property] > objB[property]) {
                return 1;
            }
           
            return 0;          
        }
    }
}

var ticket = new Ticket(["Philadelphia|94.20|available",
"New York City|95.99|available",
"New York City|95.99|sold",
"Boston|126.20|departed"],
"status");

console.log(ticket.toString());