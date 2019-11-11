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
            Assert.True(digit.Match("abc"));
        }

        [Fact]
        public void TestIfMatchMethodReturnsFalse()
        {
            var digit = new Range('a', 'f');
            Assert.False(digit.Match("1bc"));
        }

        [Fact]
        public void TestIfMatchMethodReturnsFalseIfNullText()
        {
            var digit = new Range('a', 'f');
            Assert.False(digit.Match(""));
        }

        [Fact]
        public void TestIfMatchMethodReturnsTrueForInverseStringOrder()
        {
            var digit = new Range('a', 'f');
            Assert.True(digit.Match("cba"));
        }
    }
}
