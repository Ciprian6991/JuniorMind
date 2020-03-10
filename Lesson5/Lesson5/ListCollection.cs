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

        public bool IsReadOnly { get; private set; }

        public virtual T this[int index]
        {
            get
            {
                CheckIfListIsEmpty();
                CheckParameter(index);
                return array[index];
            }

            set
            {
                CheckIfListIsEmpty();
                CheckParameter(index);
                CheckIfListIsReadonly();
                array[index] = value;
            }
        }

        public virtual void Add(T item)
        {
            CheckIfListIsReadonly();
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
            CheckParameter(index);
            CheckIfListIsReadonly();
            CheckSize();
            ShiftRightFromIndex(index);
            array[index] = item;
            Count++;
        }

        public void RemoveAt(int index)
        {
            CheckParameter(index);
            CheckIfListIsReadonly();
            ShiftLeftFromIndex(index);
            Count--;
        }

        public void Clear()
        {
            CheckIfListIsReadonly();
            Count = 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            CheckIfArrayIsNull(array);
            if (arrayIndex < 0 || arrayIndex < Count || array.Length < Count + arrayIndex)
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
            CheckIfListIsReadonly();
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

        public void AsReadOnly()
        {
            IsReadOnly = true;
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

        private void CheckIfListIsEmpty()
            {
            if (Count != 0)
            {
                return;
            }

            throw new ArgumentException(message: "List is empty!");
        }

        private void CheckParameter(int index)
            {
            if (index >= 0 && index < Count)
            {
                return;
            }

            throw new ArgumentException("Invalid Index; must be greater then 0 and less than ", "Count = " + Count.ToString());
        }

        private void CheckIfListIsReadonly()
            {
            if (!IsReadOnly)
            {
                return;
            }

            throw new NotSupportedException("List is readonly!");
        }

        private void CheckIfArrayIsNull(T[] array)
            {
            if (array != null)
            {
                return;
            }

            throw new ArgumentNullException(paramName: nameof(array));
        }
    }
}
