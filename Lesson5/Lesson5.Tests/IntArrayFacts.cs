using System;
using Xunit;

namespace Lesson5.Tests
{
    public class IntArrayFacts
    {
        [Fact]
        public void TestIntArrayAddAndCount()
        {
            var testArray = new IntArray();
            testArray.Add(2);
            Assert.Equal(1, testArray.Count());
        }
    }
}
