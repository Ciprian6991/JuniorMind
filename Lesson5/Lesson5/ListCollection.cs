using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lesson5
{
    public class ListCollection<T> : IList<T>
    {
        protected const int SizeFactor = 4;
        private T[] array;

        public ListCollection()
        {
            array = new T[SizeFactor];
        }

        public int Count { get; private set; }

        public bool IsReadOnly { get => false; }

        public virtual T this[int index]
        {
            get => array[index];
            set
            {
                    if (index < Count)
                    {
                        array[index] = value;
                    }
                    else
                    {
                        throw new ArgumentException("Invalid Index; must be less than ", "Count = " + Count.ToString());
                    }
            }
        }

        public virtual void Add(T item)
        {
            CheckSize();
            array[Count++] = item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)array).GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return array[i];
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if ((item == null && array[i] == null)
                    || item?.Equals(array[i]) == true)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public virtual void Insert(int index, T item)
        {
            CheckSize();
            ShiftRightFromIndex(index);
            array[index] = item;
            Count++;
        }

        public void RemoveAt(int index)
        {
            ShiftLeftFromIndex(index);
            Count--;
        }

        public void Clear()
        {
            Count = 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null || arrayIndex < 0 || arrayIndex < Count || array.Length < Count + arrayIndex)
            {
                return;
            }

            int usedIndex = 0;
            for (int i = arrayIndex; i < Count + arrayIndex; i++)
            {
                array[i] = this.array[usedIndex++];
            }
        }

        public bool Remove(T item)
        {
            int initialCount = Count;
            if (IndexOf(item) != -1)
            {
                RemoveAt(IndexOf(item));
            }

            return initialCount > Count;
        }

        public void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        private void ShiftLeftFromIndex(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                array[i] = array[i + 1];
            }
        }

        private void ShiftRightFromIndex(int index)
        {
            for (int i = Count; i > index; i--)
            {
                array[i] = array[i - 1];
            }
        }

        private void CheckSize()
            {
            if (Count != array.Length)
            {
                return;
            }

            Array.Resize(ref array, array.Length + SizeFactor);
        }
    }
}
