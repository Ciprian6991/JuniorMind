using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lesson7Dictionary
{
    public class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly int[] buckets;
        private Element[] elements;
        private int freeIndex;

        public Dictionary(int size = 5)
        {
            buckets = new int[size];
            Array.Fill(buckets, -1);

            freeIndex = -1;
            elements = new Element[size];

            Count = 0;
        }

        public ICollection<TKey> Keys
        {
            get
            {
                var list = new List<TKey>();

                foreach (var element in this)
                {
                    list.Add(element.Key);
                }

                return list;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                var list = new List<TValue>();

                foreach (var element in this)
                {
                    list.Add(element.Value);
                }

                return list;
            }
        }

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public TValue this[TKey key]
        {
            get
            {
                ThrowArgumentIsNull(key);
                return elements[SearchPosition(key, out int previousNotUsed)].Value;
            }

            set
            {
                ThrowArgumentIsNull(key);
                elements[SearchPosition(key, out int previousNotUsed)].Value = value;
            }
        }

        public void Add(TKey key, TValue value)
        {
            ThrowInvalidKey(key);
            EnsureCapacity();
            int index = FindNewEmptyPosition();
            int bucketIndex = GetBucketIndex(key);

            AddElement(ref elements[index], key, value, buckets[bucketIndex]);

            if (buckets[bucketIndex] != -1)
            {
                elements[index].Next = buckets[bucketIndex];
            }

            buckets[bucketIndex] = index;
            Count++;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            Count = 0;
            Array.Fill(buckets, -1);
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return SearchPosition(item.Key, out int previousNotUsed) != -1;
        }

        public bool ContainsKey(TKey key)
        {
            return SearchPosition(key, out int previousNotUsed) != -1;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
            {
            if (array == null)
            {
                return;
            }

            var enumerator = GetEnumerator();
            for (int i = arrayIndex; i < Count + arrayIndex; i++)
            {
                {
                    enumerator.MoveNext();
                    array[i] = enumerator.Current;
                }
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            int curentCounter = Count;
            for (int i = 0; i < curentCounter; i++)
            {
                {
                    if (!ContainsKey(elements[i].Key))
                    {
                        curentCounter++;
                        continue;
                    }

                    yield return KeyValuePair.Create(elements[i].Key, elements[i].Value);
                }
            }
        }

        public bool Remove(TKey key)
        {
            int position = SearchPosition(key, out int previous);

            if (position == -1)
            {
                return false;
            }

            if (previous != -1)
            {
                elements[previous].Next = elements[position].Next;
            }
            else
            {
                buckets[GetBucketIndex(key)] = elements[position].Next;
            }

            elements[position].Next = freeIndex;
            freeIndex = position;
            Count--;
            return true;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            if (SearchPosition(item.Key, out int notUsedVariable) == -1)
            {
                {
                    return false;
                }
            }

            return Remove(item.Key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            int searchedPosition = SearchPosition(key, out int previousNotUsed);
            if (searchedPosition != -1)
            {
                value = elements[searchedPosition].Value;
                return true;
            }

            value = default;
            return false;
        }

        public ReadOnlyDictionary<TKey, TValue> AsReadOnly()
        {
            return new ReadOnlyDictionary<TKey, TValue>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private int SearchPosition(TKey key, out int previous)
        {
            previous = -1;
            for (int i = buckets[GetBucketIndex(key)]; i != -1; i = elements[i].Next)
            {
                if (elements[i].Key.Equals(key))
                {
                    return i;
                }

                previous = i;
            }

            return -1;
        }

        private int FindNewEmptyPosition()
        {
            if (freeIndex == -1)
            {
                return Count;
            }

            int usedIndex = freeIndex;
            freeIndex = elements[freeIndex].Next;
            return usedIndex;
        }

        private void AddElement(ref Element element, TKey key, TValue value, int next = -1)
        {
            element.Key = key;
            element.Value = value;
            element.Next = next;
        }

        private int GetBucketIndex(TKey key)
        {
            return Math.Abs(key.GetHashCode()) % buckets.Length;
        }

        private void EnsureCapacity()
        {
            if (Count != elements.Length)
            {
                return;
            }

            int doubleLength = elements.Length * 2;
            Array.Resize(ref elements, doubleLength);
        }

        private void ThrowInvalidKey(TKey key)
        {
            if (!ContainsKey(key))
            {
                return;
            }

            throw new ArgumentException($"Key {key} already exists in dictionary!");
        }

        private void ThrowArgumentIsNull(TKey key)
        {
            if (key != null)
            {
                return;
            }

            throw new ArgumentNullException(paramName: nameof(key));
        }

        struct Element
        {
            public TKey Key { get; set; }

            public TValue Value { get; set; }

            public int Next { get; set; }
        }
    }
}
