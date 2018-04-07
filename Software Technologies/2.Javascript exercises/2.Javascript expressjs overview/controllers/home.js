const Calculator = require('../models/Calculator');

module.exports = {
    indexGet: (req, res) => {
        res.render('home/index');
    },
    indexPost: (req, res) => {
        let data = req.body['calculator'];
        let right = Number(data.rightOperand);
        let operator = data.operator;
        let left = Number(data.leftOperand);

        let calculator = new Calculator(left,operator,right);
        let result=calculator.calculateResult();

        res.render('home/index',{'calculator':calculator,'result':result});
    }
};