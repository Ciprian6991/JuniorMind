using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Lesson5.Tests
{
    public class ObjIEnumeratorFacts
    {
        [Fact]
        public void TestForCallingAddInIEnumerable()
        {
            object var1 = 123;
            object var2 = "Test 1";
            object var3 = 123.123;

            var myArray = new ObjectArrayCollection { var1, var2, var3 };

            Assert.Equal(3, myArray.Count);
            Assert.Equal(123.123, myArray[2]);
            
        }
    }
}
