const assert = require('chai').assert;
const lookupChar = require('../03. Char Lookup');

let str;

describe('lookupChar', function () {
    beforeEach(function () {
        str = 'some string';
    });

    it('have to return correct result', function () {
        assert.equal(lookupChar(str, 0), 's');
        assert.equal(lookupChar(str, str.length - 1), 'g');
    });

    it('if parameters are invalid return undefined', function () {
        assert.isUndefined(lookupChar({}, 0));
        assert.isUndefined(lookupChar([], 0));
        assert.isUndefined(lookupChar(0, 0));
        assert.isUndefined(lookupChar(null, 0));
        assert.isUndefined(lookupChar(undefined, 0));
        assert.isUndefined(lookupChar(str, {}));
        assert.isUndefined(lookupChar(str, []));
        assert.isUndefined(lookupChar(str, null));
        assert.isUndefined(lookupChar(str, undefined));
        assert.isUndefined(lookupChar(str, 'pesho'));
        assert.isUndefined(lookupChar(str, '1'));
        assert.isUndefined(lookupChar(str, 1.14));
    });

    it('if second parameter is out of range return message', function () {
        let firstParameter = 'some string';

        assert.equal(lookupChar(firstParameter, -1), 'Incorrect index');
        assert.equal(lookupChar(firstParameter, firstParameter.length), 'Incorrect index');
        assert.equal(lookupChar('', 0), 'Incorrect index');
    });
});
