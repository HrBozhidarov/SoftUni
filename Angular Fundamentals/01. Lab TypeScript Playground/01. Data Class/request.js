var HttpRequest = /** @class */ (function () {
    function HttpRequest(method, uri, version, message) {
        var _this = this;
        this.response = undefined;
        this.fulfilled = false;
        this.toString = function () {
            var obj = { method: _this.method,
                uri: _this.uri,
                version: _this.version,
                message: _this.message,
                response: _this.response,
                fulfilled: _this.fulfilled };
            return JSON.stringify(obj, null, 2);
        };
        this.method = method;
        this.uri = uri;
        this.version = version;
        this.message = message;
    }
    return HttpRequest;
}());
var myData = new HttpRequest('GET', 'http://google.com', 'HTTP/1.1', '');
console.log(myData.toString());
