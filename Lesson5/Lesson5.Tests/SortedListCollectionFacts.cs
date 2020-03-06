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


        [Fact]
        public void TestAddingListOfStringsShouldBeInOrder()
        {
            var array = new SortedListCollection<string>();
            array.Add("azz");
            array.Add("axc");
            array.Add("abc");

            Assert.Equal(3, array.Count);
            Assert.Equal("abc", array[0]);
            Assert.Equal("axc", array[1]);
            Assert.Equal("azz", array[2]);
        }


        [Fact]
        public void TestAddingListOfBooleansShouldBeInOrder()
        {
            var array = new SortedListCollection<bool>();
            array.Add(true);
            array.Add(false);
            array.Add(true);
            array.Add(false);
            array.Add(true);

            Assert.Equal(5, array.Count);
            Assert.Equal(false, array[0]);
            Assert.Equal(false, array[1]);
            Assert.Equal(true, array[2]);
            Assert.Equal(true, array[3]);
            Assert.Equal(true, array[4]);
        }

        [Fact]
        public void TestAddingListOfFloatsShouldBeInOrder()
        {
            var array = new SortedListCollection<float>();
            array.Add(float.MaxValue);
            array.Add(float.MinValue);
            array.Add(int.MaxValue);
            array.Add(long.MinValue);
            array.Add(1);

            Assert.Equal(2, array.Count);
            Assert.Equal(float.MinValue, array[0]);
            Assert.Equal(float.MaxValue, array[1]);
        }

        [Fact]
        public void TestAddingListOfCharsShouldBeInOrder()
        {
            var array = new SortedListCollection<char>
            {
                'e',
                'd',
                'a',
                'c',
                'b'
            };


            Assert.Equal(5, array.Count);
            Assert.Equal('a', array[0]);
            Assert.Equal('b', array[1]);
            Assert.Equal('c', array[2]);
            Assert.Equal('d', array[3]);
            Assert.Equal('e', array[4]);
        }


        [Fact]
        public void TestAddingListOfRepetedCharsShouldBeInOrder()
        {
            var array = new SortedListCollection<char>
            {
                'e',
                'd',
                'a',
                'a',
                'a'
            };


            Assert.Equal(5, array.Count);
            Assert.Equal('a', array[0]);
            Assert.Equal('a', array[1]);
            Assert.Equal('a', array[2]);
            Assert.Equal('d', array[3]);
            Assert.Equal('e', array[4]);
        }

        [Fact]
        public void TestInsertElementWhenResultingIntListIsSorted()
        {
            var array = new SortedListCollection<int>
            {
                1,
                4,
                6,
                8
            };

            array.Insert(2, 5);

            Assert.Equal(2, array.IndexOf(5));
            Assert.Equal(5, array.Count);
        }



        [Fact]
        public void TestInsertElementWhenResultingIntListIsNotSorted()
        {
            var array = new SortedListCollection<int>
            {
                1,
                4,
                6,
                8
            };

            array.Insert(2, 100);

            Assert.Equal(-1, array.IndexOf(100));
            Assert.Equal(4, array.Count);
        }


        [Fact]
        public void TestInsertElementWhenSortedListIsEmpty()
        {
            var array = new SortedListCollection<int>();

            array.Insert(0, 100);
            array.Insert(2, 111);

            Assert.Equal(0, array.IndexOf(100));
            Assert.Equal(1, array.Count);
        }


        [Fact]
        public void TestGetElementForSimpleList()
        {
            var array = new SortedListCollection<double>
            {
                1,
                5,
                10
            };

            Assert.Equal(5, array[1]);
        }


        [Fact]
        public void TestSetElementWhenResultingListIsSorted()
        {
            var array = new SortedListCollection<byte>
            {
                1,
                5,
                10
            };
            array[1] = 3;

            Assert.Equal(3, array[1]);
        }


        [Fact]
        public void TestSetElementWhenResultingListNotSorted()
        {
            var array = new SortedListCollection<byte>
            {
                1,
                5,
                10
            };
            array[1] = 100;

            Assert.Equal(5, array[1]);
        }

        [Fact]
        public void TestSetElementWhereIndexOutOfRange()
        {
            var array = new SortedListCollection<byte>
            {
                1,
                5,
                10
            };
            ArgumentException ex = Assert.Throws<ArgumentException>(() => array[10] = 100);
            Assert.Equal("Invalid index; must be less than\r\nParameter name: Count = 3", ex.Message);
            Assert.Equal(5, array[1]);
        }


        [Fact]
        public void TestSetElementEmptyListException()
        {
            var array = new SortedListCollection<byte>();

            ArgumentException ex = Assert.Throws<ArgumentException>(() => array[0] = 3);
            Assert.Equal("Invalid index; must be less than\r\nParameter name: Count = 0", ex.Message);

            Assert.Equal(0, array.Count);
        }


        [Fact]
        public void TestSetLastElementSameValuesBefore()
        {
            var array = new SortedListCollection<byte>
            {
                2,
                2,
                2
            };
            array[2] = 3;

            Assert.Equal(3, array[2]);
        }


        [Fact]
        public void TestSetElementLowerValueShouldNotWork()
        {
            var array = new SortedListCollection<byte>
            {
                2,
                2,
                2
            };
            array[2] = 1;

            Assert.Equal(2, array[2]);
        }

        [Fact]
        public void TestSetElementOneValueForWholeList()
        {
            var array = new SortedListCollection<byte>
            {
                2,
            };
            array[0] = 10;

            Assert.Equal(10, array[0]);
        }
    }
}
