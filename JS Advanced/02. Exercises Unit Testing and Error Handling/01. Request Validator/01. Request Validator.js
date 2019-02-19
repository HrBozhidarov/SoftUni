function validateRequest(request) {
    let validMethods = ["GET", "POST", "DELETE", "CONNECT"];
    let validVersion = ["HTTP/0.9", "HTTP/1.0", "HTTP/1.1", "HTTP/2.0"];

    if (!request['method'] || !validMethods.includes(request['method'])) {
        throw new Error("Invalid request header: Invalid Method");
    }

    if (!request['uri'] || !checkIfProperyValueIsValid(/^[\w.]+$/, [request['uri']])) {
        throw new Error(`Invalid request header: Invalid URI`);
    }

    if (!request['version'] || !validVersion.includes(request.version)) {
        throw new Error("Invalid request header: Invalid Version");
    }

    if (!request.hasOwnProperty('message') || !checkIfProperyValueIsValid(/^[^<>\\&'"]*$/, [request['message']])) {
        throw new Error(`Invalid request header: Invalid Message`);
    }

    return request;

    function checkIfProperyValueIsValid(regex, message) {
        if (regex.test(message)) {
            return true;
        }

        return false;
    }
}

let obj = {
    method: 'POST',
    uri: 'home.bash',
    version: 'HTTP/2.0'
};

validateRequest(obj);