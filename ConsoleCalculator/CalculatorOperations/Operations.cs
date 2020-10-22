using System;
using System.Collections.Generic;
using System.Text;
using ConsoleCalculator.Interfaces;

namespace ConsoleCalculator.CalculatorOperations
{
    class Addition : ICalculatorOperation
    {
        public char Operation { get { return '+'; } }

        public double Operate(double operand1, double operand2)
        {
            return operand1 + operand2;
        }
    }

    class Subtraction : ICalculatorOperation
    {
        public char Operation { get { return '-'; } }

        public double Operate(double operand1, double operand2)
        {
            return operand1 - operand2;
        }
    }

    class Multiplication : ICalculatorOperation
    {
        public char Operation { get { return 'X'; } }

        public double Operate(double operand1, double operand2)
        {
            return operand1 * operand2;
        }
    }

    class Division : ICalculatorOperation
    {
        public char Operation { get { return '/'; } }

        public double Operate(double operand1, double operand2)
        {
            if (operand2 == 0)
                throw new DivideByZeroException();

            return operand1 / operand2;
        }
    }
}
