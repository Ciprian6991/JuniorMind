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
        public void Test_AddNodesInEmptyList()
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

        [Fact]
        public void Test_AddAtFrontAsNode()
        {
            DoubleLinkedListCollection<int> dlList = new DoubleLinkedListCollection<int>();

            dlList.AddAtFront(1);
            dlList.AddAtFront(2);
            dlList.AddAtFront(3);

            DNode<int> node = new DNode<int>(4);

            dlList.AddAtFront(node);

            var enumerator = dlList.GetEnumerator();

            Assert.True(enumerator.MoveNext());
            Assert.Equal(4, enumerator.Current);

            Assert.True(enumerator.MoveNext());
            Assert.Equal(3, enumerator.Current);

            Assert.True(enumerator.MoveNext());
            Assert.Equal(2, enumerator.Current);

            Assert.True(enumerator.MoveNext());
            Assert.Equal(1, enumerator.Current);

            Assert.False(enumerator.MoveNext());
        }

        [Fact]
        public void Test_Add()
        {
            DoubleLinkedListCollection<int> dlList = new DoubleLinkedListCollection<int>
            {
                1,
                2,
                3
            };

            var enumerator = dlList.GetEnumerator();

            Assert.True(enumerator.MoveNext());
            Assert.Equal(1, enumerator.Current);

            Assert.True(enumerator.MoveNext());
            Assert.Equal(2, enumerator.Current);

            Assert.True(enumerator.MoveNext());
            Assert.Equal(3, enumerator.Current);

            Assert.False(enumerator.MoveNext());
        }

        [Fact]
        public void Test_Clear()
        {
            DoubleLinkedListCollection<int> dlList = new DoubleLinkedListCollection<int>
            {
                1,
                2,
                3
            };

            dlList.Clear();

            var enumerator = dlList.GetEnumerator();

            Assert.False(enumerator.MoveNext());
            Assert.False(enumerator.MoveNext());
        }

        [Fact]
        public void Test_Contains()
        {
            DoubleLinkedListCollection<int> dlList = new DoubleLinkedListCollection<int>
            {
                1,
                2,
                3
            };

            Assert.Contains(1, dlList);
            Assert.Contains(2, dlList);
            Assert.Contains(3, dlList);

            var checkGet = Assert.Throws<InvalidOperationException>(() => dlList.Contains(4));

            Assert.Equal("Node does not exists!", checkGet.Message);

        }


        [Fact]
        public void Test_RemoveInsideList()
        {
            DoubleLinkedListCollection<int> dlList = new DoubleLinkedListCollection<int>
            {
                1,
                2,
                3,
                4
            };

            Assert.True(dlList.Remove(3));
            var checkGet = Assert.Throws<InvalidOperationException>(() => dlList.Contains(3));

            Assert.Equal("Node does not exists!", checkGet.Message);

        }

        [Fact]
        public void Test_RemoveFirst()
        {
            DoubleLinkedListCollection<int> dlList = new DoubleLinkedListCollection<int>
            {
                1,
                2,
                3,
                4
            };

            Assert.True(dlList.Remove(1));

            var checkGet = Assert.Throws<InvalidOperationException>(() => dlList.Contains(1));

            Assert.Equal("Node does not exists!", checkGet.Message);

        }

        [Fact]
        public void Test_RemoveLast()
        {
            DoubleLinkedListCollection<int> dlList = new DoubleLinkedListCollection<int>
            {
                1,
                2,
                3,
                4
            };

            Assert.True(dlList.Remove(4));
            var checkGet = Assert.Throws<InvalidOperationException>(() => dlList.Contains(4));

            Assert.Equal("Node does not exists!", checkGet.Message);

        }

        [Fact]
        public void Test_CopyTo()
        {
            DoubleLinkedListCollection<int> dlList = new DoubleLinkedListCollection<int>
            {
                1,
                2,
                3,
            };

            int[] list = { 4, 5, 6 };

            dlList.CopyTo(list, 3);

            var enumerator = dlList.GetEnumerator();

            Assert.True(enumerator.MoveNext());
            Assert.Equal(1, enumerator.Current);

            Assert.True(enumerator.MoveNext());
            Assert.Equal(2, enumerator.Current);

            Assert.True(enumerator.MoveNext());
            Assert.Equal(3, enumerator.Current);

            Assert.True(enumerator.MoveNext());
            Assert.Equal(4, enumerator.Current);

            Assert.True(enumerator.MoveNext());
            Assert.Equal(5, enumerator.Current);

            Assert.True(enumerator.MoveNext());
            Assert.Equal(6, enumerator.Current);

            Assert.False(enumerator.MoveNext());

        }

        [Fact]
        public void Test_ExceptionRemoveInvalidValue()
        {
            DoubleLinkedListCollection<int> dlList = new DoubleLinkedListCollection<int>
            {
                1,
                2,
                3,
            };

            var checkGet = Assert.Throws<InvalidOperationException>(() => dlList.Remove(4));

            Assert.Equal("Node does not exists!", checkGet.Message);
        }


        [Fact]
        public void Test_ExceptionCopyToInvalidIndex()
        {
            DoubleLinkedListCollection<int> dlList = new DoubleLinkedListCollection<int>
            {
                1,
                2,
                3,
            };

            int[] list = { 4, 5, 6 };

            var checkGet = Assert.Throws<InvalidOperationException>(() => dlList.CopyTo(list, 10));

            Assert.Equal("Invalid Index!", checkGet.Message);

        }


        [Fact]
        public void Test_ExceptionCopyToNullArray()
        {
            DoubleLinkedListCollection<int> dlList = new DoubleLinkedListCollection<int>
            {
                1,
                2,
                3,
            };

            int[] list = null;

            var checkGet = Assert.Throws<InvalidOperationException>(() => dlList.CopyTo(list, 12));

            Assert.Equal("Null Array!", checkGet.Message);

        }

        [Fact]
        public void Test_NumeratorAtEnd_AndFindAtEnd()
        {
            DoubleLinkedListCollection<int> dlList = new DoubleLinkedListCollection<int>()
            {
                1,
                2,
                3,
                4,
                3,
                5
            };

            //Find at End

            DNode<int> nodeAtEnd = dlList.FindAtEnd(3);

            Assert.Equal(4, nodeAtEnd.Previous.Data);
            Assert.Equal(5, nodeAtEnd.Next.Data);


            // backwards enumerator
            var enumerator = dlList.GetEnumeratorAtEnd();

            Assert.True(enumerator.MoveNext());
            Assert.Equal(5, enumerator.Current);

            Assert.True(enumerator.MoveNext());
            Assert.Equal(3, enumerator.Current);

            Assert.True(enumerator.MoveNext());
            Assert.Equal(4, enumerator.Current);

            Assert.True(enumerator.MoveNext());
            Assert.Equal(3, enumerator.Current);

            Assert.True(enumerator.MoveNext());
            Assert.Equal(2, enumerator.Current);

            Assert.True(enumerator.MoveNext());
            Assert.Equal(1, enumerator.Current);

            Assert.False(enumerator.MoveNext());
        }

        [Fact]
        public void Test_AddAtFrontNull()
        {
            DoubleLinkedListCollection<int> dlList = new DoubleLinkedListCollection<int>()
            {
                1,
                2,
                3
            };

            DNode<int> node = null;

            var checkGet = Assert.Throws<InvalidOperationException>(() => dlList.AddAtFront(node));

            Assert.Equal("Null Node!", checkGet.Message);

            var enumerator = dlList.GetEnumerator();

            Assert.True(enumerator.MoveNext());
            Assert.Equal(1, enumerator.Current);

            Assert.True(enumerator.MoveNext());
            Assert.Equal(2, enumerator.Current);

            Assert.True(enumerator.MoveNext());
            Assert.Equal(3, enumerator.Current);

            Assert.False(enumerator.MoveNext());
        }
    }
}
