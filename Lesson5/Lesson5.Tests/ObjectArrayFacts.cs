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
    }
}
