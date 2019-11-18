using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Lesson4Abstracting.Facts
{
    public class MatchFacts
    {
        [Fact]
        public void TestForMatchClassRemainingTextMethod()
        {
            var matching = new Match("string", false);
            Assert.Equal("string", matching.RemainingText());
        }


        [Fact]
        public void TestForMatchClassSuccesMethod()
        {
            var matching = new Match("string", false);
            Assert.False(matching.Success());
        }
    }
}

