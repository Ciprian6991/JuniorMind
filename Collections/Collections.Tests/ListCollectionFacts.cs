using System;
using Xunit;

namespace Lesson5.Tests
{
    public class ListFacts
    {
        [Fact]
        public void TestListOfStringObjects()
        {

            var stringList = new ListCollection<string> { "string1", "string2" };

            stringList.Add("string3");
            stringList.Add("1");

            var numerator = stringList.GetEnumerator();

            for (int i = 0; i < 10; i++)
            {
                numerator.MoveNext();
            }

            var current = numerator.Current;

            Assert.Equal("1", current);

            Assert.Equal("string1", stringList[0]);
            Assert.Equal("string2", stringList[1]);
            Assert.Equal("string3", stringList[2]);
            Assert.Equal("1", stringList[3]);
            Assert.Equal(4, stringList.Count);

        }


        [Fact]
        public void TestContainsListOfIntegers()
        {

            var intList = new ListCollection<int>();
            intList.Add(123);
            intList.Add(int.MaxValue);
            intList.Add(int.MinValue);

            Assert.True(intList.Contains(123));
            Assert.True(intList.Contains(int.MinValue));
            Assert.Equal(3, intList.Count);

        }


        [Fact]
        public void TestListOfBooleans()
        {

            var boolValues = new ListCollection<bool>
            {
                true,
                false,
                true,
                false
            };

            Assert.True(boolValues.Contains(false));
            Assert.True(boolValues.Contains(true));
            Assert.Equal(0, boolValues.IndexOf(true));
            Assert.Equal(4, boolValues.Count);

        }

        [Fact]
        public void TestInvalidIndexList()
        {

            var boolValues = new ListCollection<bool>
            {
                true,
                false,
                true,
                false
            };


            Exception ex = Assert.Throws<ArgumentException>(() => (boolValues[4] = true));

            Assert.Equal("Invalid Index; must be greater then 0 and less than \r\nParameter name: Count = 4", ex.Message);

            Assert.True(boolValues.Contains(false));
            Assert.True(boolValues.Contains(true));
            Assert.Equal(0, boolValues.IndexOf(true));
            Assert.Equal(4, boolValues.Count);

        }


        [Fact]
        public void TestInsertListOfStringObjectsWithNullValue()
        {

            var objectsList = new ListCollection<string>
            {
                "string0",
                "strin1",
                "string2",
                "string4",
                string.Empty

            };

            objectsList.Insert(3, null);
            Assert.Equal("string0", objectsList[0]);
            Assert.True(objectsList.Contains(null));
            Assert.Equal(6, objectsList.Count);
        }


        [Fact]
        public void Test_Remove_RemoveAt_ClearListOfStringObjects()
        {

            var objectsList = new ListCollection<string>
            {
                "string0",
                "strin1",
                "string2",
                "string4",
                string.Empty

            };

            objectsList.Remove("string0");
            objectsList.RemoveAt(0);
            Assert.Equal("string2", objectsList[0]);
            Assert.Equal(3, objectsList.Count);

            objectsList.Clear();
            Assert.Equal(0, objectsList.Count);
        }


        [Fact]
        public void TestListOfObjects()
        {

            var listOfObjects = new ListCollection<object>
            {
                true,
                false,
                "string",
                null,
                string.Empty,
                int.MaxValue
            };

            listOfObjects.Insert(1, 123);
            listOfObjects.Insert(0, string.Empty);

            Assert.False(listOfObjects.Contains("string2"));
            Assert.True(listOfObjects.Contains(null));
            Assert.Equal(0, listOfObjects.IndexOf(string.Empty));
            Assert.Equal(2, listOfObjects.IndexOf(123));
            Assert.Equal(8, listOfObjects.Count);

        }

    }
}