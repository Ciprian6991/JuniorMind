using System;
using Xunit;

namespace Lesson4Abstracting.Facts
{
    public class RangeFacts
    {
        [Fact]
        public void TestIfMatchMethodReturnsTrue()
        {
            var digit = new Range('a', 'f');
            Assert.True(digit.Match("abc").Success());
        }

        [Fact]
        public void TestIfMatchMethodReturnsFalse()
        {
            var digit = new Range('a', 'f');
            Assert.False(digit.Match("1bc").Success());
        }

        [Fact]
        public void TestIfMatchMethodReturnsFalseIfNullText()
        {
            var digit = new Range('a', 'f');
            Assert.False(digit.Match("").Success());
        }

        [Fact]
        public void TestIfMatchMethodReturnsTrueForInverseStringOrder()
        {
            var digit = new Range('a', 'f');
            Assert.True(digit.Match("cba").Success());
        }

        [Fact]
        public void TestForExceptedCharacters()
        {
            var digit = new Range('1', '9', "7");
            Assert.False(digit.Match("751").Success());
        }

        [Fact]
        public void TestForExceptedCharactersTrue()
        {
            var digit = new Range('1', '9', "7");
            Assert.True(digit.Match("851").Success());
        }
    }
}
