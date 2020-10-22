using System;
using System.Collections.Generic;
using System.Text;
using ConsoleCalculator.Interfaces;
using ConsoleCalculator.CalculatorOperations;

namespace ConsoleCalculator.Factories
{
    public class OperatorFactory
    {
        Dictionary<char, ICalculatorOperation> Operations = new Dictionary<char, ICalculatorOperation>()
        {
            { CommonFunctions.Common.Addition, new Addition()},
            { CommonFunctions.Common.Subtraction, new Subtraction()},
            { CommonFunctions.Common.Multiplication, new Multiplication()},
            { CommonFunctions.Common.Division, new Division()}
        };

        public ICalculatorOperation GetOperation(char operation)
        {
            return Operations[Char.ToUpper(operation)];
        }
    }
}
