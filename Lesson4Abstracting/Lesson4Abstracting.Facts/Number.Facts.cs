using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Lesson4Abstracting.Facts
{
    public class NumberFacts
    {
        [Fact]
        public void IntegerAsParamReturnsEmptyString()
        {
            var number = new Number();
            Assert.Equal("", number.Match("123").RemainingText());
        }

        [Fact]
        public void IntegerAsParamReturnsTrue()
        {
            var number = new Number();
            Assert.True(number.Match("123").Success());
        }


        [Fact]
        public void NegativeIntegerAsParamReturnsEmptyString()
        {
            var number = new Number();
            Assert.Equal("", number.Match("-123").RemainingText());
        }

        [Fact]
        public void NegativeIntegerAsParamReturnsTrue()
        {
            var number = new Number();
            Assert.True(number.Match("123").Success());
        }


        [Fact]
        public void FloatAsParamReturnsEmptyString()
        {
            var number = new Number();
            Assert.Equal("", number.Match("123.1").RemainingText());
        }

        [Fact]
        public void FloatIntegerAsParamReturnsTrue()
        {
            var number = new Number();
            Assert.True(number.Match("123.1").Success());
        }


        [Fact]
        public void NegativeFloatAsParamReturnsEmptyString()
        {
            var number = new Number();
            Assert.Equal("", number.Match("-123.1").RemainingText());
        }

        [Fact]
        public void NegativeFloatIntegerAsParamReturnsTrue()
        {
            var number = new Number();
            Assert.True(number.Match("-123.1").Success());
        }


        [Fact]
        public void ZeroAsParamReturnsEmptyString()
        {
            var number = new Number();
            Assert.Equal("", number.Match("0").RemainingText());
        }

        [Fact]
        public void ZeroIntegerAsParamReturnsTrue()
        {
            var number = new Number();
            Assert.True(number.Match("0").Success());
        }


        [Fact]
        public void MinusZeroAsParamReturnsEmptyString()
        {
            var number = new Number();
            Assert.Equal("", number.Match("-0").RemainingText());
        }

        [Fact]
        public void MinusZeroIntegerAsParamReturnsTrue()
        {
            var number = new Number();
            Assert.True(number.Match("-0").Success());
        }


        [Fact]
        public void ZeroDotAsParamReturnsEmptyString()
        {
            var number = new Number();
            Assert.Equal("", number.Match("0.123").RemainingText());
        }

        [Fact]
        public void ZeroDotIntegerAsParamReturnsTrue()
        {
            var number = new Number();
            Assert.True(number.Match("0.123").Success());
        }


        [Fact]
        public void MinusZeroDotAsParamReturnsEmptyString()
        {
            var number = new Number();
            Assert.Equal("", number.Match("-0.123").RemainingText());
        }

        [Fact]
        public void MinusZeroDotIntegerAsParamReturnsTrue()
        {
            var number = new Number();
            Assert.True(number.Match("-0.123").Success());
        }


        [Fact]
        public void ExponentePlusAsParamReturnsEmptyString()
        {
            var number = new Number();
            Assert.Equal("", number.Match("123e+1").RemainingText());
        }

        [Fact]
        public void ExponentePlusAsParamReturnsTrue()
        {
            var number = new Number();
            Assert.True(number.Match("123e+1").Success());
        }


        [Fact]
        public void ExponentEPlusAsParamReturnsEmptyString()
        {
            var number = new Number();
            Assert.Equal("", number.Match("123E+1").RemainingText());
        }

        [Fact]
        public void ExponentEPlusAsParamReturnsTrue()
        {
            var number = new Number();
            Assert.True(number.Match("123E+1").Success());
        }


        [Fact]
        public void ExponenteMinusAsParamReturnsEmptyString()
        {
            var number = new Number();
            Assert.Equal("", number.Match("123e-1").RemainingText());
        }

        [Fact]
        public void ExponenteMinusAsParamReturnsTrue()
        {
            var number = new Number();
            Assert.True(number.Match("123e-1").Success());
        }


        [Fact]
        public void ExponentEMinusAsParamReturnsEmptyString()
        {
            var number = new Number();
            Assert.Equal("", number.Match("123E-1").RemainingText());
        }

        [Fact]
        public void ExponentEMinusAsParamReturnsTrue()
        {
            var number = new Number();
            Assert.True(number.Match("123E-1").Success());
        }


        [Fact]
        public void ZeroDigitsAsParamReturnsString()
        {
            var number = new Number();
            Assert.Equal("123", number.Match("0123").RemainingText());
        }

        [Fact]
        public void ZeroDigitsAsParamReturnsFalse()
        {
            var number = new Number();
            Assert.True(number.Match("0123").Success());
        }


        [Fact]
        public void ExponenteDotPlusAsParamReturnsEmptyString()
        {
            var number = new Number();
            Assert.Equal("", number.Match("12.3e+1").RemainingText());
        }

        [Fact]
        public void ExponenteDotPlusAsParamReturnsTrue()
        {
            var number = new Number();
            Assert.True(number.Match("12.3e+1").Success());
        }


        [Fact]
        public void MinusExponenteDotPlusAsParamReturnsEmptyString()
        {
            var number = new Number();
            Assert.Equal("", number.Match("-12.3e+1").RemainingText());
        }

        [Fact]
        public void MinusExponenteDotPlusAsParamReturnsTrue()
        {
            var number = new Number();
            Assert.True(number.Match("-12.3e+1").Success());
        }


        [Fact]
        public void MinusDotAsParamReturnsDotString()
        {
            var number = new Number();
            Assert.Equal(".", number.Match("-12.").RemainingText());
        }

        [Fact]
        public void MinusDotAsParamReturnsTrue()
        {
            var number = new Number();
            Assert.True(number.Match("-12.").Success());
        }


        [Fact]
        public void MinusExponenteDotAsParamReturnseString()
        {
            var number = new Number();
            Assert.Equal("e", number.Match("-12.3e").RemainingText());
        }

        [Fact]
        public void MinusExponenteDotAsParamReturnsTrue()
        {
            var number = new Number();
            Assert.True(number.Match("-12.3e").Success());
        }
    }
}
