using Xunit;

namespace Lesson5.Tests
{
    public class SortedIntArrayFacts
    {
        [Fact]
        public void TestForAddingTwoSortedValues()
        {
            var sortedArray = new SortedIntArray();
            sortedArray.Add(1);
            sortedArray.Add(3);
            Assert.Equal(1, sortedArray[0]);
            Assert.Equal(3, sortedArray[1]);
        }

        [Fact]
        public void TestForAddingTwoNotSortedValues()
        {
            var notSortedArray = new SortedIntArray();
            notSortedArray.Add(3);
            notSortedArray.Add(1);
            Assert.Equal(1, notSortedArray[0]);
            Assert.Equal(3, notSortedArray[1]);
        }

        [Fact]
        public void TestForAddingFourNotSortedValues()
        {
            var notSortedArray = new SortedIntArray();
            notSortedArray.Add(3);
            notSortedArray.Add(1);
            notSortedArray.Add(6);
            notSortedArray.Add(2);
            Assert.Equal(1, notSortedArray[0]);
            Assert.Equal(2, notSortedArray[1]);
            Assert.Equal(3, notSortedArray[2]);
            Assert.Equal(6, notSortedArray[3]);
        }

        [Fact]
        public void TestForAddingSameValues()
        {
            var notSortedArray = new SortedIntArray();
            notSortedArray.Add(1);
            notSortedArray.Add(1);
            notSortedArray.Add(1);
            notSortedArray.Add(1);
            Assert.Equal(0, notSortedArray.IndexOf(1));
            Assert.Equal(-1, notSortedArray.IndexOf(2));
        }


        [Fact]
        public void TestForInsertingInASortedArray()
        {
            var sortedArray = new SortedIntArray();
            sortedArray.Add(1);
            sortedArray.Add(4);
            sortedArray.Add(6);
            sortedArray.Add(12);
            sortedArray.Insert(2, 5);
            Assert.Equal(2, sortedArray.IndexOf(5));
            Assert.Equal(5, sortedArray.Count);
        }


        [Fact]
        public void TestForInsertingInAnUnsortedArrayShouldNotWork()
        {
            var notSortedArray = new SortedIntArray();
            notSortedArray.Add(1);
            notSortedArray.Add(4);
            notSortedArray.Add(6);
            notSortedArray.Add(12);
            notSortedArray.Insert(2, 100);
            Assert.Equal(-1, notSortedArray.IndexOf(100));
            Assert.Equal(4, notSortedArray.Count);
        }


        [Fact]
        public void TestForInsertingInEmptyArray()
        {
            var testArray = new SortedIntArray();
            testArray.Insert(0, 100);
            Assert.Equal(0, testArray.IndexOf(100));
            Assert.Equal(1, testArray.Count);
        }

        [Fact]
        public void TestForInsertingAtEnd()
        {
            var testArray = new SortedIntArray();
            testArray.Add(100);
            testArray.Add(200);
            testArray.Insert(2, 300);
            Assert.Equal(2, testArray.IndexOf(300));
            Assert.Equal(3, testArray.Count);
        }


        [Fact]
        public void TestForIndexWhenResultsSortedArray()
        {
            var testArray = new SortedIntArray();
            testArray.Add(1);
            testArray.Add(5);
            testArray.Add(10);
            testArray[1] = 3;
            Assert.Equal(3, testArray[1]);
        }


        [Fact]
        public void TestForIndexWhenResultsNotSortedArray()
        {
            var testArray = new SortedIntArray();
            testArray.Add(2);
            testArray.Add(5);
            testArray.Add(10);
            testArray[0] = 1;
            Assert.Equal(1, testArray[0]);
            Assert.Equal(10, testArray[2]);
        }

        [Fact]
        public void TestForIndexAtTheEndWhenResultsNotSortedArrayResultsFalse()
        {
            var testArray = new SortedIntArray();
            testArray.Add(2);
            testArray.Add(5);
            testArray.Add(10);
            testArray[2] = 1;
            Assert.Equal(10, testArray[2]);
            Assert.Equal(5, testArray[1]);
        }


        [Fact]
        public void TestForIndexAtTheEndWhenResultsSortedArrayResultsTrue()
        {
            var testArray = new SortedIntArray();
            testArray.Add(1);
            testArray.Add(5);
            testArray.Add(10);
            testArray[2] = 15;
            Assert.Equal(15, testArray[2]);
        }
    }
}
