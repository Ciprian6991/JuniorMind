using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Lesson4Abstracting.Facts
{
    public class StringFacts
    {
        [Fact]
        public void EmptyStringReturnsEmptyString()
        {
            var text = new String();
            Assert.Equal("", text.Match("\"\"").RemainingText());
        }

        [Fact]
        public void EmptyStringReturnsTrue()
        {
            var text = new String();
            Assert.True(text.Match("\"\"").Success());
        }


        [Fact]
        public void SpaceStringReturnsEmptyString()
        {
            var text = new String();
            Assert.Equal("", text.Match("\" \"").RemainingText());
        }

        [Fact]
        public void SpaceStringReturnsTrue()
        {
            var text = new String();
            Assert.True(text.Match("\" \"").Success());
        }


        [Fact]
        public void SimpleStringReturnsString()
        {
            var text = new String();
            Assert.Equal("", text.Match("\"Test\"").RemainingText());
        }

        [Fact]
        public void SimpleStringReturnsTrue()
        {
            var text = new String();
            Assert.True(text.Match("\"Test\"").Success());
        }


        [Fact]
        public void SimpleTextPlusHexStringReturnsString()
        {
            var text = new String();
            Assert.Equal("", text.Match("\"Test\\u0097\"").RemainingText());
        }

        [Fact]
        public void SimpleTextPlusHexStringReturnsTrue()
        {
            var text = new String();
            Assert.True(text.Match("\"Test\\u1234\"").Success());
        }


        [Fact]
        public void NewLineReturnsString()
        {
            var text = new String();
            Assert.Equal("", text.Match("\"\n\"").RemainingText());
        }

        [Fact]
        public void NewLineReturnsTrue()
        {
            var text = new String();
            Assert.True(text.Match("\"\n\"").Success());
        }


        [Fact]
        public void NewLineReturnsTrueee()
        {
            var text = new String();
            Assert.Equal("", text.Match("\"\n\"").RemainingText());
        }


        [Fact]
        public void SolidusReverseSolidusReturnsEmptyString()
        {
            var text = new String();
            Assert.True(text.Match("\"\\/\"").Success());
        }


        [Fact]
        public void SolidusReverseSolidusReturnsTrue()
        {
            var text = new String();
            Assert.Equal("", text.Match("\"\\/\"").RemainingText());
        }


        [Fact]
        public void SolidusQuatationMarkReturnsEmptyString()
        {
            var text = new String();
            Assert.True(text.Match("\"\\\"\"").Success());
        }


        [Fact]
        public void SolidusQuatationMarkReturnsTrue()
        {
            var text = new String();
            Assert.Equal("", text.Match("\"\\\"\"").RemainingText());
        }



        [Fact]
        public void SolidusSolidusReturnsEmptyString()
        {
            var text = new String();
            Assert.True(text.Match("\"\\\\\"").Success());
        }


        [Fact]
        public void SolidusSolidusReturnsTrue()
        {
            var text = new String();
            Assert.Equal("", text.Match("\"\\\\\"").RemainingText());
        }



        [Fact]
        public void MissingQuatationMarkReturningFalse1()
        {
            var text = new String();
            Assert.False(text.Match("Test\"").Success());
        }


        [Fact]
        public void MissingQuatationMarkReturnsRemainingString1()
        {
            var text = new String();
            Assert.Equal("Test\"", text.Match("Test\"").RemainingText());
        }


        [Fact]
        public void MissingQuatationMarkReturningFalse2()
        {
            var text = new String();
            Assert.False(text.Match("\"Test").Success());
        }


        [Fact]
        public void MissingQuatationMarkReturnsRemainingString2()
        {
            var text = new String();
            Assert.Equal("\"Test", text.Match("\"Test").RemainingText());
        }


        [Fact]
        public void QuatationMarkSolidReturningFalse()
        {
            var text = new String();
            Assert.False(text.Match("\"\\Test\"").Success());
        }


        [Fact]
        public void QuatationMarkSolidReturnsRemainingString()
        {
            var text = new String();
            Assert.Equal("\"\\Test\"", text.Match("\"\\Test\"").RemainingText());
        }


        [Fact]
        public void CharactersQuatationMarkCharactersReturningFalse()
        {
            var text = new String();
            Assert.True(text.Match("\"Te\"st\"").Success());
        }


        [Fact]
        public void CharactersQuatationMarkCharactersReturnsRemainingString()
        {
            var text = new String();
            Assert.Equal("st\"", text.Match("\"Te\"st\"").RemainingText());
        }
    }
}
