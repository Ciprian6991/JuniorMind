using Lesson6LinkedList;
using System;
using Xunit;

namespace LinkedList.Tests
{
    public class DNodeFacts
    {
        [Fact]
        public void TestLinkToAnotherNode()
        {
            DNode<int> node1 = new DNode<int>(23);

            DNode<int> node2 = new DNode<int>(24);

            node1.Next = node2;
            node2.Previous = node1;

            Assert.Equal(24, node1.Next.Data);
            Assert.Equal(23, node2.Previous.Data);
        }
    }
}
