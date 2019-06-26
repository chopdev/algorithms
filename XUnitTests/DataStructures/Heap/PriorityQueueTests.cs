using DataStructures.Heap;
using System;
using Xunit;

namespace XUnitTests.DataStructures.Heap
{
    public class PriorityQueueTests
    {
        [Fact(DisplayName = "PriorityQ Insert Correct")]
        public void PriorityQInsertCorrect()
        {
            PriorityQ<int> queue = new PriorityQ<int>();
            queue.insert(1);
            queue.insert(2);
            queue.insert(3);
            queue.insert(4);
            queue.insert(5);
            Assert.True(queue.peek() == 1);

            queue = new PriorityQ<int>();
            queue.insert(5);
            queue.insert(4);
            queue.insert(3);
            queue.insert(2);
            queue.insert(1);
            Assert.True(queue.peek() == 1);

            queue = new PriorityQ<int>();
            queue.insert(3);
            queue.insert(4);
            queue.insert(5);
            queue.insert(2);
            queue.insert(1);
            Assert.True(queue.peek() == 1);
        }

        [Fact(DisplayName = "PriorityQ Pop Correct")]
        public void PriorityQPopCorrect()
        {
            PriorityQ<int> queue = new PriorityQ<int>();
            queue.insert(3);
            queue.insert(4);
            queue.insert(5);
            queue.insert(2);
            queue.insert(1);

            Assert.True(queue.pop() == 1);
            Assert.True(queue.pop() == 2);
            Assert.True(queue.pop() == 3);
            Assert.True(queue.pop() == 4);
            Assert.True(queue.pop() == 5);

            queue = new PriorityQ<int>();
            queue.insert(3);
            queue.insert(4);
            queue.insert(5);
            queue.insert(2);
            queue.insert(1);
            queue.insert(6);

            Assert.True(queue.pop() == 1);
            Assert.True(queue.pop() == 2);
            Assert.True(queue.pop() == 3);
            Assert.True(queue.pop() == 4);
            Assert.True(queue.pop() == 5);
            Assert.True(queue.pop() == 6);
            Assert.Throws<InvalidOperationException>(() => queue.pop());
        }
    }
}
