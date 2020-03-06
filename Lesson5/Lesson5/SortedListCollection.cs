using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson5
{
    public class SortedListCollection<T> : ListCollection<T>
                 where T : IComparable<T>
    {
        public SortedListCollection() : base()
        {
        }

        public override T this[int index]
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

        public override void Add(T element)
        {
            if (Count == 0 || this[Count - 1].CompareTo(element) <= 0)
            {
                base.Insert(Count, element);
            }
            else
            {
                for (int i = 0; i < Count; i++)
                {
                    if (this[i].CompareTo(element) > 0)
                    {
                        Insert(i, element);
                        break;
                    }
                }
            }
        }

        public override void Insert(int index, T element)
        {
            if (!CheckSetElement(index, element))
            {
                return;
            }

            base.Insert(index, element);
        }

        private bool CheckSetElement(int index, T element)
        {
            if (index == 0)
            {
                return Count <= 1 || this[0].CompareTo(element) > 0;
            }

            // adding with .Add()
            if (index == Count - 1)
            {
                return this[index].CompareTo(element) < 0;
            }

            // inserting at the end
            if (index == Count)
            {
                return this[index - 1].CompareTo(element) < 0;
            }

            return CheckNeighbours(index, element);
        }

        private bool CheckNeighbours(int index, T element)
        {
            return (this[index + 1].CompareTo(element) >= 0 || this[index].CompareTo(element) >= 0)
                 && this[index - 1].CompareTo(element) <= 0;
        }
    }
}
