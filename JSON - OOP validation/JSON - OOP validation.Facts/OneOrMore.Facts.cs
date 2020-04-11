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

        [Fact]
        public void NumberAsParamReturnsTrueForA()
        {
            var a = new OneOrMore(new Range('0', '9'));
            Assert.True(a.Match("123").Success());
        }


        [Fact]
        public void NumberAndStringAsParamReturnsStringForA()
        {
            var a = new OneOrMore(new Range('0', '9'));
            Assert.Equal("a", a.Match("1a").RemainingText());
        }

        [Fact]
        public void NumberAndStringAsParamReturnsTrueForA()
        {
            var a = new OneOrMore(new Range('0', '9'));
            Assert.True(a.Match("1a").Success());
        }



        [Fact]
        public void StringAsParamReturnsStringForA()
        {
            var a = new OneOrMore(new Range('0', '9'));
            Assert.Equal("bc", a.Match("bc").RemainingText());
        }

        [Fact]
        public void StringAsParamReturnsFalseForA()
        {
            var a = new OneOrMore(new Range('0', '9'));
            Assert.False(a.Match("bc").Success());
        }


        [Fact]
        public void EmptyStringAsParamReturnsEmptyStringForA()
        {
            var a = new OneOrMore(new Range('0', '9'));
            Assert.Equal("bc", a.Match("bc").RemainingText());
        }

        [Fact]
        public void EmptyStringAsParamReturnsFalseForA()
        {
            var a = new OneOrMore(new Range('0', '9'));
            Assert.False(a.Match("bc").Success());
        }


        [Fact]
        public void NullAsParamReturnsNullForA()
        {
            var a = new OneOrMore(new Range('0', '9'));
            Assert.Null(a.Match(null).RemainingText());
        }

        [Fact]
        public void NullAsParamReturnsFalseForA()
        {
            var a = new OneOrMore(new Range('0', '9'));
            Assert.False(a.Match(null).Success());
        }
    }
}
