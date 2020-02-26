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
            Assert.Equal(1, testArray.Count);
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


        [Fact]
        public void TestIndexOfDoesntHaveOne()
        {
            var testArray = new IntArray();
            testArray.Add(2);
            testArray.Add(3);
            testArray.Add(4);
            testArray.Add(5);

            Assert.Equal(-1, testArray.IndexOf(10));
        }

        [Fact]
        public void TestInsert()
        {
            var testArray = new IntArray();
            testArray.Add(2);
            testArray.Add(3);
            testArray.Add(4);
            testArray.Add(5);
            testArray.Insert(2, 10);

            Assert.Equal(10, testArray.Element(2));
        }

        [Fact]
        public void TestInsertLastIndex()
        {
            var testArray = new IntArray();
            testArray.Add(2);
            testArray.Add(3);
            testArray.Add(4);
            testArray.Add(5);
            testArray.Insert(2, 10);

            Assert.Equal(5, testArray.Element(4));
        }


        [Fact]
        public void TestClear()
        {
            var testArray = new IntArray();
            testArray.Add(2);
            testArray.Add(3);
            testArray.Add(4);
            testArray.Clear();
            Assert.Equal(0, testArray.Count);
        }


        [Fact]
        public void TestRemoveValue()
        {
            var testArray = new IntArray();
            testArray.Add(2);
            testArray.Add(3);
            testArray.Add(2);
            testArray.Add(5);
            testArray.Remove(2);

            Assert.Equal(3, testArray.Element(0));
        }


        [Fact]
        public void TestRemoveSize()
        {
            var testArray = new IntArray();
            testArray.Add(2);
            testArray.Add(3);
            testArray.Add(2);
            testArray.Add(5);
            testArray.Remove(2);

            Assert.Equal(3, testArray.Count);
        }

        [Fact]
        public void TestRemoveAtValue()
        {
            var testArray = new IntArray();
            testArray.Add(2);
            testArray.Add(3);
            testArray.Add(2);
            testArray.Add(5);
            testArray.RemoveAt(2);

            Assert.Equal(5, testArray.Element(2));
        }

        [Fact]
        public void TestRemoveAtCount()
        {
            var testArray = new IntArray();
            testArray.Add(2);
            testArray.Add(3);
            testArray.Add(2);
            testArray.Add(5);
            testArray.RemoveAt(2);

            Assert.Equal(3, testArray.Count);
        }
    }
}
