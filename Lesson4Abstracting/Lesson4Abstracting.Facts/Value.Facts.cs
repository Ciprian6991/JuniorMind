using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Lesson4Abstracting.Facts
{
    public class ValueFacts
    {
        [Fact]
        public void TestForSimpleTrueFalseNull()
        {
            var value = new Value();
            const string text = "true";
            Assert.True(value.Match(text).Success());
        }


        [Fact]
        public void TestForString()
        {
            var value = new Value();
            const string text = "\"Abc123\"";
            Assert.True(value.Match(text).Success());
        }


        [Fact]
        public void TestForNumber()
        {
            var value = new Value();
            const string number = "-12.3e";
            Assert.True(value.Match(number).Success());
        }


        [Fact]
        public void TestForArrayWs()
        {
            var value = new Value();
            const string number = "[  ]";
            Assert.True(value.Match(number).Success());
        }


    }
}
