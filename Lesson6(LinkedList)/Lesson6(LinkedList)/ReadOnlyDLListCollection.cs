using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lesson6LinkedList
{
    public class ReadOnlyDLListCollection<T> : ICollection<T>
    {
        private readonly ICollection<T> dlinkedList;

        public ReadOnlyDLListCollection(ICollection<T> dllist)
        {
            dlinkedList = dllist;
        }

        public int Count => dlinkedList.Count;

        public bool IsReadOnly => true;

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
            return dlinkedList.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw ReadOnlyException();
        }

        public bool Remove(T item)
        {
            throw ReadOnlyException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return dlinkedList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)dlinkedList).GetEnumerator();
        }

        private Exception ReadOnlyException()
        {
            throw new NotSupportedException("List is readonly!");
        }
    }
}
