using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LINQ.Tests
{
    public class ReversePolishNotationFacts
    {
        [Fact]
        public void Test_Calculate_Addition()
        {

            var result = new ReversePolishNotation("1 2 3 + +").Calculate();

            Assert.Equal(6, result);
        }

        [Fact]
        public void Test_Calculate_Subtraction()
        {

            var result = new ReversePolishNotation("1 2 3 - -").Calculate();

            Assert.Equal(-4, result);
        }

        [Fact]
        public void Test_Calculate_Multiplication()
        {

            var result = new ReversePolishNotation("1 2 3 * *").Calculate();

            Assert.Equal(6, result);
        }

        [Fact]
        public void Test_Calculate_Division()
        {

            var result = new ReversePolishNotation("12 2 3 / /").Calculate();

            Assert.Equal(2, result);
        }

        [Fact]
        public void Test_Calculate_Mod()
        {

            var result = new ReversePolishNotation("12 5 3 % %").Calculate();

            Assert.Equal(2, result);
        }

        [Fact]
        public void Test_Calculate_MinusPlus()
        {

            var result = new ReversePolishNotation("2 1 3 - +").Calculate();

            Assert.Equal(4, result);
        }

        [Fact]
        public void Test_Calculate_Complex()
        {

            var result = new ReversePolishNotation("15 7 1 1 + - / 3 * 2 1 1 + % +").Calculate();

            Assert.Equal(1, result);
        }

        [Fact]
        public void Test_Calculate_NullException()
        {
            string input = null;

            var ex = Assert.Throws<ArgumentNullException>( () => new ReversePolishNotation(input).Calculate());

            Assert.Equal("expression", ex.ParamName);
        }

        [Fact]
        public void Test_Calculate_InvalidInputException()
        {
            var ex = Assert.Throws<ArithmeticException>(() => new ReversePolishNotation("1 2 + - + -").Calculate());

            Assert.Equal("invalid expression", ex.Message);
        }
    }
}
