namespace PriorityQueue
{
    public interface IPriorityQueue<T>
    {
        T Peek();
        void Dequeue();
        void Enqueue(T item, int priority);
        bool IsEmpty();
        string ToString();
    }
}
