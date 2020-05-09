using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LINQ.Tests
{
    public class StringOperationsFacts
    {
        [Fact]
        public void Test_CountVocals()
        {
            int count = StringOperations.CountVocals("Four Words Seven Vocals");

            Assert.Equal(7, count);
        }

        [Fact]
        public void Test_CountConsonants()
        {
            int count = StringOperations.CountConsonants("Four Words Seventeen Consonant");

            Assert.Equal(17, count);
        }
    }
}
