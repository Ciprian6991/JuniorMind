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

        [Fact]
        public void Test_Clear()
        {
            var dic = new Dictionary<int, int>()
            {
                {123, 123},
                {456, 456}
            };

            Assert.Equal(2, dic.Count);

            dic.Clear();

            Assert.Equal(0, dic.Count);
        }


        [Fact]
        public void Test_TryGetValue()
        {

            var dictionary = new Dictionary<string, string>
            {
                { "Ana", "Andra" },
                { "Vlad", string.Empty },
                { "12", "2" },
                { "asd", "dsa" },
            };

            string value;

            Assert.True(dictionary.TryGetValue("12", out value));
            Assert.Equal("2", value);
        }

        [Fact]
        public void Test_RemoveReturnsFalseForNotExistingKey()
        {

            var dictionary = new Dictionary<int, string>()
            {
                { 1, "a" },
                { 6, "b" },
                { 11, "c" },
                { 16, "d" }
            };

            Assert.False(dictionary.Remove(2));
        }

        [Fact]
        public void Test_RemoveReturnsTrueAndRemovesTheFirstKeyInTheBucket()
        {

            var dictionary = new Dictionary<int, string>()
            {
                { 1, "a" },
                { 2, "b" },
                { 10, "c" },
                { 7, "d" },
                { 12, "e" }
            };

            Assert.Equal(5, dictionary.Count);

            Assert.True(dictionary.Remove(12));

            Assert.Equal(4, dictionary.Count);
            var enumerator = dictionary.GetEnumerator();

            Assert.True(enumerator.MoveNext());
            Assert.Equal(new KeyValuePair<int, string>(1, "a"), enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(new KeyValuePair<int, string>(2, "b"), enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(new KeyValuePair<int, string>(10, "c"), enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(new KeyValuePair<int, string>(7, "d"), enumerator.Current);
            Assert.False(enumerator.MoveNext());
        }

        [Fact]
        public void Test_AddMethodShouldResizeWhenDictionaryIsFull()
        {
            var dictionary = new Dictionary<int, int>()
            {
                {0, 100},
                {1, 100 },
                {3, 100 },
                {5, 100 },
                {16, 100 }
            };

            dictionary.Add(2, 100);

            Assert.True(dictionary.ContainsKey(0));
            Assert.True(dictionary.ContainsKey(2));
            Assert.Equal(6, dictionary.Count);
        }


        [Fact]
        public void Test_SetGetForValidElements()
        {

            var dictionary = new Dictionary<int, string>()
            {
                { 1, "a" },
                { 2, "b" },
                { 10, "c" },
                { 7, "d" },
                { 12, "e" }
            };

            Assert.Equal("e", dictionary[12]);

            dictionary[12] = "f";

            Assert.Equal("f", dictionary[12]);
        }

        [Fact]
        public void Test_RemoveReturnsTrueAndRemovesConflictedKeys()
        {

            var dictionary = new Dictionary<int, string>()
            {
                { 1, "a" },
                { 2, "b" },
                { 10, "c" },
                { 7, "d" },
                { 12, "e" }
            };

            Assert.Equal(5, dictionary.Count);

            Assert.True(dictionary.Remove(7));
            Assert.True(dictionary.Remove(1));

            Assert.Equal(3, dictionary.Count);
            var enumerator = dictionary.GetEnumerator();

            Assert.True(enumerator.MoveNext());
            Assert.Equal(new KeyValuePair<int, string>(2, "b"), enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(new KeyValuePair<int, string>(10, "c"), enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(new KeyValuePair<int, string>(12, "e"), enumerator.Current);
            Assert.False(enumerator.MoveNext());
        }


        [Fact]
        public void Test_RemoveKeyValuePairReturnsTrueAndRemovesConflictedKeys()
        {
            var pair = new KeyValuePair<int, string>(10, "c");

            var dictionary = new Dictionary<int, string>()
            {
                { 1, "a" },
                { 2, "b" },
                { 10, "c" },
                { 7, "d" },
                { 12, "e" }
            };

            Assert.Equal(5, dictionary.Count);

            Assert.True(dictionary.Remove(pair));

            Assert.Equal(4, dictionary.Count);
            var enumerator = dictionary.GetEnumerator();

            Assert.True(enumerator.MoveNext());
            Assert.Equal(new KeyValuePair<int, string>(1, "a"), enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(new KeyValuePair<int, string>(2, "b"), enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(new KeyValuePair<int, string>(7, "d"), enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(new KeyValuePair<int, string>(12, "e"), enumerator.Current);
            Assert.False(enumerator.MoveNext());
        }

        [Fact]
        public void Test_RemoveKeyValuePairReturnsFalse()
        {
            var pair = new KeyValuePair<int, string>(11, "c");

            var dictionary = new Dictionary<int, string>()
            {
                { 1, "a" },
                { 2, "b" },
                { 10, "c" },
                { 7, "d" },
                { 12, "e" }
            };

            Assert.Equal(5, dictionary.Count);

            Assert.False(dictionary.Remove(pair));

            Assert.Equal(5, dictionary.Count);
            var enumerator = dictionary.GetEnumerator();

            Assert.True(enumerator.MoveNext());
            Assert.Equal(new KeyValuePair<int, string>(1, "a"), enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(new KeyValuePair<int, string>(2, "b"), enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(new KeyValuePair<int, string>(10, "c"), enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(new KeyValuePair<int, string>(7, "d"), enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(new KeyValuePair<int, string>(12, "e"), enumerator.Current);
            Assert.False(enumerator.MoveNext());
        }

        [Fact]
        public void Test_RemoveAndAddOnFreePositions()
        {

            var dictionary = new Dictionary<int, string>()
            {
                { 1, "a" },
                { 2, "b" },
                { 10, "c" },
                { 7, "d" },
                { 12, "e" }
            };

            Assert.Equal(5, dictionary.Count);

            Assert.True(dictionary.Remove(7));
            Assert.True(dictionary.Remove(1));

            dictionary.Add(17, "f");

            Assert.Equal(4, dictionary.Count);
            var enumerator = dictionary.GetEnumerator();

            Assert.True(enumerator.MoveNext());
            Assert.Equal(new KeyValuePair<int, string>(17, "f"), enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(new KeyValuePair<int, string>(2, "b"), enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(new KeyValuePair<int, string>(10, "c"), enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(new KeyValuePair<int, string>(12, "e"), enumerator.Current);
            Assert.False(enumerator.MoveNext());
        }

        [Fact]
        public void Test_CopyMethodArrayHasEnoughCapacity()
        {
            var dictionary = new Dictionary<int, int>();
            KeyValuePair<int, int>[] array = new KeyValuePair<int, int>[6];

            dictionary.Add(11, 1);
            dictionary.Add(2, 3);
            dictionary.Add(3, 4);
            dictionary.CopyTo(array, 2);

            Assert.Equal(3, dictionary.Count);
            Assert.NotEqual(1, array[5].Value);
            Assert.Equal(3, array[4].Key);
            Assert.Equal(4, array[4].Value);
            Assert.NotEqual(11, array[0].Key);
            Assert.NotEqual(4, array[5].Value);

        }


        [Fact]
        public void Test_ReadOnly()
        {
            var pair = new KeyValuePair<int, string>(10, "c");

            var dictionary = new Dictionary<int, string>()
            {
                { 1, "a" },
                { 2, "b" },
                { 10, "c" },
                { 7, "d" },
                { 12, "e" }
            };

            var dictionary2 = dictionary.AsReadOnly();

            Assert.Equal(5, dictionary2.Count);

            var check = Assert.Throws<NotSupportedException>(() => dictionary2.Remove(pair));

            Assert.Equal("Dictionary is read only!", check.Message);
        }


        [Fact]
        public void Test_ExceptionAddMethodShouldNotAddSameKeyTwice()
        {
            var dictionary = new Dictionary<int, string>()
            {
                { 1, "a" },
            };

            var check = Assert.Throws<ArgumentException>(() => dictionary.Add(1, "b"));

            var enumerator = dictionary.GetEnumerator();
            enumerator.MoveNext();

            Assert.Single(dictionary);
            Assert.Equal(new KeyValuePair<int, string>(1, "a"), enumerator.Current);
            Assert.False(enumerator.MoveNext());
            

            Assert.Equal("Key 1 already exists in dictionary!", check.Message);
        }

        [Fact]
        public void Test_ExceptionGetSetIndexerShouldThrowExceptionWhenKeyIsNull()
        {
            var dictionary = new Dictionary<string, string>()
            {
                { "asd", "a" },
            };

            Assert.Equal("a", dictionary["asd"]);
            dictionary["asd"] = "abc";

            var exception1 = Assert.Throws<ArgumentNullException>(() => dictionary[null]);
            var exception2 = Assert.Throws<ArgumentNullException>(() => dictionary[null] = "m");

            Assert.Equal("key", exception1.ParamName);
            Assert.Equal("key", exception2.ParamName);
        }

        [Fact]
        public void Test_ExceptionWhenKeyNOTfound()
        {
            var dictionary = new Dictionary<int, string>()
            {
                { 1, "a" },
            };

            var exception1 = Assert.Throws<KeyNotFoundException>(() => dictionary[100]);
            var exception2 = Assert.Throws<KeyNotFoundException>(() => dictionary[100] = "10");

            Assert.Equal("Key 100 not found in dictionary!", exception1.Message);
            Assert.Equal("Key 100 not found in dictionary!", exception2.Message);

        }
    }
}
