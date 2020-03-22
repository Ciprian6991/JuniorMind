using System;
using Xunit;
using Lesson7Dictionary;

namespace Lesson7Dictionary.Tests
{
    public class DictionaryFacts
    {
        [Fact]
        public void Test_AddOneElement()
        {
            var dic = new Dictionary<int, string>(5)
            {
                { 1, "a" }
            };
            Assert.True(dic.ContainsKey(1));
        }

        [Fact]
        public void Test_ContainsNot()
        {
            var dic = new Dictionary<int, string>(5)
            {
                { 1, "a" }
            };
            Assert.False(dic.ContainsKey(2));
        }

        [Fact]
        public void Test_EnumeratorReturnsFalseWhenEmptyDictionary()
        {
        var dictionary = new Dictionary<int, int>();

        var enumerator = dictionary.GetEnumerator();

        Assert.False(enumerator.MoveNext());
        Assert.Empty(dictionary);
        }
    }
}
