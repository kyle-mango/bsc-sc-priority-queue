using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
     public class SortedLinkedPriorityQueue<T> : IPriorityQueue<T>
    {
        private Node<T> head;

        public SortedLinkedPriorityQueue()
        {
            head = null;
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        public void Enqueue(T item, int priority)
        {
            var newNode = new Node<T>(new PriorityItem<T>(item, priority));

            // Case 1: empty list OR new node has highest priority
            if (head == null || priority > head.Data.Priority)
            {
                newNode.Next = head;
                head = newNode;
                return;
            }

            // Case 2: find correct position
            Node<T> current = head;

            while (current.Next != null && current.Next.Data.Priority >= priority)
            {
                current = current.Next;
            }

            newNode.Next = current.Next;
            current.Next = newNode;
        }

        public T Peek()
        {
            if (IsEmpty()) throw new QueueUnderflowException();
            return head.Data.Item;
        }

        public void Dequeue()
        {
            if (IsEmpty()) throw new QueueUnderflowException();
            head = head.Next;
        }

        public override string ToString()
        {
            if (IsEmpty()) throw new QueueUnderflowException("No items to display");

            string result = "[";
            Node<T> current = head;

            while (current != null)
            {
                result += current.Data.ToString();
                if (current.Next != null) result += ", ";
                current = current.Next;
            }

            result += "]";
            return result;
        }
    }
}