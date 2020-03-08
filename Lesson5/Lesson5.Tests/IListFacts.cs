using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Lesson5.Tests
{
    public class IListFacts
    {
        [Fact]
        void Test_AddingIntsToList()
        {
            var array = new ListCollection<int> { 1, 2, 3, 4, 5 };
            Assert.Equal(1, array[0]);
            Assert.Equal(2, array[1]);
            Assert.Equal(3, array[2]);
            Assert.Equal(4, array[3]);
            Assert.Equal(5, array[4]);
            Assert.Equal(5, array.Count);
        }
    }
}
