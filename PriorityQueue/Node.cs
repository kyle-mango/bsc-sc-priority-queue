using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace PriorityQueue
{
    public class Node<T>
    {
        public PriorityItem<T> Data;
        public Node<T> Next;

        public Node(PriorityItem<T> data)
        {
            Data = data;
            Next = null;
        }
    }
}