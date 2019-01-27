function leapYear() {
    let input = document.querySelector('#main input[type="number"]');
    let h2 = document.querySelector('#year h2');

    document.querySelector('#main button').addEventListener('click',function (e) {
        let divForYear = h2.nextElementSibling;

       if(leapYear(input.value)) {
            h2.textContent = 'Leap Year';
       }
       else {
           h2.textContent = 'Not Leap Year';
       }

       divForYear.textContent = input.value;
       input.value = '';
    });

    function leapYear(year)
    {
        return ((year % 4 === 0) && (year % 100 !== 0)) || (year % 400 === 0);
    }
}