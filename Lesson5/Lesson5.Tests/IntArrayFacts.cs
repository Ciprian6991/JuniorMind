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

        [Fact]
        public void TestElement()
        {
            var testArray = new IntArray();
            testArray.Add(2);
            testArray.Add(3);
            testArray.Add(4);
            testArray.Add(5);
            Assert.Equal(4, testArray.Element(2));
        }
    }
}
