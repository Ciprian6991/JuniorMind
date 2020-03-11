using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Lesson5.Tests
{
    public class ReadOnlyListCollectionFacts
    {
        [Fact]
        public void Test_ExceptionRemoveAtListIsReadOnly()
        {
            var intList = new ListCollection<int> { 1, 2, 3, 4, 5 };
            var readOnly = new ReadOnlyListCollection<int>(intList);

            var checkGet = Assert.Throws<NotSupportedException>(() => readOnly.RemoveAt(2));

            Assert.Equal("List is readonly!", checkGet.Message);
        }

        [Fact]
        public void Test_ExceptionSettingListIsReadOnly()
        {
            var intList = new ListCollection<int> { 1, 2, 3, 4, 5 };
            var readOnly = new ReadOnlyListCollection<int>(intList);

            var checkGet = Assert.Throws<NotSupportedException>(() => readOnly[0] = 1);

            Assert.Equal("List is readonly!", checkGet.Message);
        }


        [Fact]
        public void Test_ExceptionCountListIsReadOnly()
        {
            var intList = new ListCollection<int> { 1, 2, 3, 4, 5 };
            var readOnly = new ReadOnlyListCollection<int>(intList);

            Assert.Equal(5, readOnly.Count);
        }

        [Fact]
        public void Test_ExceptionAddListIsReadOnly()
        {
            var intList = new ListCollection<int> { 1, 2, 3, 4, 5 };
            var readOnly = new ReadOnlyListCollection<int>(intList);

            var checkGet = Assert.Throws<NotSupportedException>(() => readOnly.Add(1));

            Assert.Equal("List is readonly!", checkGet.Message);
        }

        [Fact]
        public void Test_ExceptionClearListIsReadOnly()
        {
            var intList = new ListCollection<int> { 1, 2, 3, 4, 5 };
            var readOnly = new ReadOnlyListCollection<int>(intList);

            var checkGet = Assert.Throws<NotSupportedException>(() => readOnly.Clear());

            Assert.Equal("List is readonly!", checkGet.Message);
        }


        [Fact]
        public void Test_ExceptionContainsListIsReadOnly()
        {
            var intList = new ListCollection<int> { 1, 2, 3, 4, 5 };
            var readOnly = new ReadOnlyListCollection<int>(intList);

            Assert.Contains(1, readOnly);
        }


        [Fact]
        public void Test_CopyListToArrayReadOnly()
        {

            var intList = new ListCollection<int> { 1, 2, 3 };
            var readOnly = new ReadOnlyListCollection<int>(intList);
            int[] array ={ 1, 2 };

            var checkGet = Assert.Throws<NotSupportedException>(() => readOnly.CopyTo(array, 3));

            Assert.Equal("List is readonly!", checkGet.Message);
        }

        [Fact]
        public void Test_ExceptionIndexOfListIsReadOnly()
        {
            var intList = new ListCollection<int> { 1, 2, 3, 4, 5 };
            var readOnly = new ReadOnlyListCollection<int>(intList);

            Assert.Equal(2, readOnly.IndexOf(3));
        }

        [Fact]
        public void Test_ExceptionInsertListIsReadOnly()
        {
            var intList = new ListCollection<int> { 1, 2, 3, 4, 5 };
            var readOnly = new ReadOnlyListCollection<int>(intList);

            var checkGet = Assert.Throws<NotSupportedException>(() => readOnly.Insert(1,2));

            Assert.Equal("List is readonly!", checkGet.Message);
        }


        [Fact]
        public void Test_ExceptionEnumeratorListIsReadOnly()
        {
            var intList = new ListCollection<int> { 1, 2, 3, 4, 5 };
            var readOnly = new ReadOnlyListCollection<int>(intList);

            var checkGet = Assert.Throws<NotSupportedException>(() => readOnly.RemoveAt(2));

            var enumerator = readOnly.GetEnumerator();
            enumerator.MoveNext();
            enumerator.MoveNext();
            enumerator.MoveNext();
            enumerator.MoveNext();
            enumerator.MoveNext();

            Assert.Equal(5, enumerator.Current);
        }
    }
}
