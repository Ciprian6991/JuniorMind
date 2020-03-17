using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson6LinkedList
{
    public class DNode<T>
    {
        public DNode(T data)
        {
            Data = data;
            Next = null;
            Previous = null;
        }

        public T Data { get; set; }

        public DNode<T> Next { get; set; }

        public DNode<T> Previous { get; set; }

        public void LinkTo(DNode<T> prev, DNode<T> next)
        {
            Previous = prev;
            Next = next;
        }
    }
}
