using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lesson7Dictionary
{
    public class ReadOnlyDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly IDictionary<TKey, TValue> dic;

        public ReadOnlyDictionary(IDictionary<TKey, TValue> dic)
        {
            this.dic = dic;
        }

        public ICollection<TKey> Keys => dic.Keys;

        public ICollection<TValue> Values => dic.Values;

        public int Count => dic.Count;

        public bool IsReadOnly => true;

        public TValue this[TKey key] { get => dic[key]; set => throw ReadOnlyException(); }

        public void Add(TKey key, TValue value)
        {
            throw ReadOnlyException();
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw ReadOnlyException();
        }

        public void Clear()
        {
            throw ReadOnlyException();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return dic.Contains(item);
        }

        public bool ContainsKey(TKey key)
        {
            return dic.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw ReadOnlyException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return dic.GetEnumerator();
        }

        public bool Remove(TKey key)
        {
            throw ReadOnlyException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw ReadOnlyException();
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return dic.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return dic.GetEnumerator();
        }

        private Exception ReadOnlyException()
        {
            throw new NotSupportedException("Dictionary is read only!");
        }
    }
}
