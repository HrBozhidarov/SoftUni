class CheckingAccount  {
    constructor(clientId,email,firstName,lastName) {
        this.clientId = clientId;
        this.email = email;
        this.firstName = firstName;
        this.lastName = lastName;
    }

    get clientId() {
        return this._clientId;
    }

    set clientId(clientId) {
        let pattern = /[0-9]{6}/gm
        let isValid = pattern.test(clientId);

        if(!isValid || clientId.length > 6) {
            throw new TypeError('Client ID must be a 6-digit number');
        }

        this._clientId = clientId;
    }

    get email() {
        return this._email;
    }

    set email(email) {
        let pattern = /\w+@[a-z\.]+/gm
        let isValid = pattern.test(email);

        if(!isValid) {
            throw new TypeError('Invalid e-mail');
        }

        this._email = email;
    }

    get firstName() {
        return this._firstName;
    }

    set firstName(firstName) {
        let pattern = /^[a-zA-Z]{3,20}$/gm
        let isValid = pattern.test(firstName);

        if(firstName.length < 3 || firstName.length > 20) {
            throw new TypeError('First name must be between 3 and 20 characters long');
        }

        if(!isValid) {
            throw new TypeError('First name must contain only Latin characters');
        }

        this._firstName = firstName;
    }

    get lastName() {
        return this._lasttName;
    }

    set lastName(lasttName) {
        let pattern = /^[a-zA-Z]{3,20}$/gm
        let isValid = pattern.test(lasttName);

        if(lasttName.length < 3 || lasttName.length > 20) {
            throw new TypeError('Last name must be between 3 and 20 characters long');
        }

        if(!isValid) {
            throw new TypeError('Last name must contain only Latin characters');
        }

        this._lasttName = lasttName;
    }
}

let acc = new CheckingAccount('131455', 'ivan@some.com', 'Ivan', 'P3trov')