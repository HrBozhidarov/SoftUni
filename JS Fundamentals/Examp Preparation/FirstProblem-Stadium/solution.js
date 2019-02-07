function solve() {
    let profit = 0;
    let fans = 0;
    let output = document.getElementById('output');
    let summaryResult = document.querySelector('#summary > span');

    document.querySelector('#summary > button').addEventListener('click', summary);

    Array.from(document.querySelectorAll('tbody > tr > td:nth-child(1)'))
         .forEach((x) => {
             x.addEventListener('click',sectorA)
         });

    Array.from(document.querySelectorAll('tbody > tr > td:nth-child(2)'))
        .forEach((x) => {
            x.addEventListener('click',sectorB)
        });

    Array.from(document.querySelectorAll('tbody > tr > td:nth-child(3)'))
        .forEach((x) => {
            x.addEventListener('click',sectorC)
        });

    function sectorC(e) {
        let target = e.target;

        if(takeSeat(target,'C')) {
            profit += getPrice(target,'C');
        }
    }

    function sectorB(e) {
        let target = e.target;

        if(takeSeat(target,'B')) {
            profit += getPrice(target,'B');
        }
    }

    function sectorA(e) {
        let target = e.target;

        if(takeSeat(target,'A')) {
            profit += getPrice(target,'A');
        }
    }

    function takeSeat(target,sector) {
        let section = getSection(target);
        let seatNumber = target.textContent;

        if(target.getAttribute('style') == 'background: rgb(255, 0, 0);') {
            output.value +=` Seat ${seatNumber} in zone ${section} sector ${sector} is unavailable.\n`;

            return false;
        }

        fans++;
        output.value +=` Seat ${seatNumber} in zone ${section} sector ${sector} was taken.\n`;
        target.style.background = 'rgb(255,0,0)';

        return true;
    }

    function getPrice(target,sector) {
        let section = getSection(target);
        let price;

        if(section === 'Litex' || section === 'Levski') {
            switch (sector) {
                case 'A': price = 10; break;
                case 'B': price = 7; break;
                case 'C': price = 5; break;
            }
        }

        switch (section+sector) {
            case 'VIPA': price = 25; break;
            case 'VIPB': price = 15; break;
            case 'VIPC': price = 10; break;
        }

        return price;
    }

    function getSection(target) {
        return target.parentElement
            .parentElement
            .parentElement
            .parentElement
            .parentElement
            .getAttribute('class');
    }

    function summary(e) {
        summaryResult.textContent = `${profit} leva, ${fans} fans.`
    }
}