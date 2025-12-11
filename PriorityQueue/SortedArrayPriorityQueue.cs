using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    public class SortedArrayPriorityQueue<T> : IPriorityQueue<T>
    {
        private readonly PriorityItem<T>[] storage;
        private readonly int capacity;
        private int tailIndex;

        public SortedArrayPriorityQueue(int size)
        {
            storage = new PriorityItem<T>[size];
            capacity = size;
            tailIndex = -1;
        }

        public T Peek()
        {
            if (IsEmpty()) throw new QueueUnderflowException();
            return storage[0].Item;
        }

        public void Enqueue(T item, int priority)
        {
            tailIndex++;
            if (tailIndex >= capacity)
            {
                tailIndex--;
                throw new QueueOverflowException();
            }

            int i = tailIndex;
            while (i > 0 && storage[i - 1].Priority < priority)
            {
                storage[i] = storage[i - 1];
                i--;
            }
            storage[i] = new PriorityItem<T>(item, priority);
        }

        public void Dequeue()
        {
            if (IsEmpty()) throw new QueueUnderflowException();

            for (int i = 0; i < tailIndex; i++)
            {
                storage[i] = storage[i + 1];
            }
            tailIndex--;
        }

        public bool IsEmpty()
        {
            return tailIndex < 0;
        }

        public override string ToString()
        {
            if (IsEmpty()) throw new QueueUnderflowException("No items to display");

            string result = "[";
            for (int i = 0; i <= tailIndex; i++)
            {
                if (i > 0) result += ", ";
                result += storage[i];
            }
            result += "]";
            return result;
        }
    }
}
