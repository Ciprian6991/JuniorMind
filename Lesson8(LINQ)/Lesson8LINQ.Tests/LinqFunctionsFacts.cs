using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Lesson8LINQ.Tests
{
    public class LinqFunctionsFacts
    {
        [Fact]
        public void TestAllWhenTrue()
        {
            var array = new int[] { 2, 4, 6 };

            Func<int, bool> myFunc = (x) => { return x % 2 == 0; };

            Assert.True(LinqFunctions.All(array, p => myFunc(p)));
        }

        [Fact]
        public void TestAllWhenFalse()
        {
            var array = new int[] { 2, 4, 6, 7 };

            Func<int, bool> myFunc = (x) => { return x % 2 == 0; };

            Assert.False(LinqFunctions.All(array, p => myFunc(p)));
        }

        [Fact]
        public void TestAllWhenSourceIsNull()
        {
            int[] array = null;

            Func<int, bool> myFunc = (x) => { return x == 4; };

            var msg = Assert.Throws<ArgumentNullException>(() => LinqFunctions.All(array, p => myFunc(p)));

            Assert.Equal("Value cannot be null.\r\nParameter name: source", msg.Message);
        }

        [Fact]
        public void TestAnyWhenTrue()
        {
            var array = new int[] { 1, 2, 3, 4, 5, 15};

            Func<int, bool> myFunc = (x) => { return x >= 10; };

            Assert.True(LinqFunctions.Any(array, p => myFunc(p)));
        }

        [Fact]
        public void TestAnyWhenFalse()
        {
            var array = new int[] { 1, 2, 3, 4, 5 };

            Func<int, bool> myFunc = (x) => { return x >= 10; };

            Assert.False(LinqFunctions.Any(array, p => myFunc(p)));
        }

        [Fact]
        public void TestAnyWhenSourceIsNull()
        {
            int[] array = null;

            Func<int, bool> myFunc = (x) => { return x == 4; };

            var msg = Assert.Throws<ArgumentNullException>(() => LinqFunctions.Any(array, p => myFunc(p)));

            Assert.Equal("Value cannot be null.\r\nParameter name: source", msg.Message);
        }

        [Fact]
        public void TestFirstWhenExists()
        {
            var array = new int[] { 1, 2, 3, 4, 5 };

            Func<int, bool> myFunc = (x) => { return x == 4; };

            var result = LinqFunctions.First(array, p => myFunc(p));

            Assert.Equal(4, result);
        }

        [Fact]
        public void TestFirstWhenDoesntExists()
        {
            var array = new int[] { 2, 5, 3 };

            Func<int, bool> myFunc = (x) => { return x == 4; };

             var msg = Assert.Throws<InvalidOperationException>(() => LinqFunctions.First(array, p => myFunc(p)));

            Assert.Equal("No element has been found", msg.Message);
        }

        [Fact]
        public void TestFirstWhenSourceIsNull()
        {
            int[] array = null;

            Func<int, bool> myFunc = (x) => { return x == 4; };

            var msg = Assert.Throws<ArgumentNullException>(() => LinqFunctions.First(array, p => myFunc(p)));

            Assert.Equal("Value cannot be null.\r\nParameter name: source", msg.Message);
        }
    }
}
