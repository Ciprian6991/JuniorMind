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

        [Fact]
        public void SimpleTextWithoutOneOfTheQuatationMarkOnLeftSideIsNotValid()
        {
            Assert.False(Program.IsAValidJsonString("notValid\""));
        }

        [Fact]
        public void SimpleTextWithoutOneOfTheQuatationMarkOnRightSideIsNotValid()
        {
            Assert.False(Program.IsAValidJsonString("\"notValid"));
        }


        [Fact]
        public void SimpleTextWithBackslashInsideIsNotValid()
        {
            Assert.False(Program.IsAValidJsonString("\"\\Test\""));
        }

        [Fact]
        public void SimpleTextWithQuatationMarkInsideIsNotValid()
        {
            Assert.False(Program.IsAValidJsonString("\"Te\"st\""));
        }

        [Fact]
        public void PositiveNaturalNumberIsValid()
        {
            Assert.True(Program.IsValidJsonNumber("123"));
        }

        [Fact]
        public void NegativeNaturalNumberIsValid()
        {
            Assert.True(Program.IsValidJsonNumber("-123"));
        }

        [Fact]
        public void OneNegativeSignIsInvalid()
        {
            Assert.False(Program.IsValidJsonNumber("-"));
        }

        [Fact]
        public void OneNumberWithoutADigitAndSpecialCharactersIsFalse()
        {
            Assert.False(Program.IsValidJsonNumber("123.E123A"));
        }
    }
}
