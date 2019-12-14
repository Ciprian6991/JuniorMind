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
        public void ExponentAsParamReturnsEmptyString()
        {
            var number = new Number();
            Assert.Equal("", number.Match("123e+1").RemainingText());
        }
    }
}
