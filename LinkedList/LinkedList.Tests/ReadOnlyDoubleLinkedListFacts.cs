﻿using Lesson6LinkedList;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LinkedList.Tests
{
    public class ReadOnlyDoubleLinkedListFacts
    {
        [Fact]
        public void Test_Add()
        {
            DoubleLinkedList<int> dlList = new DoubleLinkedList<int>
            {
                1,
                2,
                3,
            };

            var ReadOnlydlList = dlList.AsReadOnly();

            var checkGet = Assert.Throws<NotSupportedException>(() => ReadOnlydlList.Add(2));

            Assert.Equal("List is readonly!", checkGet.Message);
        }

        [Fact]
        public void Test_Count()
        {
            DoubleLinkedList<int> dlList = new DoubleLinkedList<int>
            {
                1,
                2,
                3,
            };

            var ReadOnlydlList = dlList.AsReadOnly();

            Assert.Equal(3, ReadOnlydlList.Count);
        }

        [Fact]
        public void Test_IsReadOnly()
        {
            DoubleLinkedList<int> dlList = new DoubleLinkedList<int>
            {
                1,
                2,
                3,
            };

            var ReadOnlydlList = dlList.AsReadOnly();

            Assert.True(ReadOnlydlList.IsReadOnly);
        }

        [Fact]
        public void Test_Clear()
        {
            DoubleLinkedList<int> dlList = new DoubleLinkedList<int>
            {
                1,
                2,
                3,
            };

            var ReadOnlydlList = dlList.AsReadOnly();

            var checkGet = Assert.Throws<NotSupportedException>(() => ReadOnlydlList.Clear());

            Assert.Equal("List is readonly!", checkGet.Message);
        }

        [Fact]
        public void Test_Contains()
        {
            DoubleLinkedList<int> dlList = new DoubleLinkedList<int>
            {
                1,
                2,
                3,
            };

            var ReadOnlydlList = dlList.AsReadOnly();

            Assert.Contains(2, ReadOnlydlList);
        }

        [Fact]
        public void Test_CopyTo()
        {
            DoubleLinkedList<int> dlList = new DoubleLinkedList<int>
            {
                1,
                2,
                3,
            };

            int[] array = { 4, 5 };

            var ReadOnlydlList = dlList.AsReadOnly();

            var checkGet = Assert.Throws<NotSupportedException>(() => ReadOnlydlList.CopyTo(array, 1));

            Assert.Equal("List is readonly!", checkGet.Message);
        }

        [Fact]
        public void Test_Remove()
        {
            DoubleLinkedList<int> dlList = new DoubleLinkedList<int>
            {
                1,
                2,
                3,
            };

            var ReadOnlydlList = dlList.AsReadOnly();

            var checkGet = Assert.Throws<NotSupportedException>(() => ReadOnlydlList.Clear());

            Assert.Equal("List is readonly!", checkGet.Message);
        }

        [Fact]
        public void Test_Eumerator()
        {
            DoubleLinkedList<int> dlList = new DoubleLinkedList<int>
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
    }
}
