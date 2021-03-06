﻿using System;
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
                if (index < Count)
                {
                    if (!CheckSetElement(index, value))
                    {
                        return;
                    }

                    base[index] = value;
                }
                else
                {
                    throw new ArgumentException("Invalid index; must be less than", "Count = " + Count.ToString());
                }

                base[index] = value;
            }
        }

        public override void Add(T item)
        {
            if (Count == 0 || this[Count - 1].CompareTo(item) <= 0)
            {
                base.Insert(Count, item);
            }
            else
            {
                for (int i = 0; i < Count; i++)
                {
                    if (this[i].CompareTo(item) >= 0)
                    {
                        Insert(i, item);
                        break;
                    }
                }
            }
        }

        public override void Insert(int index, T item)
        {
            if (!CheckSetElement(index, item))
            {
                return;
            }

            base.Insert(index, item);
        }

        private bool CheckSetElement(int index, T element)
        {
            if (index == 0)
            {
                return Count <= 1 || this[0].CompareTo(element) >= 0;
            }

            // adding with .Add()
            if (index == Count - 1)
            {
                return this[index].CompareTo(element) <= 0;
            }

            // inserting at the end
            if (index == Count)
            {
                return this[index - 1].CompareTo(element) <= 0;
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
