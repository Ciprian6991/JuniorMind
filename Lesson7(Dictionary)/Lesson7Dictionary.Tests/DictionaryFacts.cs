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
    }
}
