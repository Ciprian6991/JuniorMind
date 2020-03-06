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
    }
}