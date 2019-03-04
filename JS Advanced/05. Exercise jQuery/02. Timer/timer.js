function timer() {
    let timer = null;
    let seconds = $('#seconds').eq(0);
    let minutes = $('#minutes').eq(0);
    let hours = $('#hours').eq(0);
    let counter = 0;

    $('#start-timer').on('click', startTimer);
    $('#stop-timer').on('click', stopTimer);

    function startTimer() {
        if(timer === null) {
            timer = setInterval(step, 1000);
        }
    }

    function stopTimer() {
        if(timer !== null) {
            clearInterval(timer);
            timer = null;
        }
    }

    function step() {
        counter++;

        if (counter > 59) {
            counter = 0;

            let minutesValue = Number(minutes.text()) + 1;

            if (minutesValue > 59) {
                minutesValue = 0;

                let hoursValue = Number(hours.text()) + 1;

                hours.text(hoursValue.toString().padStart(2, 0));
            }

            minutes.text(minutesValue.toString().padStart(2, 0));
        }

        seconds.text(counter.toString().padStart(2, 0));
    }
}