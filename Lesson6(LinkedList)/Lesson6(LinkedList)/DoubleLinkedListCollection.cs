using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lesson6LinkedList
{
    public class DoubleLinkedListCollection<T> : ICollection<T>
    {
        private readonly DNode<T> sentinel;

        public DoubleLinkedListCollection()
        {
            Count = 0;
            sentinel = new DNode<T>(default);
            sentinel.LinkTo(sentinel, sentinel);
        }

        public int Count { get; private set; }

        public bool IsReadOnly { get; }

        public void AddAtFront(T data)
        {
            DNode<T> node = new DNode<T>(data);
            AddFirst(node);
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (DNode<T> i = sentinel.Next; i != sentinel; i = i.Next)
            {
                yield return i.Data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void AddFirst(DNode<T> node)
        {
            if (IsListEmpty() && node != null)
            {
                LinkToSentinel(node);
            }
            else
            if (node != null)
            {
                sentinel.Next.Previous = node;
                node.Next = sentinel.Next;
                sentinel.Next = node;
            }

            Count++;
        }

        private bool IsListEmpty()
        {
            return Count == 0;
        }

        private void LinkToSentinel(DNode<T> node)
        {
            sentinel.LinkTo(node, node);
            node.LinkTo(sentinel, sentinel);
        }
    }
}
