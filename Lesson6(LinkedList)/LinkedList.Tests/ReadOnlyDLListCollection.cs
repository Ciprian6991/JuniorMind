using Lesson6LinkedList;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LinkedList.Tests
{
    public class ReadOnlyDLListCollection
    {
        [Fact]
        public void Test_Add()
        {
            DoubleLinkedListCollection<int> dlList = new DoubleLinkedListCollection<int>
            {
                1,
                2,
                3,
            };

            var ReadOnlydlList = dlList.AsReadOnly();

            var checkGet = Assert.Throws<NotSupportedException>(() => ReadOnlydlList.Add(2));

            Assert.Equal("List is readonly!", checkGet.Message);
        }
    }
}
