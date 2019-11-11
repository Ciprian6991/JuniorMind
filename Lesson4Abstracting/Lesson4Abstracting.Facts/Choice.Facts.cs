using System;
using Xunit;

namespace Lesson4Abstracting.Facts
{
    public class ChoiceFacts
    {
        [Fact]
        public void TestIfIPatternWorksForCharacterAndRAngeClasses()
        {
            var digitPatterns = new Choice(new Character('0'), new Range('1', '9'));
            const string text = "00001";
            Assert.True(digitPatterns.Match(text));
        }
    }
}
