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

        [Fact]
        public void TestLinkToAnotherNodeFunction()
        {
            DNode<int> node1 = new DNode<int>(23);

            DNode<int> node2 = new DNode<int>(24);

            node1.Next = node2;
            node2.Previous = node1;

            DNode<int> node3 = new DNode<int>(25);

            node3.LinkTo(node1, node2);
        

            Assert.Equal(24, node3.Next.Data);
            Assert.Equal(23, node3.Previous.Data);
        }

        [Fact]
        public void TestLinkToAnotherNodeFunctionViaFunction()
        {
            DNode<int> node1 = new DNode<int>(23);

            DNode<int> node2 = new DNode<int>(24);

            node1.LinkTo(default, node2);
            node2.LinkTo(node1, default);


            Assert.Equal(24, node1.Next.Data);
            Assert.Equal(23, node2.Previous.Data);
        }


        [Fact]
        public void TestLinkToAnotherNodeFunctionShoudNotWorkForNullPreviousAndNext()
        {
            DNode<int> node1 = new DNode<int>(23);

            DNode<int> node2 = new DNode<int>(24);

            node1.LinkTo(node2, default);
            node2.LinkTo(default, node1);

            Assert.Throws<NullReferenceException>(() => node1.Next.Data);
            Assert.Throws<NullReferenceException>(() => node2.Previous.Data);
        }
    }
}
