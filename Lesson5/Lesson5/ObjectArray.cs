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
