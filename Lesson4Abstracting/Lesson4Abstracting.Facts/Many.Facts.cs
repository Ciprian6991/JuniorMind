using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Lesson4Abstracting.Facts
{
    public class ManyFacts
    {
        [Fact]
        public void AbcAsParamReturnsBcForA()
        {
            var a = new Many(new Character('a'));
            Assert.Equal("bc",a.Match("abc").RemainingText());
        }
    }
}
