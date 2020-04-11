using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Lesson5.Tests
{
    public class IntListFacts
    {

        private IntList AddArray(params int[] values)
        {
            IntList array = new IntList();
            foreach (var value in values)
                array.Add(value);

            return array;
        }

        [Fact]
        public void CompleteTests()
        {

            var array = new IntList();
            Assert.Equal(0, array.Count);

            array = AddArray(1, 2, 3, 4);
            Assert.Equal(4, array.Count);

            array.Add(5);
            Assert.Equal(5, array.Count);
            Assert.Equal(5, array[4]);

            array[4] = 220;
            Assert.Equal(220, array[4]);

            Assert.True(array.Contains(3));
            Assert.False(array.Contains(10));

            Assert.Equal(-1, array.IndexOf(100));

            array.Insert(5, 100);
            Assert.Equal(5, array.IndexOf(100));
            Assert.Equal(6, array.Count);

            array.Remove(100);
            Assert.Equal(-1, array.IndexOf(100));
            Assert.Equal(5, array.Count);


            array.RemoveAt(4);
            Assert.Equal(4, array[3]);
            Assert.Equal(4, array.Count);
        }

    }
}
