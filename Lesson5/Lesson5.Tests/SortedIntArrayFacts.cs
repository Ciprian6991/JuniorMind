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
    }
}
