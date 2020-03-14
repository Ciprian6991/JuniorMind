using Lesson6LinkedList;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LinkedList.Tests
{
    public class DoubleLinkedListCollectionFacts
    {
        [Fact]
        void Test_AddNodesInEmptyList()
        {
            DoubleLinkedListCollection<int> dlList = new DoubleLinkedListCollection<int>();

            dlList.AddAtFront(1);
            dlList.AddAtFront(2);
            dlList.AddAtFront(3);

            var enumerator = dlList.GetEnumerator();

            Assert.True(enumerator.MoveNext());
            Assert.Equal(3, enumerator.Current);

            Assert.True(enumerator.MoveNext());
            Assert.Equal(2, enumerator.Current);

            Assert.True(enumerator.MoveNext());
            Assert.Equal(1, enumerator.Current);

            Assert.False(enumerator.MoveNext());
        }
    }
}
