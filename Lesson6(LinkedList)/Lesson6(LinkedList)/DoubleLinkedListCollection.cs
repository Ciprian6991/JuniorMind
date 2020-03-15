using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lesson6LinkedList
{
    public class DoubleLinkedListCollection<T> : ICollection<T>
        where T : IComparable<T>
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

        public void AddAtFront(DNode<T> node)
        {
            AddFirst(node);
        }

        public void Add(T item)
        {
            DNode<T> node = new DNode<T>(item);
            AddLast(node);
        }

        public void Clear()
        {
            sentinel.LinkTo(sentinel, sentinel);
            Count = 0;
        }

        public bool Contains(T item)
        {
            return FindDnode(item) != sentinel;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            if (!Contains(item))
            {
                return false;
            }

            DNode<T> nodeToBeRemoved = FindDnode(item);

            nodeToBeRemoved.Previous.Next = nodeToBeRemoved.Next;
            nodeToBeRemoved.Next.Previous = nodeToBeRemoved.Previous;

            return true;
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

        private void AddLast(DNode<T> node)
        {
            if (IsListEmpty() && node != null)
            {
                LinkToSentinel(node);
            }
            else
            if (node != null)
            {
                node.LinkTo(sentinel.Previous, sentinel);
                sentinel.Previous.Next = node;
                sentinel.Previous = node;
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

        private IEnumerable<DNode<T>> GetNodesAtStart()
        {
            for (DNode<T> i = sentinel.Next; i != sentinel; i = i.Next)
            {
                yield return i;
            }
        }

        private DNode<T> FindDnode(T item)
        {
            foreach (DNode<T> node in GetNodesAtStart())
            {
                if (node.Data.CompareTo(item) == 0)
                {
                    return node;
                }
            }

            return sentinel;
        }
    }
}
