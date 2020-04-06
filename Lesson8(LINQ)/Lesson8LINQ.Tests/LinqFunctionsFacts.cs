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
    }
}
