using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    public class UnsortedLinkedPriorityQueue<T> : IPriorityQueue<T>
    {
        private Node<T> head;

        public UnsortedLinkedPriorityQueue()
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
            newNode.Next = head;
            head = newNode;
        }

        public T Peek()
        {
            if (IsEmpty()) throw new QueueUnderflowException();

            Node<T> current = head;
            Node<T> highest = head;

            while (current != null)
            {
                if (current.Data.Priority > highest.Data.Priority)
                {
                    highest = current;
                }
                current = current.Next;
            }

            return highest.Data.Item;
        }

        public void Dequeue()
        {
            if (IsEmpty()) throw new QueueUnderflowException();

            Node<T> current = head;
            Node<T> highest = head;
            Node<T> prev = null;
            Node<T> prevHighest = null;

            while (current != null)
            {
                if (current.Data.Priority > highest.Data.Priority)
                {
                    highest = current;
                    prevHighest = prev;
                }

                prev = current;
                current = current.Next;
            }

            // Remove the highest priority node
            if (prevHighest == null)
            {
                head = head.Next; // removing head
            }
            else
            {
                prevHighest.Next = highest.Next;
            }
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