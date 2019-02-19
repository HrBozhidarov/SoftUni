const assert = require('chai').assert;
const mathEnforcer = require('../04. Math Enforcer');

describe('mathEnforcer', function () {
    describe('addFive', function () {
        it('addFive should work correctly if pass integer', function () {
            let num = 5;

            let result = mathEnforcer.addFive(num);

            assert.equal(result, 10);
        });

        it('addFive should work correctly if pass float', function () {
            let num = 5.1;

            let result = mathEnforcer.addFive(num);

            assert.closeTo(result, 10.1,0.01);
        });

        it('addFive should work correctly if pass negative float', function () {
            let num = -5.1;

            let result = mathEnforcer.addFive(num);

            assert.closeTo(result, -0.1,0.01);
        });

        it('if pass parameter is not number return undefined',function () {
            assert.isUndefined(mathEnforcer.addFive(null));
            assert.isUndefined(mathEnforcer.addFive([1]));
            assert.isUndefined(mathEnforcer.addFive({}));
            assert.isUndefined(mathEnforcer.addFive('1'));
            assert.isUndefined(mathEnforcer.addFive());
        });
    });
    describe('subtractTen',function () {
        it('subtractTen have to work correctly', function () {
            let num = 15;

            let result = mathEnforcer.subtractTen(num);

            assert.equal(result, 5);
        });

        it('subtractTen should work correctly if pass negative float', function () {
            let num = -5.1;

            let result = mathEnforcer.subtractTen(num);

            assert.closeTo(result, -15.1,0.01);
        });

        it('subtractTen should work correctly if pass float', function () {
            let num = 10.1;

            let result = mathEnforcer.subtractTen(num);

            assert.closeTo(result, 0.1,0.01);
        });
        it('if pass parameter is not number return undefined',function () {
            assert.isUndefined(mathEnforcer.subtractTen(null));
            assert.isUndefined(mathEnforcer.subtractTen([1]));
            assert.isUndefined(mathEnforcer.subtractTen({}));
            assert.isUndefined(mathEnforcer.subtractTen('1'));
            assert.isUndefined(mathEnforcer.subtractTen());
        });
    });
    describe('sum',function () {
       it('sum have to work correctly',function () {
           let num1 = 5;
           let num2 = 5;

           let result = mathEnforcer.sum(num1,num2);

           assert.equal(result, 10);
       });
        it('subtractTen should work correctly if pass float', function () {
            let num1 = 10.1;
            let num2 = 5.2;

            let result = mathEnforcer.sum(num1,num2);

            assert.closeTo(result, 15.3,0.01);
        });
        it('if one of pass parameters is not number return undefined',function () {
            assert.isUndefined(mathEnforcer.sum(null,1));
            assert.isUndefined(mathEnforcer.sum([1],2));
            assert.isUndefined(mathEnforcer.sum({},3));
            assert.isUndefined(mathEnforcer.sum('1',4));
            assert.isUndefined(mathEnforcer.sum(1,{}));
            assert.isUndefined(mathEnforcer.sum(2,null));
            assert.isUndefined(mathEnforcer.sum(3,'1'));
            assert.isUndefined(mathEnforcer.sum(4,[1]));
            assert.isUndefined(mathEnforcer.sum(1));
        });
    });
});

