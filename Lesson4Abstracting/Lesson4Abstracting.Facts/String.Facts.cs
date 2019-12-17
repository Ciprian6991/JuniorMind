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
    }
}
