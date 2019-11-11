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
                    new Range('0', '9')
                };

            const string text = "0011";
            foreach (IPattern pattern in digitPatterns)
            {
                Assert.True(pattern.Match(text));
            }
        }

        [Fact]
        public void TestForIPatterInterfaceReturnsFalse()
        {
            var digitPatterns = new IPattern[]
                {
                    new Character('0'),
                    new Range('0', '8')
                };

            const string text = "9011";
            foreach (IPattern pattern in digitPatterns)
            {
                Assert.False(pattern.Match(text));
            }
        }
    }
}
