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
        public void UnicodeStringInsideQuatationMarksIsValid()
        {
            Assert.True(Program.IsAValidJsonString("\"Test\\u0097\nAnother line\""));
        }

        [Fact]
        public void UnicodeStringInsideQuatationMarksIsNotValid()
        {
            Assert.False(Program.IsAValidJsonString("\"Test\\u0097\nAnother line\\u12\""));
        }
    }
}
