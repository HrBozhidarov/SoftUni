function Calculator(leftOperand, operator, rightOperand) {
    this.leftOperand = leftOperand;
    this.operator = operator;
    this.rightOperand = rightOperand;

    this.calculateResult = function () {
        let result = 0;

        switch (this.operator) {
            case '+': result = Number(this.leftOperand) + Number(this.rightOperand); break;
            case '-': result = Number(this.leftOperand) - Number(this.rightOperand); break;
            case '*': result = Number(this.leftOperand) * Number(this.rightOperand); break;
            case '/': result = Number(this.leftOperand) / Number(this.rightOperand); break;
        }

        return result;
    }
}

module.exports = Calculator;