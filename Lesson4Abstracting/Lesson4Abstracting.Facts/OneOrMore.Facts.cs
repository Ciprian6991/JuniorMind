using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Lesson4Abstracting.Facts
{
    public class OneOrMoreFacts
    {
        [Fact]
        public void NumberAsParamReturnsEmptyStringForA()
        {
            var a = new OneOrMore(new Range('0', '9'));
            Assert.Equal("", a.Match("123").RemainingText());
        }
    }
}
