using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Lesson4Abstracting.Facts
{
    public class TextFacts
    {
        [Fact]
        public void TrueAsStringParameterShouldReturnTrue()
        {
            var truE = new Text("true");
            Assert.True(truE.Match("true").Success());
        }
    }
}
