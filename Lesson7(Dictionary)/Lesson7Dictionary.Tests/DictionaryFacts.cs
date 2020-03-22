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
                new KeyValuePair<int, string>(1, "Ana")
            };
            var enumerator = dictionary.GetEnumerator();

            Assert.Equal(2, dictionary.Count);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(new KeyValuePair<int, string>(11, "1"), enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(new KeyValuePair<int, string>(1, "Ana"), enumerator.Current);
            Assert.False(enumerator.MoveNext());
        }

        [Fact]
        public void Test_KeysProperty()
        {

            var dictionary = new Dictionary<string, string>
            {
                { "Ana", "Andra" },
                { "Vlad", string.Empty },
                { "12", "2" }
            };

            Assert.Equal(new List<string> { "Ana", "Vlad", "12" }, dictionary.Keys);
        }

        [Fact]
        public void Test_KeysPropertyEmptyDictionary()
        {
            var dictionary = new Dictionary<string, string>();

            Assert.Equal(new List<string>(), dictionary.Keys);
        }

        [Fact]
        public void Test_ValuesProperty()
        {

            var dictionary = new Dictionary<string, string>()
            {
                { "Ana", "Andra"},
                { "Vlad", string.Empty},
                { "12", "2" }
            };
            Assert.Equal(new List<string> { "Andra", string.Empty, "2" }, dictionary.Values);
        }

        [Fact]
        public void Test_ValuesPropertyEmptyDictionary()
        {

            var dictionary = new Dictionary<string, string>();

            Assert.Equal(new List<string>(), dictionary.Values);
        }

        [Fact]
        public void Test_ContainsKeyReturnTrue1Element()
        {

            var dictionary = new Dictionary<string, string>
            {
                { "Ana", "1" }
            };

            Assert.Single(dictionary);
            Assert.True(dictionary.ContainsKey("Ana"));
        }

        [Fact]
        public void Test_ContainsKeyConflicts()
        {

            var dictionary = new Dictionary<int, string>();

            dictionary.Add(1, "Ana");
            dictionary.Add(6, "Maria");
            dictionary.Add(11, "Ana");
            dictionary.Add(16, "GTA");

            Assert.Equal(4, dictionary.Count);
            Assert.True(dictionary.ContainsKey(1));
            Assert.True(dictionary.ContainsKey(6));
            Assert.True(dictionary.ContainsKey(11));
            Assert.True(dictionary.ContainsKey(16));
            Assert.False(dictionary.ContainsKey(21));
            Assert.False(dictionary.ContainsKey(7));
            Assert.False(dictionary.ContainsKey(0));
        }
    }
}
