using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Lesson4Abstracting.Facts
{
    public class ListFacts
    {
        [Fact]
        public void NumberAndCommaAsParamReturnsEmptyStringForA()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            Assert.Equal("", a.Match("1,2,3").RemainingText());
        }

        [Fact]
        public void NumberAndCommaAsParamReturnsTrueForA()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            Assert.True(a.Match("1,2,3").Success());
        }


        [Fact]
        public void NumberAndCommaSAsParamReturnsCommaForA()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            Assert.Equal(",", a.Match("1,2,3,").RemainingText());
        }
    }
}
