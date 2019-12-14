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
    }
}
