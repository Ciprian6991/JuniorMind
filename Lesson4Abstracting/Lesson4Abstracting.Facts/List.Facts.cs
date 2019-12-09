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

        [Fact]
        public void NumberAndCommaSAsParamReturnsTrueForA()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            Assert.True(a.Match("1,2,3,").Success());
        }


        [Fact]
        public void NumberAndStringAsParamReturnsStringForA()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            Assert.Equal("a", a.Match("1a").RemainingText());
        }


        [Fact]
        public void NumberAndStringAsParamReturnsTrueForA()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            Assert.True(a.Match("1a").Success());
        }


        [Fact]
        public void StringAsParamReturnsStringForA()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            Assert.Equal("abc", a.Match("abc").RemainingText());
        }

        [Fact]
        public void StringAsParamReturnsTrueForA()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            Assert.True(a.Match("abc").Success());
        }


        [Fact]
        public void EmptyStringAsParamReturnsEmptyString()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            Assert.Equal("", a.Match("").RemainingText());
        }

        [Fact]
        public void EmptyStringAsParamReturnsTrueForA()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            Assert.True(a.Match("").Success());
        }


        [Fact]
        public void NullAsParamReturnsNull()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            Assert.Null(a.Match(null).RemainingText());
        }

        [Fact]
        public void NullAsParamReturnsTrueForA()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            Assert.True(a.Match(null).Success());
        }


        [Fact]
        public void ComplexAsParamReturnsTrue()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);
            var a = new List(new Range('0', '9'), new Character(','));
            Assert.True(list.Match("1; 22  ;\n 333 \t; 22").Success());
        }

        [Fact]
        public void ComplexAsParamReturnsEmptyString()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);
            Assert.Equal("", list.Match("1; 22  ;\n 333 \t; 22").RemainingText());
        }


        [Fact]
        public void SimpleCombinationStringAsParamReturnsTrue()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);
            var a = new List(new Range('0', '9'), new Character(','));
            Assert.True(list.Match("1 \n;").Success());
        }

        [Fact]
        public void SimpleCombinationStringReturnsPartOfString()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);
            Assert.Equal(" \n;", list.Match("1 \n;").RemainingText());
        }


        [Fact]
        public void AbcAsParamReturnsTrue()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);
            var a = new List(new Range('0', '9'), new Character(','));
            Assert.True(list.Match("1 \n;").Success());
        }

        [Fact]
        public void AbcReturnsAbc()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);
            Assert.Equal("abc", list.Match("abc").RemainingText());
        }
    }
}
