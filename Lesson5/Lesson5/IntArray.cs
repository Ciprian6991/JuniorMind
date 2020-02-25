using System;

namespace Lesson5
{
    public class IntArray
    {
        private const int SizeFactor = 4;
        private int[] array;
        private int count;

        public IntArray()
        {
            count = 0;
            array = new int[SizeFactor];
        }

        public void Add(int element)
        {
            CheckSize();
            array[count++] = element;
        }

        public int Count()
        {
            return count;
        }

        public int Element(int index)
        {
            return array[index];
        }

        public void SetElement(int index, int element)
        {
            array[index] = element;
        }

        public bool Contains(int element)
        {
            return IndexOf(element) != -1;
        }

        public int IndexOf(int element)
        {
            for (int i = 0; i <= count; i++)
            {
                if (array[i] == element)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, int element)
        {
            CheckSize();
            ShiftRightFromIndex(index);
            array[index] = element;
        }

        public void Clear()
        {
            count = 0;
        }

        public void Remove(int element)
        {
            RemoveAt(IndexOf(element));
        }

        public void RemoveAt(int index)
        {
            ShiftLeftFromIndex(index);
            this.count--;
        }

        private void ShiftLeftFromIndex(int index)
        {
            for (int i = index; i < this.count - 1; i++)
            {
                array[i] = array[i + 1];
            }
        }

        private void ShiftRightFromIndex(int index)
        {
            for (int i = this.count - 1; i > index; i--)
            {
                array[i] = array[i - 1];
            }
        }

        private void CheckSize()
            {
            if (count < array.Length - 1 - 1)
            {
                return;
            }

            Array.Resize(ref array, array.Length + SizeFactor);
        }
    }
}
