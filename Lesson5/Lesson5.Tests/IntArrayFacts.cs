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

        [Fact]
        public void TestSetElement()
        {
            var testArray = new IntArray();
            testArray.Add(2);
            testArray.Add(3);
            testArray.Add(4);
            testArray.Add(5);
            testArray.SetElement(2, 10);
            Assert.Equal(10, testArray.Element(2));
        }

        [Fact]
        public void TestContainsTrue()
        {
            var testArray = new IntArray();
            testArray.Add(2);
            testArray.Add(3);
            testArray.Add(4);
            testArray.Add(5);
            
            Assert.True(testArray.Contains(5));
        }

        [Fact]
        public void TestContainsFalse()
        {
            var testArray = new IntArray();
            testArray.Add(2);
            testArray.Add(3);
            testArray.Add(4);
            testArray.Add(5);

            Assert.False(testArray.Contains(10));
        }

        [Fact]
        public void TestIndexOfHasOne()
        {
            var testArray = new IntArray();
            testArray.Add(2);
            testArray.Add(3);
            testArray.Add(4);
            testArray.Add(5);

            Assert.Equal(3, testArray.IndexOf(5));
        }
    }
}
