<?php
namespace CalculatorBundle\Entity;

class Calculator
{
    /**
     * @var float
     */
    private $leftOperand;

    /**
     * @var float
     */
    private $rightOperand;

    /**
     * @var string
     */
    private $operator;

    /**
     * @return string
     */
    public function getOperator()
    {
        return $this->operator;
    }

    /**
     * @param string $operator
     */
    public function setOperator(string $operator)
    {
        $this->operator = $operator;
    }

    /**
     * @return float
     */
    public function getRightOperand()
    {
        return $this->rightOperand;
    }

    /**
     * @param float $rightOperand
     */
    public function setRightOperand(float $rightOperand)
    {
        $this->rightOperand = $rightOperand;
    }

    /**
     * @return float
     */
    public function getLeftOperand()
    {
        return $this->leftOperand;
    }

    /**
     * @param float $leftOperand
     */
    public function setLeftOperand(float $leftOperand)
    {
        $this->leftOperand = $leftOperand;
    }

}