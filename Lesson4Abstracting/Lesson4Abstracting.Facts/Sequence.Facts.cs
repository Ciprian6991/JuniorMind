using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Lesson4Abstracting.Facts
{
    public class SequenceFacts
    {
        [Fact]
        public void TestIfTwoCharSequenceReturnsTrue()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));
            Assert.True(ab.Match("abcd").Success());
        }
    }
}
