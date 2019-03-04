(function stringExtension() {
    String.prototype.ensureStart = function (str) {
        if (this.startsWith(str)) {
            return this.toString();
        }

        return `${str}${this.toString()}`;
    };

    String.prototype.ensureEnd = function (str) {
        if (this.endsWith(str)) {
            return this.toString();
        }

        return `${this.toString()}${str}`;
    };

    String.prototype.isEmpty = function () {
        return this.length === 0;
    };

    String.prototype.truncate = function (n) {
        let str = this.toString();

        if (str.length < 4) {
            return '.'.repeat(n);
        }

        if (str.length <= n) {
            return str;
        }

        let index = str.substr(0, n - 2).lastIndexOf(' ');

        if (index < 0) {
            return str.substr(0, n - 3) + '...';
        }

        return str.substr(0, index) + '...';
    };

    String.format = function (template, ...params) {
        for (let i = 0; i < params.length; i++) {
            template = template.replace(`{${i}}`, params[i]);
        }

        return template;
    };
})();