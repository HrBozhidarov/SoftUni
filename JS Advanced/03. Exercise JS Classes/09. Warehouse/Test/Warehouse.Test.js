let assert = require('chai').assert;
let Warehouse = require('../Warehouse');

describe('Warehouse', function () {
    it('throw if pass negative number through initialize', function () {
        let throwErrIfNegativeNumber = () => new Warehouse(-1);
        let throwIfInvalidNumber = () => new Warehouse({});

        assert.throw(throwIfInvalidNumber, `Invalid given warehouse space`);
        assert.throw(throwErrIfNegativeNumber, `Invalid given warehouse space`);
    });

    it('add product have to throw exception', function () {
        let warehouse = new Warehouse(1);
        let throwErr = () => warehouse.addProduct(null, null, 2);

        assert.throw(throwErr, `There is not enough space or the warehouse is already full`);
    });

    it('add product have to work correctly', function () {
        let warehouse = new Warehouse(5);
        let result = warehouse.addProduct('Food', 'apple', 2);

        assert.equal(result['apple'], 2);
    });

    it('orderProducts have to work correctly', function () {
        let warehouse = new Warehouse(30);
        warehouse.addProduct('Food', 'apple', 2);
        warehouse.addProduct('Food', 'orange', 4);

        let result = warehouse.orderProducts('Food');
        let expect = {
            'orange': 4,
            'apple': 2,
        };

        let expectedProducts = Object.keys(expect);
        let outputProducts = Object.keys(result);

        for (let i = 0; i < expectedProducts.length; i++) {
            assert.equal(outputProducts[i],expectedProducts[i]);
        }
    });

    it('occupiedCapacity have to work correctly', function () {
        let firstWarehouse = new Warehouse(5);
        let secondWarehouse = new Warehouse(10);

        secondWarehouse.addProduct('Food', 'apple', 2);
        secondWarehouse.addProduct('Food', 'orange', 4);

        let returnZero = firstWarehouse.occupiedCapacity();
        let returnSix = secondWarehouse.occupiedCapacity();

        assert.equal(returnZero, 0);
        assert.equal(returnSix, 6);
    });

    it('revision have to work correctly', function () {
        let firstWarehouse = new Warehouse(5);
        let secondWarehouse = new Warehouse(10);
        let expectedSecondResult = 'Product type - [Food]\n' + `- apple 2\n` + 'Product type - [Drink]\n' + `- cola 4`;

        secondWarehouse.addProduct('Food', 'apple', 2);
        secondWarehouse.addProduct('Drink', 'cola', 4);
        let firstResult = firstWarehouse.revision();
        let secondResult = secondWarehouse.revision();

        assert.equal(firstResult, 'The warehouse is empty');
        assert.equal(secondResult, expectedSecondResult);
    });

    it('scrapeAProduct have to throw exception', function () {
        let warehouse = new Warehouse(5);

        warehouse.addProduct("Food", "banana", 4);
        warehouse.addProduct("Food", "apple", 1);

        let result = () => warehouse.scrapeAProduct('tomato', 1);

        assert.throw(result, 'tomato do not exists');
    });

    it('scrapeAProduct have to work correctly', function () {
        let warehouse = new Warehouse(5);
        let warehouseReset = new Warehouse(5);
        warehouse.addProduct('Food', 'apple', 2);
        warehouseReset.addProduct('Food', 'apple', 2);
        let result = warehouse.scrapeAProduct('apple', 1);
        let secondResult = warehouseReset.scrapeAProduct('apple', 3);

        assert.equal(JSON.stringify(result), '{"apple":1}');
        assert.equal(JSON.stringify(secondResult), '{"apple":0}');
    });
});
