using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    public class UnsortedArrayPriorityQueue<T> : IPriorityQueue<T>
    {
        private readonly PriorityItem<T>[] storage;
        private readonly int capacity;
        private int tailIndex;

        public UnsortedArrayPriorityQueue(int size)
        {
            storage = new PriorityItem<T>[size];
            capacity = size;
            tailIndex = -1;
        }

        public bool IsEmpty()
        {
            return tailIndex < 0;
        }

        public void Enqueue(T item, int priority)
        {
            tailIndex++;
            if (tailIndex >= capacity)
            {
                tailIndex--;
                throw new QueueOverflowException();
            }

            storage[tailIndex] = new PriorityItem<T>(item, priority);
        }

        public T Peek()
        {
            if (IsEmpty()) throw new QueueUnderflowException();

            int highestIndex = 0;

            for (int i = 1; i <= tailIndex; i++)
            {
                if (storage[i].Priority > storage[highestIndex].Priority)
                {
                    highestIndex = i;
                }
            }

            return storage[highestIndex].Item;
        }

        public void Dequeue()
        {
            if (IsEmpty()) throw new QueueUnderflowException();

            int highestIndex = 0;

            for (int i = 1; i <= tailIndex; i++)
            {
                if (storage[i].Priority > storage[highestIndex].Priority)
                {
                    highestIndex = i;
                }
            }

            for (int i = highestIndex; i < tailIndex; i++)
            {
                storage[i] = storage[i + 1];
            }

            tailIndex--;
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