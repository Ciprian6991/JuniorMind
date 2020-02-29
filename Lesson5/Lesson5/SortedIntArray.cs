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

        public override int this[int index]
        {
            get => base[index];
            set
            {
                if (!CheckSetElement(index, value))
                {
                    return;
                }

                base[index] = value;
            }
        }

        public override void Add(int element)
        {
            CheckSize();

            if (Count == 0 || element >= this[Count - 1])
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

        public override void Insert(int index, int element)
        {
            if (!CheckSetElement(index, element))
            {
                return;
            }

            CheckSize();
            ShiftRightFromIndex(index);
            this[index] = element;
            Count++;
        }

        private bool CheckSetElement(int index, int element)
        {
            if (index == 0)
            {
                return Count <= 1 || element <= this[0];
            }

            // adding with .Add()
            if (index == Count - 1)
            {
                return element > this[index];
            }

            // inserting at the end
            if (index == Count)
            {
                return element > this[index - 1];
            }

            return CheckNeighbours(index, element);
        }

        private bool CheckNeighbours(int index, int element)
        {
            return (element <= this[index + 1] || element <= this[index])
                 && element >= this[index - 1];
        }
    }
}
