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

        [Fact]
        public void TestIfIPatternWorksForCharacterAndRAngeClassesReturnsFalse()
        {
            var digitPatterns = new Choice(new Character('0'), new Range('1', '9'));
            const string text = "a0001";
            Assert.False(digitPatterns.Match(text));
        }

        [Fact]
        public void TestIfIPatternWorksForCharacterAndRAngeClassesReturnsFalseIfNullString()
        {
            var digitPatterns = new Choice(new Character('0'), new Range('1', '9'));
            const string text = "";
            Assert.False(digitPatterns.Match(text));
        }

        [Fact]
        public void TestIfChoiceClassWorksByReceivingTwoCharacterClassesAsParameters()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            const string text = "a0001";
            Assert.True(hex.Match(text));
        }

        [Fact]
        public void TestIfChoiceClassWorksForTwoDigits()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            const string text = "92";
            Assert.True(hex.Match(text));
        }

        [Fact]
        public void TestIfChoiceClassWorksForADigitAndACharacter()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            const string text = "a8";
            Assert.True(hex.Match(text));
        }

        [Fact]
        public void TestIfChoiceClassWorksForACapitalCharacterAndADigit()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            const string text = "B0";
            Assert.True(hex.Match(text));
        }

        [Fact]
        public void TestIfChoiceClassWorksForNullString()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            const string text = null;
            Assert.False(hex.Match(text));
        }
    }
}
