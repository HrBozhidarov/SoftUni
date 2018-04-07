package com.softuni.entity;

public class Calculator {
    private double leftOperand;
    private double rightOperand;
    private String operator;

    public Calculator(double leftOperand, double rightOperand, String operator) {
        this.leftOperand = leftOperand;
        this.rightOperand = rightOperand;
        this.operator = operator;
    }

    public double getLeftOperand() {
        return this.leftOperand;
    }

    public void setLeftOperand(double leftOperand) {
        this.leftOperand = leftOperand;
    }

    public double getRightOperand() {
        return this.rightOperand;
    }

    public void setRightOperand(double rightOperand) {
        this.rightOperand = rightOperand;
    }

    public String getOperator() {
        return this.operator;
    }

    public void setOperator(String operator) {
        this.operator = operator;
    }

    public double calculateResult() {
        double result = 0;

        switch (this.operator) {
            case "+": result = this.leftOperand + this.rightOperand; break;
            case "-": result = this.leftOperand - this.rightOperand; break;
            case "*": result = this.leftOperand * this.rightOperand; break;
            case "/": result = this.leftOperand / this.rightOperand; break;
            default: result=0; break;
        }

        return result;
    }
}
