function timeToWalk(steps,footprint,speedKm) {
    let distanceInMeters = +steps * +footprint;
    let addMinutes = Math.floor(distanceInMeters/500);
    let distanceInKm = distanceInMeters/1000;
    let time = distanceInKm/speedKm;
    let hoursAndMinutes = (time).toString().split('.');
    let hours = +hoursAndMinutes[0];
    let minutesSecons = (time * 60).toString().split('.');
    let minutes = +minutesSecons[0] + addMinutes;
    let seconds = Math.round(+('0.'+minutesSecons[1])*60);

    console.log(`${pad(hours)}:${pad(minutes)}:${pad(seconds)}`);

    function pad(n) { return ("00" + n).slice(-2); }
}

timeToWalk(2564, 0.70, 5.5);