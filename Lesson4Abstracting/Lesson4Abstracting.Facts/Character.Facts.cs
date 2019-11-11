using System;
using Xunit;

namespace Lesson4Abstracting.Facts
{
    public class CharacterFacts
    {
        [Fact]
        public void TestIfMatchMethodReturnsTrue()
        {
            var x = new Character('x');
            Assert.True(x.Match("xabc"));
        }

        [Fact]
        public void TestIfMatchMethodReturnsFalse()
        {
            var x = new Character('x');
            Assert.False(x.Match("babc"));
        }

        [Fact]
        public void TestIfMatchMethodReturnsFalseInCaseOfNullString()
        {
            var x = new Character('x');
            Assert.False(x.Match(""));
        }
    }
}
