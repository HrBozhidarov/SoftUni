function solve() {
    let passengerPattern = (/( [A-Z][A-Za-z]*-[A-Z][A-Za-z]* | [A-Z][A-Za-z]*-[A-Z][A-Za-z]*\.-[A-Z][A-Za-z]* )/g);
    let airportPattern = (/( [A-Z]{3}\/[A-Z]{3} )/g);
    let flightNumberPattern = (/( [A-Z]{1,3}[0-9]{1,5} )/g);
    let companyPattern = (/(- [A-Z][a-z]*\*[A-Z][a-z]* )/g);
    let inputSplit = document.getElementById('str').value.split(', ');
    let result = document.getElementById('result');
    let text = inputSplit[0];
    let commandPrint = inputSplit[1];
    let passengerRegex = passengerPattern.exec(text);
    let airportRegex = airportPattern.exec(text);
    let flightNumberRegex = flightNumberPattern.exec(text);
    let companyRegex = companyPattern.exec(text);

    let passenger = passengerRegex !== null
        ? passengerRegex[1].trim().replace(/-/g,' ') : null;

    let airport = airportRegex !== null
        ? airportRegex[1].split('/').map(x=>x.trim()) : null;

    let flightNumber = flightNumberRegex !== null
        ? flightNumberRegex[1].trim() : null;

    let company = companyRegex !== null
        ? companyRegex[1].replace(/\*/g,' ').replace(/- /g,'').trim() : null;

    switch (commandPrint) {
        case 'all': result.textContent=`Mr/Ms, ${passenger}, your flight number ${flightNumber} is from ${airport[0]} to ${airport[1]}. Have a nice flight with ${company}.`; break;
        case 'name': result.textContent = `Mr/Ms, ${passenger}, have a nice flight!`; break;
        case 'flight': result.textContent = `Your flight number ${flightNumber} is from ${airport[0]} to ${airport[1]}.`; break;
        case 'company': result.textContent = `Have a nice flight with ${company}.`; break;
    }
}