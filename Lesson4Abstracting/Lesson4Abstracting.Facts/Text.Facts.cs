using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Lesson4Abstracting.Facts
{
    public class TextFacts
    {
        [Fact]
        public void TrueAsStringParameterShouldReturnTrue()
        {
            var truE = new Text("true");
            Assert.True(truE.Match("true").Success());
        }

        [Fact]
        public void TrueAsStringParamReturnsEmptyStringFromSameParameter()
        {
            var truE = new Text("true");
            Assert.Equal("",truE.Match("true").RemainingText());
        }


        [Fact]
        public void TrueXAsStringParameterShouldReturnTrue()
        {
            var truE = new Text("true");
            Assert.True(truE.Match("trueX").Success());
        }

        [Fact]
        public void TrueXAsStringParamReturnsXAsString()
        {
            var truE = new Text("true");
            Assert.Equal("X", truE.Match("trueX").RemainingText());
        }


        [Fact]
        public void FalseAsStringParameterShouldReturnFalse()
        {
            var truE = new Text("true");
            Assert.False(truE.Match("false").Success());
        }

        [Fact]
        public void FalseAsStringParamReturnsFalseAsString()
        {
            var truE = new Text("true");
            Assert.Equal("false", truE.Match("false").RemainingText());
        }


        [Fact]
        public void EmptyStringParameterShouldReturnFalse()
        {
            var truE = new Text("true");
            Assert.False(truE.Match("").Success());
        }

        [Fact]
        public void EmptyStringParamReturnsEmptyString()
        {
            var truE = new Text("true");
            Assert.Equal("", truE.Match("").RemainingText());
        }


        [Fact]
        public void NullParameterShouldReturnFalse()
        {
            var truE = new Text("true");
            Assert.False(truE.Match(null).Success());
        }
    } 
}
