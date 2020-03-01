using System;

namespace Lesson5
{
    public class IntArray
    {
        private const int SizeFactor = 4;
        private int[] array;

        public IntArray()
        {
            array = new int[SizeFactor];
        }

        public int Count { get; set; }

        public virtual int this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        public virtual void Add(int element)
        {
            CheckSize();
            array[Count++] = element;
        }

        public bool Contains(int element)
        {
            return IndexOf(element) != -1;
        }

        public int IndexOf(int element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (array[i] == element)
                {
                    return i;
                }
            }

            return -1;
        }

        public virtual void Insert(int index, int element)
        {
            CheckSize();
            ShiftRightFromIndex(index);
            array[index] = element;
            Count++;
        }

        public void Clear()
        {
            Count = 0;
        }

        public void Remove(int element)
        {
            RemoveAt(IndexOf(element));
        }

        public void RemoveAt(int index)
        {
            ShiftLeftFromIndex(index);
            this.Count--;
        }

        protected void CheckSize()
        {
            if (Count <= array.Length - 1)
            {
                return;
            }

            Array.Resize(ref array, array.Length + SizeFactor);
        }

        protected void ShiftLeftFromIndex(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                array[i] = array[i + 1];
            }
        }

        protected void ShiftRightFromIndex(int index)
        {
            for (int i = this.Count; i > index; i--)
            {
                array[i] = array[i - 1];
            }
        }
    }
}
