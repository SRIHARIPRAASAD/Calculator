using System;
using System.Text;
using ConsoleCalculator.CommonFunctions;
using ConsoleCalculator.Factories;
using ConsoleCalculator.Interfaces;

namespace ConsoleCalculator
{
    public class Calculator
    {
        double result = 0;
        const string calcErrorMessage = "-E-";
        bool isResultUpdated = false;
        bool isOperandConsumed = false;

        StringBuilder operand;
        ICalculatorOperation operation;
        OperatorFactory operatorFactory;

        public Calculator()
        {
            operand = new StringBuilder();
            operation = null;
            operatorFactory = new OperatorFactory();
        }

        public string SendKeyPress(char key)
        {
            try
            {
                KeyPressed keyType = Utility.GetKeyType(key);
                switch (keyType)
                {
                    case KeyPressed.Number:
                        HoldNumberValue(key);
                        return operand.ToString();

                    case KeyPressed.Decimal:
                        HoldDecimalPointValue(key);
                        return operand.ToString();

                    case KeyPressed.Sign:
                        ChangeOperandsSign();
                        return operand.ToString();

                    case KeyPressed.Operator:
                        HoldOperatorSymbol(key);
                        return result.ToString();

                    case KeyPressed.Equals:
                        CalculateOperationResultant();
                        return result.ToString();

                    case KeyPressed.Clear:
                        ResetToDefaults();
                        return result.ToString();

                    default:
                        return result.ToString(); 

                }
            }
            catch (DivideByZeroException ex)
            {
                ResetToDefaults();
                return "Cannot divide by zero";
            }
            catch (Exception ex)
            {
                ResetToDefaults();
                return calcErrorMessage;                
            }              
        }

        private void ResetToDefaults()
        {
            result = 0;
            operand.Clear();
            operation = null;
            isResultUpdated = false;
            isOperandConsumed = false;
        }

        private void ChangeOperandsSign()
        {
            if (double.TryParse(operand.ToString(), out double temp))
            {
                operand.Clear();
                operand.Append((-1 * temp).ToString());
            }
        }
        private void CalculateOperationResultant()
        {
            if (operation != null)
            {
                if (operand.Length > 0)
                    result = operation.Operate(result, Convert.ToDouble(operand.ToString()));
            }
        }

        private void HoldOperatorSymbol(char key)
        {
            if (operation != null && isResultUpdated)
                result = operation.Operate(result, Convert.ToDouble(operand.ToString()));
            else
                result = Convert.ToDouble(operand.ToString());

            operation = operatorFactory.GetOperation(key);

            operand.Clear().Append(result.ToString());
            isOperandConsumed = true;
            isResultUpdated = true;
        }

        private void HoldDecimalPointValue(char key)
        {
            if (!operand.ToString().Contains(key.ToString()))
                operand.Append(key);
        }

        private void HoldNumberValue(char key)
        {
            if (isOperandConsumed)
            {
                operand.Clear();
                isOperandConsumed = false;
            }

            operand.Append(key);
            double.TryParse(operand.ToString(), out double temp);
            operand.Clear().Append(temp.ToString());
        }
    }
}
