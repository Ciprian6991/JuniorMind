using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lesson5
{
    public class ReadOnlyListCollection<T> : IList<T>
    {
        private readonly IList<T> list;

        public ReadOnlyListCollection(IList<T> list)
        {
            this.list = list;
        }

        public int Count => list.Count;

        public bool IsReadOnly => true;

        public T this[int index] { get => list[index]; set => throw ReadOnlyException(); }

        public void Add(T item)
        {
            throw ReadOnlyException();
        }

        public void Clear()
        {
            throw ReadOnlyException();
        }

        public bool Contains(T item)
        {
            return list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw ReadOnlyException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            throw ReadOnlyException();
        }

        public bool Remove(T item)
        {
            throw ReadOnlyException();
        }

        public void RemoveAt(int index)
        {
            throw ReadOnlyException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)list).GetEnumerator();
        }

        private Exception ReadOnlyException()
        {
            throw new NotSupportedException("List is readonly!");
        }
    }
}
