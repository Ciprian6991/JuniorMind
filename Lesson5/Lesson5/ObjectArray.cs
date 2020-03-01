using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson5
{
    public class ObjectArray
    {
        protected const int SizeFactor = 4;
        private object[] objArray;

        public ObjectArray()
        {
            objArray = new object[SizeFactor];
        }

        public int Count { get; private set; }

        public virtual object this[int index]
        {
            get => objArray[index];
            set => objArray[index] = value;
        }

        public virtual void Add(object element)
        {
            CheckSize();
            objArray[Count++] = element;
        }

        public int IndexOf(object element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (objArray[i] == element || (objArray[i]?.Equals(element) == true))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Contains(object element)
        {
            return IndexOf(element) != -1;
        }

        public virtual void Insert(int index, object element)
        {
            CheckSize();
            ShiftRightFromIndex(index);
            objArray[index] = element;
            Count++;
        }

        public void RemoveAt(int index)
        {
            ShiftLeftFromIndex(index);
            Count--;
        }

        public void Remove(object element)
        {
            RemoveAt(IndexOf(element));
        }

        public void Clear()
        {
            Count = 0;
        }

        private void ShiftLeftFromIndex(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                objArray[i] = objArray[i + 1];
            }
        }

        private void ShiftRightFromIndex(int index)
        {
            for (int i = Count; i > index; i--)
            {
                objArray[i] = objArray[i - 1];
            }
        }

        private void CheckSize()
            {
            if (Count != objArray.Length)
            {
                return;
            }

            Array.Resize(ref objArray, objArray.Length + SizeFactor);
        }
    }
}
