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

        public bool IsReadOnly => false;

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
            DNode<T> nodeToFind = FindDnode(item, GetNodesAtStart());

            return true;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw NullArrayException();
            }

            DNode<T> curentNode = GetDnodeAtIndex(arrayIndex);

            foreach (T item in array)
            {
                InsertDNodeAfter(curentNode, item);
                curentNode = curentNode.Next;
            }
        }

        public bool Remove(T item)
        {
            if (!Contains(item))
            {
                throw InvalidValueException();
            }

            DNode<T> nodeToBeRemoved = FindDnode(item, GetNodesAtStart());

            nodeToBeRemoved.Previous.Next = nodeToBeRemoved.Next;
            nodeToBeRemoved.Next.Previous = nodeToBeRemoved.Previous;

            return true;
        }

        public DNode<T> FindAtEnd(T value)
        {
            try
            {
                return FindDnode(value, GetNodesAtEnd());
            }
            catch (InvalidOperationException)
            {
                throw NotFoundNodeException();
            }
        }

        public ReadOnlyDLListCollection<T> AsReadOnly()
        {
            return new ReadOnlyDLListCollection<T>(this);
        }

        public IEnumerator<T> GetEnumerator()
        {
            DNode<T> curentNode = sentinel;
            for (int i = 0; i < Count; i++)
            {
                curentNode = curentNode.Next;
                yield return curentNode.Data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumeratorAtEnd()
        {
            DNode<T> curentNode = sentinel;
            for (int i = Count - 1; i >= 0; i--)
            {
                curentNode = curentNode.Previous;
                yield return curentNode.Data;
            }
        }

        private IEnumerable<DNode<T>> GetNodesAtStart()
        {
            for (DNode<T> i = sentinel.Next; i != sentinel; i = i.Next)
            {
                yield return i;
            }
        }

        private IEnumerable<DNode<T>> GetNodesAtEnd()
        {
            for (DNode<T> i = sentinel.Previous; i != sentinel; i = i.Previous)
            {
                yield return i;
            }
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

        private DNode<T> FindDnode(T item, IEnumerable<DNode<T>> nodes)
        {
            foreach (DNode<T> node in nodes)
            {
                if (node.Data.CompareTo(item) == 0)
                {
                    return node;
                }
            }

            throw NotFoundNodeException();
        }

        private DNode<T> GetDnodeAtIndex(int arrayIndex)
        {
            if (arrayIndex < 0 || arrayIndex > Count)
            {
                throw InvalidIndexException();
            }

            int curentIndex = 1;

            foreach (DNode<T> node in GetNodesAtStart())
            {
                if (curentIndex == arrayIndex)
                {
                    return node;
                }

                curentIndex++;
            }

            throw NotFoundNodeException();
        }

        private void InsertDNodeAfter(DNode<T> curentNode, T item)
        {
            DNode<T> newNode = new DNode<T>(item);

            newNode.LinkTo(curentNode, curentNode.Next);
            curentNode.Next = newNode;
            curentNode.Next.Previous = newNode;
            Count++;
        }

        private Exception InvalidValueException()
        {
            throw new InvalidOperationException("Invalid Value!");
        }

        private Exception InvalidIndexException()
        {
            throw new InvalidOperationException("Invalid Index!");
        }

        private Exception NullArrayException()
        {
            throw new InvalidOperationException("Null Array!");
        }

        private Exception NotFoundNodeException()
        {
            throw new InvalidOperationException("Node does not exists!");
        }
    }
}
