using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Lesson5.Tests
{
    public class ReadOnlyListCollectionFacts
    {
        [Fact]
        public void Test_ExceptionRemoveAtListIsReadOnly()
        {
            var intList = new ListCollection<int> { 1, 2, 3, 4, 5 };
            var readOnly = new ReadOnlyListCollection<int>(intList);

            var checkGet = Assert.Throws<NotSupportedException>(() => readOnly.RemoveAt(2));

            Assert.Equal("List is readonly!", checkGet.Message);
        }
    }
}
