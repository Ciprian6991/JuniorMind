using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lesson7Dictionary
{
    public class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly int[] buckets;
        private readonly Element[] elements;

        public Dictionary(int size = 5)
        {
            buckets = new int[size];
            Array.Fill(buckets, -1);

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

        public TValue this[TKey key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Add(TKey key, TValue value)
        {
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
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(TKey key)
        {
            for (int i = buckets[GetBucketIndex(key)]; i != -1; i = elements[i].Next)
            {
                if (elements[i].Key.Equals(key))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return GetBucket(elements[i]);
            }
        }

        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            for (int i = buckets[GetBucketIndex(key)]; i != -1; i = elements[i].Next)
            {
                if (elements[i].Key.Equals(key))
                {
                    value = elements[i].Value;
                    return true;
                }
            }

            value = default;
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void AddElement(ref Element element, TKey key, TValue value)
        {
            element.Key = key;
            element.Value = value;
            element.Next = -1;
        }

        private KeyValuePair<TKey, TValue> GetBucket(Element element)
        {
            return KeyValuePair.Create(element.Key, element.Value);
        }

        private int GetBucketIndex(TKey key)
        {
            return Math.Abs(key.GetHashCode()) % buckets.Length;
        }

        struct Element
        {
            public TKey Key { get; set; }

            public TValue Value { get; set; }

            public int Next { get; set; }
        }
    }
}
