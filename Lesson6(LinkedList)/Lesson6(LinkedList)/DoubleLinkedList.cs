using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lesson6LinkedList
{
    public class DoubleLinkedList<T> : ICollection<T>
        where T : IComparable<T>
    {
        private readonly DNode<T> sentinel;

        public DoubleLinkedList()
        {
            Count = 0;
            sentinel = new DNode<T>(default);
            sentinel.LinkTo(sentinel, sentinel);
        }

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public void AddAtFront(T data)
        {
            InsertNodeBetween(sentinel, new DNode<T>(data), sentinel.Next);
        }

        public void AddAtFront(DNode<T> node)
        {
            InsertNodeBetween(sentinel, node, sentinel.Next);
        }

        public void Add(T item)
        {
            InsertNodeBetween(sentinel.Previous, new DNode<T>(item), sentinel);
        }

        public void Clear()
        {
            sentinel.LinkTo(sentinel, sentinel);
            Count = 0;
        }

        public bool Contains(T item)
        {
            DNode<T> nodeToFind = FindNode(item, GetNodesAtStart());

            return true;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw NullArrayException();
            }

            DNode<T> curentNode = GetNodeAtIndex(arrayIndex);

            foreach (T item in array)
            {
                InsertNodeBetween(curentNode, new DNode<T>(item), curentNode.Next);
                curentNode = curentNode.Next;
            }
        }

        public bool Remove(T item)
        {
            DNode<T> nodeToBeRemoved = FindNode(item, GetNodesAtStart());

            nodeToBeRemoved.Previous.Next = nodeToBeRemoved.Next;
            nodeToBeRemoved.Next.Previous = nodeToBeRemoved.Previous;

            return true;
        }

        public DNode<T> FindAtEnd(T value)
        {
            try
            {
                return FindNode(value, GetNodesAtEnd());
            }
            catch (InvalidOperationException)
            {
                throw NotFoundNodeException();
            }
        }

        public ReadOnlyDoubleLinkedList<T> AsReadOnly()
        {
            return new ReadOnlyDoubleLinkedList<T>(this);
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

        private void InsertNodeBetween(DNode<T> node1, DNode<T> insertNode, DNode<T> node2)
        {
            if (insertNode == null)
            {
                throw NullNodeException();
            }

            node1.LinkTo(node1.Previous, insertNode);
            insertNode.LinkTo(node1, node2);
            node2.LinkTo(insertNode, node2.Next);
            Count++;
        }

        private DNode<T> FindNode(T item, IEnumerable<DNode<T>> nodes)
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

        private DNode<T> GetNodeAtIndex(int arrayIndex)
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

        private Exception NullNodeException()
        {
            throw new InvalidOperationException("Null Node!");
        }
    }
}
