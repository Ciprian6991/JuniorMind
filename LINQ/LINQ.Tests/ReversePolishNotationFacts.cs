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
    }
}
