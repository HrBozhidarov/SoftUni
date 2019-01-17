function fittnesRate(day,offerd,hour) {
    switch(offerd){
        case 'Fitness':
            console.log(getPrice(day,5,7.5,8,hour));
            break;
        case 'Sauna':
            console.log(getPrice(day,4,6.5,7,hour));
            break;
        case 'Instructor':
            console.log(getPrice(day,10,12.5,15,hour));
            break;
    }

    function getPrice(day,firstPrice,secondPrice,sundSatPrice,hour) {
        let price = 0;

        if(day=='Saturday' || day=='Sunday') {
            price = sundSatPrice;
        }
        else {
            price= Number(hour) <= 15.00 ? firstPrice : secondPrice;
        }

        return price;
    }
}

fittnesRate('Sunday', 'Fitness', 22.00);