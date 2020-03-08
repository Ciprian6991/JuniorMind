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

        [Fact]
        void Test_DeletingIntsFromList()
        {
            var array = new ListCollection<int> { 1, 2, 3, 4, 5 };

            bool checkRemove = array.Remove(4);
            Assert.True(checkRemove);
            Assert.Equal(1, array[0]);
            Assert.Equal(2, array[1]);
            Assert.Equal(3, array[2]);
            Assert.Equal(5, array[3]);
            Assert.Equal(4, array.Count);
        }


        [Fact]
        public void Test_RemoveShouldReturnFalseWhenItemDoesNotExist()
        {
            var intList = new ListCollection<int> { 1, 2, 3, 4, 5 };
            var checkRemove = intList.Remove(100);

            Assert.False(checkRemove);
        }


        [Fact]
        public void Test_RemoveShouldReturnFalseWhenListIsEmpty()
        {
            var intList = new ListCollection<int>();
            var checkRemove = intList.Remove(100);

            Assert.False(checkRemove);
        }

        [Fact]
        public void Test_IsReadOnlyShouldReturnFalseWhenListIsEmpty()
        {
            var intList = new ListCollection<int>();

            Assert.False(intList.IsReadOnly);
            Assert.Equal(-1, intList.IndexOf(3));
        }

        [Fact]
        public void Test_CopyListToArrayWhenArrayHasEnoughCapacity()
        {

            var intList = new ListCollection<int> { 1, 2, 3 };
            int[] array = new int[10];
            array[0] = 1;
            array[1] = 2;
            array[2] = 3;

            intList.CopyTo(array, 3);

            Assert.Equal(1, array[3]);
            Assert.Equal(2, array[4]);
            Assert.Equal(3, array[5]);

            Assert.Equal(0, array[6]);
            Assert.Equal(1, array[0]);
            Assert.Equal(3, array[2]);
        }

        [Fact]
        public void Test_CopyListToArrayWhenArrayDoesNotHaveEnoughCapacity()
        {
            var intList = new ListCollection<int> { 1, 2, 3 };
            int[] array = new int[5];
            array[0] = 1;
            array[1] = 2;
            array[2] = 3;

            intList.CopyTo(array, 3);

            Assert.Equal(0, array[3]);
            Assert.Equal(0, array[4]);

            Assert.Equal(2, array[1]);
            Assert.Equal(1, array[0]);
            Assert.Equal(3, array[2]);
        }
    }
}
