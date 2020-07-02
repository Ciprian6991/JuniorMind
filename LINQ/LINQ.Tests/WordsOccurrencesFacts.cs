using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LINQ.Tests
{
    public class WordsOccurrencesFacts
    {
        [Fact]
        public void Test_GetWordsOccurrences()
        {
            var text = "trei doi trei trei unu doi";

            var mainClass = new WordsOccurrences(text);

            var result = mainClass.GetWordsOccurrences();

            var expectedResult = " trei => 3 \n doi => 2 \n unu => 1 \n ";

            Assert.Equal(expectedResult, result);
        
        }

        [Fact]
        public void Test_GetWordsOccurrences_OneWord()
        {
            var text = "trei trei trei trei trei";
            var mainClass = new WordsOccurrences(text);

            var result = mainClass.GetWordsOccurrences();

            var expectedResult = " trei => 5 \n ";

            Assert.Equal(expectedResult, result);

        }

        [Fact]
        public void Test_GetWordsOccurrences_Exception()
        {
            string text = null;

            var exception = Assert.Throws<ArgumentNullException>(() => new WordsOccurrences(text));

            Assert.Equal("input", exception.ParamName);

        }
    }
}
