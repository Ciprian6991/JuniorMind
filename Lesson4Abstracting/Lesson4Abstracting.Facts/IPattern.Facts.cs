using System;
using Xunit;

namespace Lesson4Abstracting.Facts
{
    public class IPatternFacts
    {
        [Fact]
        public void TestForIPatterInterfaceReturnsTrue()
        {
            var digitPatterns = new IPattern[]
                {
                    new Character('0'),
                    new Range('0', '9'),
                    new Choice(new Character('0'), new Range('1', '9'))
                };

            const string text = "0011";
            foreach (IPattern pattern in digitPatterns)
            {
                Assert.True(pattern.Match(text));
            }
        }
    }
}
