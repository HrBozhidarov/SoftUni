class HttpRequest {
    private method: string;
    private uri: string;
    private version: string;
    private message: string;
    private response: string = undefined;
    private fulfilled: boolean = false;

    constructor(method: string, uri: string, version: string, message: string) {
        this.method = method;
        this.uri = uri;
        this.version = version;
        this.message = message;
    }

    toString = () : string => {
        let obj = 
            { method: this.method,
                uri: this.uri,
                version: this.version,
                message: this.message,
                response: this.response,
                fulfilled: this.fulfilled }

        return JSON.stringify(obj, null, 2);
    }
}


let myData = new HttpRequest('GET', 'http://google.com', 'HTTP/1.1', '');

console.log(myData.toString());