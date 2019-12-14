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
    }
}
