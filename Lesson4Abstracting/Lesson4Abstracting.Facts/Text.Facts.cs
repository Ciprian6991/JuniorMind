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

        [Fact]
        public void NullParamReturnsNull()
        {
            var truE = new Text("true");
            Assert.Null(truE.Match(null).RemainingText());
        }


        [Fact]
        public void FalseAsParameterShouldReturnTrue()
        {
            var falsE = new Text("false");
            Assert.True(falsE.Match("false").Success());
        }

        [Fact]
        public void FalseAsStringParamReturnsFalseAsString2()
        {
            var falsE = new Text("false");
            Assert.Equal("",falsE.Match("false").RemainingText());
        }


        [Fact]
        public void FalseXAsParameterShouldReturnTrue()
        {
            var falsE = new Text("false");
            Assert.True(falsE.Match("falseX").Success());
        }

        [Fact]
        public void FalseXAsStringParamReturnsFalseAsString2()
        {
            var falsE = new Text("false");
            Assert.Equal("X", falsE.Match("falseX").RemainingText());
        }


        [Fact]
        public void TrueAsParameterShouldReturnFalse()
        {
            var falsE = new Text("false");
            Assert.False(falsE.Match("true").Success());
        }

        [Fact]
        public void TrueAsStringParamReturnsFalseAsString2()
        {
            var falsE = new Text("false");
            Assert.Equal("true", falsE.Match("true").RemainingText());
        }


        [Fact]
        public void EmptyStringParameterShouldReturnFalse2()
        {
            var falsE = new Text("false");
            Assert.False(falsE.Match("").Success());
        }

        [Fact]
        public void EmptyStringParamReturnsEmptyString2()
        {
            var falsE = new Text("false");
            Assert.Equal("", falsE.Match("").RemainingText());
        }


        [Fact]
        public void NullParameterShouldReturnFalse2()
        {
            var falsE = new Text("false");
            Assert.False(falsE.Match(null).Success());
        }

        [Fact]
        public void NullParamReturnsNull2()
        {
            var falsE = new Text("false");
            Assert.Null(falsE.Match(null).RemainingText());
        }


        [Fact]
        public void TrueStringParamReturnsTrueString()
        {
            var empty = new Text("");
            Assert.Equal("true", empty.Match("true").RemainingText());
        }

        [Fact]
        public void TrueStringParameterShouldReturnTrue()
        {
            var empty = new Text("");
            Assert.True(empty.Match("true").Success());
        }


        [Fact]
        public void NullParamReturnsNull3()
        {
            var empty = new Text("");
            Assert.Null(empty.Match(null).RemainingText());
        }

        [Fact]
        public void NullParameterShouldReturnFalse3()
        {
            var empty = new Text("");
            Assert.False(empty.Match(null).Success());
        }
    } 
}
