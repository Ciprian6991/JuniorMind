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
    }
}
