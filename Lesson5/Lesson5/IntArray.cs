using System;

namespace Lesson5
{
    public class IntArray
    {
        private const int SizeFactor = 4;
        private int[] array;
        private int index;

        public IntArray()
        {
            index = 0;
            array = new int[SizeFactor];
        }

        public void Add(int element)
        {
            if (index < array.Length - 1 - 1)
            {
                array[index++] = element;
            }
            else
            {
                ModifyArraySizeBy(SizeFactor);
                array[index++] = element;
            }
        }

        public int Count()
        {
            return index;
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
            for (int i = 0; i <= index; i++)
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
            for (int i = 0; i <= index; i++)
            {
                array[i] = 0;
            }

            index = 0;
        }

        public void Remove(int element)
        {
            RemoveAt(IndexOf(element));
        }

        public void RemoveAt(int index)
        {
            ShiftLeftFromIndex(index);
            this.index--;
        }

        private void ModifyArraySizeBy(int size)
        {
            Array.Resize(ref array, array.Length + size);
        }

        private void ShiftLeftFromIndex(int index)
        {
            for (int i = index; i < this.index - 1; i++)
            {
                array[i] = array[i + 1];
            }
        }

        private void ShiftRightFromIndex(int index)
        {
            for (int i = this.index - 1; i > index; i--)
            {
                array[i] = array[i - 1];
            }
        }
    }
}
