namespace PriorityQueue
{
    public class PriorityItem<T>
    {
        public T Item { get; }
        public int Priority { get; }

        public PriorityItem(T item, int priority)
        {
            Item = item;
            Priority = priority;
        }

        public override string ToString()
        {
            return $"({Item}, {Priority})";
        }
    }
}
