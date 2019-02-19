const assert = require('chai').assert;
const isOddOrEven = require('../02. Even or Odd');

describe('isOddOrEven',function () {
    it('return even if length is even',function () {
        let input = 'even';

        let result = isOddOrEven(input);

        assert.equal(result,'even')
    });
    it('return odd if length is odd',function () {
        let input = 'odd';

        let result = isOddOrEven(input);

        assert.equal(result,'odd')
    });
   it('return undefined if pass parameter is diffrence from string',function () {
        assert.isUndefined(isOddOrEven(1));
        assert.isUndefined(isOddOrEven(null));
        assert.isUndefined(isOddOrEven({}));
        assert.isUndefined(isOddOrEven([]));
   });
});
