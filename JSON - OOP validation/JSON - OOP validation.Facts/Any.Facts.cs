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

        [Fact]
        public void TestForAnyClassWhenShouldReturnRightStringBackInCaseOfFalseEmptyString()
        {
            var e = new Any("eE");
            Assert.Equal("", e.Match("").RemainingText());
        }

        [Fact]
        public void TestForAnyClassWhenShouldReturnFalseNullString()
        {
            var e = new Any("eE");
            Assert.False(e.Match(null).Success());
        }

        [Fact]
        public void TestForAnyClassWhenShouldReturnRightStringBackInCaseOfFalseNullString()
        {
            var e = new Any("eE");
            Assert.Null(e.Match(null).RemainingText());
        }

        [Fact]
        public void TestForAnyClassWhenShouldReturnTrueSigns1()
        {
            var sign = new Any("-+");
            Assert.True(sign.Match("+3").Success());
        }

        [Fact]
        public void TestForAnyClassWhenShouldReturnRightStringSigns1()
        {
            var sign = new Any("-+");
            Assert.Equal("3", sign.Match("+3").RemainingText());
        }

        [Fact]
        public void TestForAnyClassWhenShouldReturnTrueSigns2()
        {
            var sign = new Any("-+");
            Assert.True(sign.Match("-2").Success());
        }

        [Fact]
        public void TestForAnyClassWhenShouldReturnRightStringSigns2()
        {
            var sign = new Any("-+");
            Assert.Equal("2", sign.Match("-2").RemainingText());
        }

        [Fact]
        public void TestForAnyClassWhenShouldReturnFalseSigns1()
        {
            var sign = new Any("-+");
            Assert.False(sign.Match("2").Success());
        }

        [Fact]
        public void TestForAnyClassWhenShouldReturnRightStringSigns3()
        {
            var sign = new Any("-+");
            Assert.Equal("2", sign.Match("-2").RemainingText());
        }

        [Fact]
        public void TestForAnyClassWhenShouldReturnFalseSignsEmpty()
        {
            var sign = new Any("-+");
            Assert.False(sign.Match("").Success());
        }

        [Fact]
        public void TestForAnyClassWhenShouldReturnEmptyStringSigns()
        {
            var sign = new Any("-+");
            Assert.Equal("", sign.Match("").RemainingText());
        }

        [Fact]
        public void TestForAnyClassWhenShouldReturnFalseSignsNULL()
        {
            var sign = new Any("-+");
            Assert.False(sign.Match(null).Success());
        }

        [Fact]
        public void TestForAnyClassWhenShouldReturnNULLStringSigns()
        {
            var sign = new Any("-+");
            Assert.Null(sign.Match(null).RemainingText());
        }

    }
}
