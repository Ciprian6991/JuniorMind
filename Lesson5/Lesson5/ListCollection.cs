using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lesson5
{
    public class ListCollection<T> : IEnumerable<T>
    {
        protected const int SizeFactor = 4;
        private T[] array;

        public ListCollection()
        {
            array = new T[SizeFactor];
        }

        public int Count { get; private set; }

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

        public virtual void Add(T element)
        {
            CheckSize();
            array[Count++] = element;
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

        public int IndexOf(T element)
        {
            for (int i = 0; i < Count; i++)
            {
                if ((element == null && array[i] == null)
                    || element?.Equals(array[i]) == true)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Contains(T element)
        {
            return IndexOf(element) != -1;
        }

        public virtual void Insert(int index, T element)
        {
            CheckSize();
            ShiftRightFromIndex(index);
            array[index] = element;
            Count++;
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
