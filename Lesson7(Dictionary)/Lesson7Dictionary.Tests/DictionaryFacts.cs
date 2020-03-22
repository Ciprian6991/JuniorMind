using System;
using Xunit;
using Lesson7Dictionary;
using System.Collections.Generic;

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

        [Fact]
        public void Test_EnumeratorShouldProperlyWorkWhenDictionaryhas1element()
        {
            var dictionary = new Dictionary<int, int>();
            var enumerator = dictionary.GetEnumerator();

            dictionary.Add(1, 1);
            enumerator.MoveNext();

            Assert.Equal(1, enumerator.Current.Key);
            Assert.Equal(1, enumerator.Current.Value);
            Assert.False(enumerator.MoveNext());
        }


        [Fact]
        public void Test_EnumeratorShouldWorkWhenDictionaryHasManyElements()
        {
            var dictionary = new Dictionary<int, int>();
            var enumerator = dictionary.GetEnumerator();

            dictionary.Add(1, 1);
            dictionary.Add(2, 1);
            dictionary.Add(3, 100);
            enumerator.MoveNext();

            Assert.Equal(1, enumerator.Current.Key);
            Assert.Equal(1, enumerator.Current.Value);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(2, enumerator.Current.Key);
            Assert.Equal(1, enumerator.Current.Value);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(3, enumerator.Current.Key);
            Assert.Equal(100, enumerator.Current.Value);
            Assert.False(enumerator.MoveNext());
        }


        [Fact]
        public void Test_EnumeratorShouldWorkSameHashCodeForMoreElements()
        {
            var dictionary = new Dictionary<int, int>();
            var enumerator = dictionary.GetEnumerator();

            dictionary.Add(1, 1);
            dictionary.Add(6, 2);
            dictionary.Add(3, 100);
            dictionary.Add(8, 3);
            enumerator.MoveNext();

            Assert.Equal(new KeyValuePair<int, int>(1, 1), enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(new KeyValuePair<int, int>(6, 2), enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(new KeyValuePair<int, int>(3, 100), enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(new KeyValuePair<int, int>(8, 3), enumerator.Current);
            Assert.False(enumerator.MoveNext());
        }

        [Fact]
        public void Test_AddMethodNoConflict()
        {
            var dictionary = new Dictionary<int, int>
            {
                { 11, 2 }
            };

            var enumerator = dictionary.GetEnumerator();

            Assert.Single(dictionary);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(new KeyValuePair<int, int>(11, 2), enumerator.Current);
        }


        [Fact]
        public void Test_AddSameHashCode()
        {

            var dictionary = new Dictionary<int, string>();

            dictionary.Add(11, "1");
            dictionary.Add(6, "1");
            dictionary.Add(1, "Ana");
            var enumerator = dictionary.GetEnumerator();

            Assert.Equal(3, dictionary.Count);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(new KeyValuePair<int, string>(11, "1"), enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(new KeyValuePair<int, string>(6, "1"), enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(new KeyValuePair<int, string>(1, "Ana"), enumerator.Current);
            Assert.False(enumerator.MoveNext());
        }

        [Fact]
        public void Test_AddMethodOverload()
        {
            var dictionary = new Dictionary<int, string>
            {
                { 11, "1" },
                new KeyValuePair<int, string>(11, "Ana")
            };
            var enumerator = dictionary.GetEnumerator();

            Assert.Equal(2, dictionary.Count);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(new KeyValuePair<int, string>(11, "1"), enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(new KeyValuePair<int, string>(11, "Ana"), enumerator.Current);
            Assert.False(enumerator.MoveNext());
        }
    }
}
