using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Lesson4Abstracting.Facts
{
    public class ManyFacts
    {
        [Fact]
        public void AbcAsParamReturnsBcForA()
        {
            var a = new Many(new Character('a'));
            Assert.Equal("bc",a.Match("abc").RemainingText());
        }

        [Fact]
        public void AbcAsParamReturnsTrueForA()
        {
            var a = new Many(new Character('a'));
            Assert.True(a.Match("abc").Success());
        }


        [Fact]
        public void AaaaaabcAsParamReturnsBcForA()
        {
            var a = new Many(new Character('a'));
            Assert.Equal("bc", a.Match("aaaaabc").RemainingText());
        }

        [Fact]
        public void AaaaaabcAsParamReturnsTrueForA()
        {
            var a = new Many(new Character('a'));
            Assert.True(a.Match("aaaaabc").Success());
        }


        [Fact]
        public void BcAsParamReturnsBcForA()
        {
            var a = new Many(new Character('a'));
            Assert.Equal("bc", a.Match("bc").RemainingText());
        }

        [Fact]
        public void BcAsParamReturnsTrueForA()
        {
            var a = new Many(new Character('a'));
            Assert.True(a.Match("bc").Success());
        }


        [Fact]
        public void EmptyAsParamReturnsEmptyForA()
        {
            var a = new Many(new Character('a'));
            Assert.Equal("", a.Match("").RemainingText());
        }

        [Fact]
        public void EmptyAsParamReturnsTrueForA()
        {
            var a = new Many(new Character('a'));
            Assert.True(a.Match("").Success());
        }


        [Fact]
        public void NullAsParamReturnsNullForA()
        {
            var a = new Many(new Character('a'));
            Assert.Null(a.Match(null).RemainingText());
        }

        [Fact]
        public void NullAsParamReturnsTrueForA()
        {
            var a = new Many(new Character('a'));
            Assert.True(a.Match(null).Success());
        }


        [Fact]
        public void DigitsAndStringAsParamReturnsCorectFormatForDigits()
        {
            var digits = new Many(new Range('0', '9'));
            Assert.Equal("ab123", digits.Match("12345ab123").RemainingText());
        }

        [Fact]
        public void DigitsAndStringAsParamReturnsTrueForDigits()
        {
            var digits = new Many(new Range('0', '9'));
            Assert.True(digits.Match("12345ab123").Success());
        }


        [Fact]
        public void StringAsParamReturnsCorectFormatForDigits()
        {
            var digits = new Many(new Range('0', '9'));
            Assert.Equal("ab", digits.Match("ab").RemainingText());
        }

        [Fact]
        public void StringAsParamReturnsTrueForDigits()
        {
            var digits = new Many(new Range('0', '9'));
            Assert.True(digits.Match("ab").Success());
        }


        [Fact]
        public void StringAsParamReturnsTrueForString()
        {
            var seqence = new Sequence(new Character('a'), new Character('b'));
            var digits = new Many(seqence);
            Assert.True(digits.Match("ababc").Success());
        }

        [Fact]
        public void StringAsParamReturnsCorectFormatForString()
        {
            var seqence = new Sequence(new Character('a'), new Character('b'));
            var digits = new Many(seqence);
            Assert.Equal("ac", digits.Match("ababac").RemainingText());
        }
    }
}
