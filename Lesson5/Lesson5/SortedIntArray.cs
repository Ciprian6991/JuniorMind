using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson5
{
    public class SortedIntArray : IntArray
    {
        public SortedIntArray() : base()
        {
        }

        public override void Add(int element)
        {
            CheckSize();

            if (Count == 0 || element > this[Count - 1])
            {
                this[Count++] = element;
            }
            else
            {
                for (int i = 0; i < Count; i++)
                {
                    if (element < this[i])
                    {
                        Insert(i, element);
                        break;
                    }
                }
            }
        }
    }
}
