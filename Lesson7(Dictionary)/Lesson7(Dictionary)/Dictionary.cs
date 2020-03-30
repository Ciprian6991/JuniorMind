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

        enum SearchOption
        {
            ByKey,
            ByKeyValue,
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
                return elements[SearchPosition(SearchOption.ByKey, key, out int previousNotUsed)].Value;
            }

            set
            {
                elements[SearchPosition(SearchOption.ByKey, key, out int previousNotUsed)].Value = value;
            }
        }

        public void Add(TKey key, TValue value)
        {
            EnsureCapacity();
            AddElement(ref elements[Count], key, value);

            int bucketIndex = GetBucketIndex(key);
            if (buckets[bucketIndex] != -1)
            {
                elements[Count].Next = buckets[bucketIndex];
            }

            buckets[bucketIndex] = Count;
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
            return SearchPosition(SearchOption.ByKeyValue, item.Key, out int previousNotUsed, item.Value) != -1;
        }

        public bool ContainsKey(TKey key)
        {
            return SearchPosition(SearchOption.ByKey, key, out int previousNotUsed) != -1;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            List<int> freeIndexList = GetFreeIndexList();
            for (int i = 0; i < Count + freeIndexList.Count; i++)
            {
                if (!freeIndexList.Contains(i))
                {
                    yield return KeyValuePair.Create(elements[i].Key, elements[i].Value);
                }
            }
        }

        public bool Remove(TKey key)
        {
            int position = SearchPosition(SearchOption.ByKey, key, out int previous);

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
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            int searchedPosition = SearchPosition(SearchOption.ByKey, key, out int previousNotUsed);
            if (searchedPosition != -1)
            {
                value = elements[searchedPosition].Value;
                return true;
            }

            value = default;
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private int SearchPosition(SearchOption option, TKey key, out int previous, TValue value = default)
        {
            previous = -1;
            for (int i = buckets[GetBucketIndex(key)]; i != -1; i = elements[i].Next)
            {
                if (elements[i].Key.Equals(key) && (option == SearchOption.ByKey
                                                    || (option == SearchOption.ByKeyValue
                                                        && elements[i].Value.Equals(value))))
                {
                    return i;
                }

                previous = i;
            }

            return -1;
        }

        private List<int> GetFreeIndexList()
        {
            List<int> freeIndexList = new List<int>();

            if (freeIndex != -1)
            {
                for (int curentIndex = freeIndex; curentIndex != -1; curentIndex = elements[curentIndex].Next)
                {
                    freeIndexList.Add(curentIndex);
                }
            }

            return freeIndexList;
        }

        private void AddElement(ref Element element, TKey key, TValue value)
        {
            element.Key = key;
            element.Value = value;
            element.Next = -1;
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

        struct Element
        {
            public TKey Key { get; set; }

            public TValue Value { get; set; }

            public int Next { get; set; }
        }
    }
}
