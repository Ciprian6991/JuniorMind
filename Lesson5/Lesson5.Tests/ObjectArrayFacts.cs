using Xunit;

namespace Lesson5.Tests
{
    public class ObjectArrayFacts
    {
        [Fact]
        void TestForIntAndStringInObjectArray()
        {
            var testObj = new ObjectArray();
            testObj.Add(1);
            testObj.Add("String");
            Assert.Equal(1, testObj[0]);
            Assert.Equal("String", testObj[1]);
            Assert.Equal(2, testObj.Count);
        }

        [Fact]
        void TestForIndexOfInObjectArray()
        {
            var testObj = new ObjectArray();
            testObj.Add(1);
            testObj.Add("String");
            testObj.Add(123.123);

            Assert.Equal(0, testObj.IndexOf(1));
            Assert.Equal(1, testObj.IndexOf("String"));
            Assert.Equal(2, testObj.IndexOf(123.123));
            Assert.Equal(3, testObj.Count);
        }

        [Fact]
        void TestForIndexOfNotPresentInObjectArray()
        {
            var testObj = new ObjectArray();
            testObj.Add(1);
            testObj.Add("String");
            testObj.Add(123.123);

            Assert.Equal(-1, testObj.IndexOf(23.23));
            Assert.Equal(3, testObj.Count);
        }

        [Fact]
        void TestForContainsInObjectArray()
        {
            var testObj = new ObjectArray();
            testObj.Add(1);
            testObj.Add("String");
            testObj.Add(123.123);

            Assert.True(testObj.Contains(1));
            Assert.True(testObj.Contains("String"));
            Assert.True(testObj.Contains(123.123));
        }


        [Fact]
        void TestForContainsFalseInObjectArray()
        {
            var testObj = new ObjectArray();
            testObj.Add(1);
            testObj.Add("String");
            testObj.Add(123.123);

            Assert.False(testObj.Contains(123));
        }

        [Fact]
        void TestForInsertInObjectArray()
        {
            var testObj = new ObjectArray();
            testObj.Add(1);
            testObj.Add("String");
            testObj.Add(123.123);
            testObj.Insert(2, "Inserted String");

            Assert.True(testObj.Contains("Inserted String"));
            Assert.Equal(2, testObj.IndexOf("Inserted String"));
            Assert.Equal(4 ,testObj.Count);
        }

        [Fact]
        void TestForRemoveAtInObjectArray()
        {
            var testObj = new ObjectArray();
            testObj.Add(1);
            testObj.Add("String");
            testObj.Add(123.123);
            testObj.RemoveAt(1);

            Assert.Equal(0, testObj.IndexOf(1));
            Assert.Equal(-1, testObj.IndexOf("String"));
            Assert.Equal(1, testObj.IndexOf(123.123));
            Assert.Equal(2, testObj.Count);
        }


        [Fact]
        void TestForRemoveInObjectArray()
        {
            var testObj = new ObjectArray();
            testObj.Add(1);
            testObj.Add("String");
            testObj.Add(123.123);
            testObj.Remove("String");

            Assert.Equal(0, testObj.IndexOf(1));
            Assert.Equal(-1, testObj.IndexOf("String"));
            Assert.Equal(1, testObj.IndexOf(123.123));
            Assert.Equal(2, testObj.Count);
        }

        [Fact]
        void TestForClearInObjectArray()
        {
            var testObj = new ObjectArray();
            testObj.Add(1);
            testObj.Add("String");
            testObj.Add(123.123);
            testObj.Clear();

            Assert.False(testObj.Contains(1));
            Assert.False(testObj.Contains("String"));
            Assert.False(testObj.Contains(123.123));
            Assert.Equal(0, testObj.Count);
        }


        [Fact]
        void TestForIndexAssignInObjectArray()
        {
            var testObj = new ObjectArray();
            testObj.Add(1);
            testObj.Add("String");
            testObj.Add(123.123);
            testObj[0] = "first";

            Assert.False(testObj.Contains(1));
            Assert.True(testObj.Contains("first"));
            Assert.Equal(0, testObj.IndexOf("first"));
            Assert.Equal(1, testObj.IndexOf("String"));
            Assert.Equal(2, testObj.IndexOf(123.123));
            Assert.Equal(3, testObj.Count);
        }


        [Fact]
        public void TestIndexOfBooleanInObjectArray()
        {

            var objectArray = new ObjectArray();
            objectArray.Add(true);
            objectArray.Add(false);

            Assert.False(objectArray.Contains("test"));
            Assert.False(objectArray.Contains(null));
            Assert.Equal(0, objectArray.IndexOf(true));

        }

        [Fact]
        public void TestInsertObjectsInObjectArray()
        {

            var objectArray = new ObjectArray();
            objectArray.Add(true);
            objectArray.Add(false);
            objectArray.Add("string");
            objectArray.Add(null);
            objectArray.Add(string.Empty);
            objectArray.Add(int.MinValue);
            objectArray.Insert(1, 1);
            objectArray.Insert(4, string.Empty);
            objectArray.Insert(5, "string2");
            objectArray[9] = int.MaxValue;

            Assert.False(objectArray.Contains("test"));
            Assert.True(objectArray.Contains(null));
            Assert.Equal(0, objectArray.IndexOf(true));
            Assert.Equal(1, objectArray.IndexOf(1));
            Assert.Equal(8, objectArray.Count);

        }
    }
}
