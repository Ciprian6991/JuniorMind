using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Lesson4Abstracting.Facts
{
    public class SequenceFacts
    {
        [Fact]
        public void TestIfTwoCharSequenceReturnsTrue1()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));
            Assert.True(ab.Match("abcd").Success());
        }

        [Fact]
        public void TestIfTwoCharSequenceReturnsCorrectString()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));
            Assert.Equal("cd", ab.Match("abcd").RemainingText());
        }

        [Fact]
        public void TestIfTwoCharSequenceReturnsTrue2()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));
            Assert.False(ab.Match("ax").Success());
        }

        [Fact]
        public void TestIfTwoCharSequenceReturnsCorrectString2()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));
            Assert.Equal("ax", ab.Match("ax").RemainingText());
        }

    }
}
