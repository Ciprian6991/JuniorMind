using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Lesson4Abstracting.Facts
{
    public class OptionalFacts
    {
        [Fact]
        public void AbcAsParamReturnsBcForA()
        {
            var a = new Optional(new Character('a'));
            Assert.Equal("bc", a.Match("abc").RemainingText());
        }

        [Fact]
        public void AbcAsParamReturnsTrueForA()
        {
            var a = new Optional(new Character('a'));
            Assert.True(a.Match("abc").Success());
        }


        [Fact]
        public void AabcAsParamReturnsBcForA()
        {
            var a = new Optional(new Character('a'));
            Assert.Equal("abc", a.Match("aabc").RemainingText());
        }

        [Fact]
        public void AaaaaabcAsParamReturnsTrueForA()
        {
            var a = new Optional(new Character('a'));
            Assert.True(a.Match("aabc").Success());
        }


        [Fact]
        public void BcAsParamReturnsBcForA()
        {
            var a = new Optional(new Character('a'));
            Assert.Equal("bc", a.Match("bc").RemainingText());
        }

        [Fact]
        public void BcAsParamReturnsTrueForA()
        {
            var a = new Optional(new Character('a'));
            Assert.True(a.Match("bc").Success());
        }


        [Fact]
        public void EmptyAsParamReturnsEmptyForA()
        {
            var a = new Optional(new Character('a'));
            Assert.Equal("", a.Match("").RemainingText());
        }

        [Fact]
        public void EmptyAsParamReturnsTrueForA()
        {
            var a = new Optional(new Character('a'));
            Assert.True(a.Match("").Success());
        }


        [Fact]
        public void NullAsParamReturnsNullForA()
        {
            var a = new Optional(new Character('a'));
            Assert.Null(a.Match(null).RemainingText());
        }

        [Fact]
        public void NullAsParamReturnsTrueForA()
        {
            var a = new Optional(new Character('a'));
            Assert.True(a.Match(null).Success());
        }


        [Fact]
        public void SignAsParamReturnsSameNumberString()
        {
            var sign = new Optional(new Character('-'));
            Assert.Equal("123", sign.Match("123").RemainingText());
        }

        [Fact]
        public void SignAsParamReturnsTrue()
        {
            var sign = new Optional(new Character('-'));
            Assert.True(sign.Match("123").Success());
        }


        [Fact]
        public void SignAsParamReturnsSameNumberString2()
        {
            var sign = new Optional(new Character('-'));
            Assert.Equal("123", sign.Match("-123").RemainingText());
        }

        [Fact]
        public void SignAsParamReturnsTrue2()
        {
            var sign = new Optional(new Character('-'));
            Assert.True(sign.Match("-123").Success());
        }
    }
}
