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
    }
}
