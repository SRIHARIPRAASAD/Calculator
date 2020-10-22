using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace ConsoleCalculator.CommonFunctions
{
    public static class Utility
    {
        public static KeyPressed GetKeyType(char key)
        {
            if (IsNumber(key))
                return KeyPressed.Number;
            else if (IsOperation(key))
                return KeyPressed.Operator;
            else if (key.ToString().Equals("s", StringComparison.OrdinalIgnoreCase))
                return KeyPressed.Sign;
            else if (key.ToString().Equals("c", StringComparison.OrdinalIgnoreCase))
                return KeyPressed.Clear;
            else if (key.Equals('.'))
                return KeyPressed.Decimal;
            else if (key.Equals('='))
                return KeyPressed.Equals;

            return KeyPressed.Undefined;
        }

        public static bool IsNumber(char digit)
        {
            return new Regex(@"[0-9]").IsMatch(digit.ToString());
        }

        public static bool IsOperation(char operation)
        {
            return new Regex(@"[+\-Xx\/]").IsMatch(operation.ToString());
        }
    }
}
