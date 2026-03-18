using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    public class HeapPriorityQueue<T> : IPriorityQueue<T>
    {
        private readonly PriorityItem<T>[] heap;
        private int size;
        private readonly int capacity;

        public HeapPriorityQueue(int capacity)
        {
            this.capacity = capacity;
            heap = new PriorityItem<T>[capacity];
            size = 0;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public void Enqueue(T item, int priority)
        {
            if (size >= capacity)
                throw new QueueOverflowException();

            var newItem = new PriorityItem<T>(item, priority);

            heap[size] = newItem;
            int current = size;
            size++;

            // Heapify up
            while (current > 0)
            {
                int parent = (current - 1) / 2;

                if (heap[current].Priority > heap[parent].Priority)
                {
                    Swap(current, parent);
                    current = parent;
                }
                else
                {
                    break;
                }
            }
        }

        public T Peek()
        {
            if (IsEmpty()) throw new QueueUnderflowException();
            return heap[0].Item;
        }

        public void Dequeue()
        {
            if (IsEmpty()) throw new QueueUnderflowException();

            // Move last item to root
            heap[0] = heap[size - 1];
            size--;

            int current = 0;

            // Heapify down
            while (true)
            {
                int left = 2 * current + 1;
                int right = 2 * current + 2;
                int largest = current;

                if (left < size && heap[left].Priority > heap[largest].Priority)
                {
                    largest = left;
                }

                if (right < size && heap[right].Priority > heap[largest].Priority)
                {
                    largest = right;
                }

                if (largest != current)
                {
                    Swap(current, largest);
                    current = largest;
                }
                else
                {
                    break;
                }
            }
        }

        private void Swap(int i, int j)
        {
            var temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }

        public override string ToString()
        {
            if (IsEmpty()) throw new QueueUnderflowException("No items to display");

            string result = "[";
            for (int i = 0; i < size; i++)
            {
                if (i > 0) result += ", ";
                result += heap[i].ToString();
            }
            result += "]";
            return result;
        }
    }
}