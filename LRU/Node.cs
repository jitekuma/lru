using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRU
{
    public class Node<T>
    {
        public T Value { get; private set; }
        public Node<T> prev;
        public Node<T> next;

        public Node(T value)
        {
            Value = value;
        }
    }
}
