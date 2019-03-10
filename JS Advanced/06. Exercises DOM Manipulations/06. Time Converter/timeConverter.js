function attachEventsListeners() {
    let daysInput = $('#days');
    let hoursInput = $('#hours');
    let minutesInput = $('#minutes');
    let secondsInput = $('#seconds');

    $('#daysBtn').on('click', days);
    $('#hoursBtn').on('click', hours);
    $('#minutesBtn').on('click', minutes);
    $('#secondsBtn').on('click', seconds);

    function days(e) {
        let daysValue = Number(daysInput.val());
        let hoursValue = daysValue * 24;
        let minutesValue = hoursValue * 60;
        let secondsValue = minutesValue * 60;

        fieldInputs(daysValue, hoursValue, minutesValue, secondsValue);
    }

    function hours(e) {
        let hoursValue = Number(hoursInput.val());
        let daysValue = hoursValue / 24;
        let minutesValue = hoursValue * 60;
        let secondsValue = minutesValue * 60;

        fieldInputs(daysValue, hoursValue, minutesValue, secondsValue);
    }

    function minutes(e) {
        let minutesValue = Number(minutesInput.val());
        let hoursValue = minutesValue / 60;
        let daysValue = hoursValue / 24;
        let secondsValue = minutesValue * 60;

        fieldInputs(daysValue, hoursValue, minutesValue, secondsValue);
    }

    function seconds(e) {
        let secondsValue = Number(secondsInput.val());
        let minutesValues = secondsValue / 60;
        let hoursValues = minutesValues / 60;
        let daysValues = hoursValues / 24;

        fieldInputs(daysValues, hoursValues, minutesValues, secondsValue);
    }

    function fieldInputs(days, hours, minutes, seconds) {
        daysInput.val(days);
        hoursInput.val(hours);
        minutesInput.val(minutes);
        secondsInput.val(seconds);
    }
}