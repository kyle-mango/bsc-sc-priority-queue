using NUnit.Framework.Legacy;
using PriorityQueue;

namespace PriorityQueueTests
{
    [TestFixture]
    public class HeapPriorityQueueTests
    {
        private IPriorityQueue<int> queue;

        [SetUp]
        public void Setup()
        {
            queue = new HeapPriorityQueue<int>(1000);
        }

        [Test]
        public void IsEmpty_NewQueue_ReturnsTrue()
        {
            ClassicAssert.IsTrue(queue.IsEmpty());
        }

        [Test]
        public void Enqueue_ThenPeek_ReturnsHighestPriority()
        {
            queue.Enqueue(10, 1);
            queue.Enqueue(20, 5);

            ClassicAssert.AreEqual(20, queue.Peek());
        }

        [Test]
        public void Dequeue_RemovesItemsInCorrectOrder()
        {
            queue.Enqueue(10, 1);
            queue.Enqueue(20, 5);
            queue.Enqueue(15, 3);

            ClassicAssert.AreEqual(20, queue.Peek());
            queue.Dequeue();

            ClassicAssert.AreEqual(15, queue.Peek());
            queue.Dequeue();

            ClassicAssert.AreEqual(10, queue.Peek());
        }

        [Test]
        public void SingleItem_BehavesCorrectly()
        {
            queue.Enqueue(42, 10);

            ClassicAssert.AreEqual(42, queue.Peek());
            queue.Dequeue();

            ClassicAssert.IsTrue(queue.IsEmpty());
        }

        [Test]
        public void DuplicatePriorities_AreHandled()
        {
            queue.Enqueue(10, 5);
            queue.Enqueue(20, 5);

            int first = queue.Peek();
            queue.Dequeue();

            int second = queue.Peek();

            ClassicAssert.IsTrue(
                (first == 10 && second == 20) ||
                (first == 20 && second == 10)
            );
        }

        [Test]
        public void Dequeue_OnEmptyQueue_ThrowsException()
        {
            ClassicAssert.Throws<QueueUnderflowException>(() => queue.Dequeue());
        }

        [Test]
        public void Peek_OnEmptyQueue_ThrowsException()
        {
            ClassicAssert.Throws<QueueUnderflowException>(() => queue.Peek());
        }

        [Test]
        public void LargeInput_ReturnsHighestPriority()
        {
            for (int i = 0; i < 1000; i++)
            {
                queue.Enqueue(i, i);
            }

            ClassicAssert.AreEqual(999, queue.Peek());
        }

        [Test]
        public void MultipleEnqueueDequeue_MaintainsCorrectState()
        {
            queue.Enqueue(5, 5);
            queue.Enqueue(10, 10);

            queue.Dequeue(); // removes 10

            queue.Enqueue(20, 20);

            ClassicAssert.AreEqual(20, queue.Peek());
        }
    }
}