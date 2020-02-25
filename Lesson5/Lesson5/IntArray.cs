using System;

namespace Lesson5
{
    public class IntArray
    {
        private int[] array;

        public IntArray()
        {
            array = new int[0];
        }

        public void Add(int element)
        {
            ModifyArraySizeBy(1);
            array[array.Length - 1] = element;
        }

        public int Count()
        {
            return array.Length;
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
            for (int i = 0; i < array.Length; i++)
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
            ModifyArraySizeBy(1);
            ShiftRightFromIndex(index);
            array[index] = element;
        }

        public void Clear()
        {
            Array.Resize(ref array, 0);
        }

        public void Remove(int element)
        {
            RemoveAt(IndexOf(element));
        }

        public void RemoveAt(int index)
        {
            if (Count() - 1 < index)
            {
                return;
            }

            ShiftLeftFromIndex(index);
            Array.Resize(ref array, array.Length - 1);
        }

        private void ModifyArraySizeBy(int size)
        {
            Array.Resize(ref array, array.Length + size);
        }

        private void ShiftLeftFromIndex(int index)
        {
            for (int i = index; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }
        }

        private void ShiftRightFromIndex(int index)
        {
            for (int i = array.Length - 1; i > index; i--)
            {
                array[i] = array[i - 1];
            }
        }
    }
}
