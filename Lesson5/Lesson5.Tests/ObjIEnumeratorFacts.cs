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

        [Fact]
        public void TestForAddWithNullAndString()
        {
            object var1 = null;
            object var2 = null;
            object var3 = "string";

            var myArray = new ObjectArrayCollection { var1, var2, var3 };

            Assert.Equal(3, myArray.Count);
            Assert.Null(myArray[0]);
        }


        [Fact]
        public void TestForAddDirectAdding()
        {
            var myArray = new ObjectArrayCollection { (object)true, (object)null, (object)123, (object)"string"};

            Assert.True(myArray.Contains((object)null));
            Assert.True(myArray.Contains(true));
            Assert.True(myArray.Contains(123));
            Assert.True(myArray.Contains("string"));

        }
    }
}
