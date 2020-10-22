using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {

        [Fact]
        public void VerifyDecimalNumber()
        {
            Calculator calc = new Calculator();
            Assert.Equal("7", calc.SendKeyPress('7'));
            Assert.Equal("7.", calc.SendKeyPress('.'));
            Assert.Equal("7.5", calc.SendKeyPress('5'));
            Assert.Equal("7.52", calc.SendKeyPress('2'));
            Assert.Equal("7.528", calc.SendKeyPress('8'));
        }

        [Fact]
        public void VerifyAdditionOfTwoNumbers()
        {
            Calculator calc = new Calculator();
            Assert.Equal("9", calc.SendKeyPress('9'));
            Assert.Equal("98", calc.SendKeyPress('8'));
            Assert.Equal("98", calc.SendKeyPress('+'));
            Assert.Equal("2", calc.SendKeyPress('2'));
            Assert.Equal("100", calc.SendKeyPress('='));
        }

        [Fact]
        public void VerifyAdditionOfTwoNumbersForNotEqual()
        {
            Calculator calc = new Calculator();
            Assert.Equal("9", calc.SendKeyPress('9'));
            Assert.Equal("98", calc.SendKeyPress('8'));
            Assert.Equal("98", calc.SendKeyPress('+'));
            Assert.Equal("2", calc.SendKeyPress('2'));
            Assert.NotEqual("101", calc.SendKeyPress('='));
        }

        [Fact]
        public void VerifySubstractionOfTwoNumbers()
        {
            Calculator calc = new Calculator();
            Assert.Equal("2", calc.SendKeyPress('2'));
            Assert.Equal("22", calc.SendKeyPress('2'));
            Assert.Equal("22", calc.SendKeyPress('-'));
            Assert.Equal("2", calc.SendKeyPress('2'));
            Assert.Equal("20", calc.SendKeyPress('='));
        }

        [Fact]
        public void VerifyMultiplicationOfTwoNumbsers()
        {
            Calculator calc = new Calculator();
            Assert.Equal("2", calc.SendKeyPress('2'));            
            Assert.Equal("2", calc.SendKeyPress('x'));
            Assert.Equal("3", calc.SendKeyPress('3'));
            Assert.Equal("6", calc.SendKeyPress('='));
        }

        [Fact]
        public void VerifyDivideTwoNumbsers()
        {
            Calculator calc = new Calculator();
            Assert.Equal("9", calc.SendKeyPress('9'));
            Assert.Equal("9", calc.SendKeyPress('/'));
            Assert.Equal("2", calc.SendKeyPress('2'));
            Assert.Equal("4.5", calc.SendKeyPress('='));
        }
        [Fact]
        public void VerifyChangeSignMultipleTimesAndDoAddition()
        {
            Calculator calc = new Calculator();

            Assert.Equal("8", calc.SendKeyPress('8'));
            Assert.Equal("-8", calc.SendKeyPress('s'));
            Assert.Equal("8", calc.SendKeyPress('s'));
            Assert.Equal("-8", calc.SendKeyPress('s'));
            Assert.Equal("-8", calc.SendKeyPress('+'));
            Assert.Equal("8", calc.SendKeyPress('8'));
            Assert.Equal("0", calc.SendKeyPress('='));
        }

        [Fact]
        public void VerifyDivideByZero()
        {
            Calculator calc = new Calculator();
            string expected = "-E-";

            calc.SendKeyPress('9');           
            calc.SendKeyPress('/');
            calc.SendKeyPress('0');
            string actual = calc.SendKeyPress('=');

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void VerifyCharecterPress_C_ReturnZero()
        { 
            Calculator calc = new Calculator();

            Assert.Equal("8", calc.SendKeyPress('8'));
            Assert.Equal("0", calc.SendKeyPress('c'));
            Assert.Equal("9", calc.SendKeyPress('9'));
            Assert.Equal("0", calc.SendKeyPress('c'));            
        }

        [Fact]
        public void VerifyMultipleOperations()
        {
            Calculator calc = new Calculator();

            Assert.Equal("1", calc.SendKeyPress('1'));
            Assert.Equal("11", calc.SendKeyPress('1'));
            Assert.Equal("11", calc.SendKeyPress('+'));
            Assert.Equal("4", calc.SendKeyPress('4'));
            Assert.Equal("15", calc.SendKeyPress('/'));
            Assert.Equal("3", calc.SendKeyPress('3'));
            Assert.Equal("5", calc.SendKeyPress('-'));
            Assert.Equal("1", calc.SendKeyPress('1'));
            Assert.Equal("4", calc.SendKeyPress('='));
        }
    }
}
