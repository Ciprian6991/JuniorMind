using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Lesson4Abstracting.Facts
{
    public class ValueFacts
    {
        [Fact]
        public void TestForSimpleTrueFalseNull()
        {
            var value = new Value();
            const string text = "true";
            Assert.True(value.Match(text).Success());
        }

    }
}
