var Ticket = /** @class */ (function () {
    function Ticket(tickets, sortBy) {
        this.tickets = tickets;
        this.sortBy = sortBy;
    }
    Ticket.prototype.toString = function () {
        var result = [];
        this.tickets.forEach(function (x) {
            var arr = x.split('|');
            var currentTicket = {
                "destination": arr[0],
                "price": Number(arr[1]),
                "status": arr[2]
            };
            result.push(currentTicket);
        });
        if (this.sortBy === 'status') {
            return result.sort(function (a, b) { return sortBy(a, b, 'status'); }).map(function (x) {
                return 'Ticket ' + ("{ destination: \"" + x.destination + "\", price: \"" + x.price + "\", status: \"" + x.status + "\" }");
            });
        }
        else if (this.sortBy === 'price') {
            return result.sort(function (a, b) { return sortBy(a, b, 'price'); }).map(function (x) {
                return 'Ticket ' + ("{ destination: \"" + x.destination + "\", price: \"" + x.price + "\", status: \"" + x.status + "\" }");
            });
        }
        else {
            return result.sort(function (a, b) { return sortBy(a, b, 'destination'); }).map(function (x) {
                return 'Ticket ' + ("{ destination: \"" + x.destination + "\", price: \"" + x.price + "\", status: \"" + x.status + "\" }");
            });
        }
        function sortBy(objA, objB, property) {
            if (objA[property] < objB[property]) {
                return -1;
            }
            if (objA[property] > objB[property]) {
                return 1;
            }
            return 0;
        }
    };
    return Ticket;
}());
var ticket = new Ticket(["Philadelphia|94.20|available",
    "New York City|95.99|available",
    "New York City|95.99|sold",
    "Boston|126.20|departed"], "status");
console.log(ticket.toString());
