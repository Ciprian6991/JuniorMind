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


        [Fact]
        public void TestInsertObjectMixedArray()
        {

            var array = new ObjectArrayCollection {
                (object)true, (object)false,
                (object)"string", (object)null,
                (object)string.Empty, (object)int.MaxValue,
                (object)float.MaxValue};


            array.Insert(1, 4);
            array.Insert(4, string.Empty);

            Assert.False(array.Contains("string2"));
            Assert.True(array.Contains(null));
            Assert.Equal(0, array.IndexOf(true));
            Assert.Equal(1, array.IndexOf(4));
            Assert.Equal(9, array.Count);
            Assert.Equal(float.MaxValue, array[array.Count - 1]);

        }

        [Fact]
        public void TestForNumeratorInObjectArrayColection()
        {
            var array = new ObjectArrayCollection {
                (object)true, (object)false,
                (object)"string", (object)null,
                (object)string.Empty, (object)int.MaxValue,
                (object)float.MaxValue};

            var numerator = array.GetEnumerator();
            numerator.MoveNext();
            numerator.MoveNext();
            numerator.MoveNext();
            var current = numerator.Current;

            Assert.Equal("string", current);
            Assert.Equal(6, array.IndexOf(float.MaxValue));
            Assert.Equal(7, array.Count);
        }


        [Fact]
        public void TestForNumerator_Move_Next_InObjectArrayColectionOutOfIndex()
        {
            var array = new ObjectArrayCollection {
                (object)true, (object)false,
                (object)"string", (object)null,
                (object)string.Empty, (object)int.MaxValue,
                (object)float.MaxValue};

            var numerator = array.GetEnumerator();

            for (int i = 0; i < 10; i++)
            {
                numerator.MoveNext();
            }

            var current = numerator.Current;

            Assert.Equal(array[array.Count - 1], current);
            Assert.Equal(6, array.IndexOf(float.MaxValue));
            Assert.Equal(7, array.Count);
        }
    }
}
