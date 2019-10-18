using JSON1;
using Xunit;


namespace JSON1.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestForASimpleStringInsideQuatationMarks()
        {
            Assert.True(Program.IsAValidJsonString("\"valid\""));
        }
    }
}
