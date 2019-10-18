using JSON1;
using Xunit;


namespace JSON1.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void SimpleStringInsideQuatationMarksIsValid()
        {
            Assert.True(Program.IsAValidJsonString("\"valid\""));
        }
        
        [Fact]
        public void ComplexStringInsideQuatationMarksIsValid()
        {
            Assert.True(Program.IsAValidJsonString("\"Test\\u0097\nAnother line\""));
        }
    }
}
