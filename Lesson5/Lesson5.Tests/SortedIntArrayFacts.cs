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
    }
}
