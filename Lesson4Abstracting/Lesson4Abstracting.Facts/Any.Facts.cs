using System;
using Xunit;

namespace Lesson4Abstracting.Facts
{
    public class AnyFacts
    {
        [Fact]
        public void TestIfIPatternWorksForCharacterAndRAngeClasses()
        {
            var e = new Any("eE");
            Assert.True(e.Match("ea").Success());
        }
    }
}
