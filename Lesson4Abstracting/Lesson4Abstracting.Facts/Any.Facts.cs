using System;
using Xunit;

namespace Lesson4Abstracting.Facts
{
    public class AnyFacts
    {
        [Fact]
        public void TestForAnyClassWhenShouldReturnTrue1()
        {
            var e = new Any("eE");
            Assert.True(e.Match("ea").Success());
        }

        [Fact]
        public void TestForAnyClassWhenShouldReturnRightStringBack1()
        {
            var e = new Any("eE");
            Assert.Equal("a", e.Match("ea").RemainingText());
        }

        [Fact]
        public void TestForAnyClassWhenShouldReturnTrue2()
        {
            var e = new Any("eE");
            Assert.True(e.Match("Ea").Success());
        }

        [Fact]
        public void TestForAnyClassWhenShouldReturnRightStringBack2()
        {
            var e = new Any("eE");
            Assert.Equal("a", e.Match("Ea").RemainingText());
        }

        [Fact]
        public void TestForAnyClassWhenShouldReturnFalse1()
        {
            var e = new Any("eE");
            Assert.False(e.Match("a").Success());
        }

        [Fact]
        public void TestForAnyClassWhenShouldReturnRightStringBackInCaseOfFalse()
        {
            var e = new Any("eE");
            Assert.Equal("a", e.Match("a").RemainingText());
        }

        [Fact]
        public void TestForAnyClassWhenShouldReturnFalse2()
        {
            var e = new Any("eE");
            Assert.False(e.Match("").Success());
        }
    }
}
