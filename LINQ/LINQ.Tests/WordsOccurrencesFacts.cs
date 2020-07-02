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
    }
}
