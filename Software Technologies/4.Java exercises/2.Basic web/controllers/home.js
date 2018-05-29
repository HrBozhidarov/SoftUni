const Calculator = require('../models/Calculator');

module.exports = {
    indexGet: (req, res) => {
        res.render('home/index');
    },
    indexPost: (req, res) => {
        let calculatorBody = req.body;
        let calculatorParams = calculatorBody['calculator'];

        let calculator=new Calculator(calculatorParams.leftOperand,calculatorParams.operator,calculatorParams.rightOperand);
        let result=calculator.calculateResult();

        res.render('home/index', {'calculator':calculator, 'result':result })
    }
};