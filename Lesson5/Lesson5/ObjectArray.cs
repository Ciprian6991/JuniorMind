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
                if (objArray[i].Equals(element))
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
