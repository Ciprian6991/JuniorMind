using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Lesson5.Tests
{
    public class SortedListCollectionFacts
    {
        [Fact]
        public void TestAddingListOfNumbersShouldBeInOrder()
        {
            var array = new SortedListCollection<int>();
            array.Add(3);
            array.Add(2);
            array.Add(1);

            Assert.Equal(3, array.Count);
            Assert.Equal(1, array[0]);
            Assert.Equal(2, array[1]);
            Assert.Equal(3, array[2]);
        }
    }
}
