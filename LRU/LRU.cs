using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRU
{
    public class LRU<T>
    {
        private int size;
        private IDictionary<T, Node<T>> cache;
        Node<T> head;
        Node<T> tail;
        public LRU(int size)
        {
            if (size <= 0)
                throw new ArgumentException("Size must be positive", nameof(size));
            this.size = size;
            cache = new Dictionary<T, Node<T>>();
            head = new Node<T>(default);
            head.next = new Node<T>(default);
            head.prev = null;
            head.next.prev = head;
            head.next.next = null;
            tail = head.next;
        }

        public bool Add(T item)
        {
            if(cache.ContainsKey(item))
            {
                //cache hit;
                Node<T> current = cache[item];
                current.prev.next = current.next;
                current.next.prev = current.prev;
                current.next = head.next;
                current.prev = head;
                head.next.prev = current;
                head.next = current;
            }
            // cache miss
            else
            {
                if(cache.Count()>= size)
                {
                    // evict element
                    Node<T> evict = tail.prev;
                    evict.prev.next = tail;
                    tail.prev = evict.prev;
                    cache.Remove(evict.Value);
                }

                // add element
                Node<T> current = new Node<T>(item);
                cache[item] = current;
                current.next = head.next;
                current.prev = head;
                head.next.prev = current;
                head.next = current;
            }

            return true;
        }

        public IList<T> GetItems()
        {
            return cache.Keys.ToList();
        }
    }
}
