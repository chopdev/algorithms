using DataStructures.Heap;
using System;
using Xunit;

namespace XUnitTests.DataStructures.Heap
{
    public class MaxPriorityQTests
    {
        [Fact(DisplayName = "MaxPriorityQ Insert Correct")]
        public void PriorityQInsertCorrect()
        {
            MaxPriorityQ queue = new MaxPriorityQ();
            queue.insert(1);
            queue.insert(2);
            queue.insert(3);
            queue.insert(4);
            queue.insert(5);
            Assert.True(queue.peek() == 5);

            queue = new MaxPriorityQ();
            queue.insert(5);
            queue.insert(4);
            queue.insert(3);
            queue.insert(2);
            queue.insert(1);
            Assert.True(queue.peek() == 5);

            queue = new MaxPriorityQ();
            queue.insert(3);
            queue.insert(4);
            queue.insert(5);
            queue.insert(2);
            queue.insert(1);
            Assert.True(queue.peek() == 5);
        }

        [Fact(DisplayName = "MaxPriorityQ Pop Correct")]
        public void PriorityQPopCorrect()
        {
            MaxPriorityQ queue = new MaxPriorityQ();
            queue.insert(3);
            queue.insert(4);
            queue.insert(5);
            queue.insert(2);
            queue.insert(1);

            Assert.True(queue.pop() == 5);
            Assert.True(queue.pop() == 4);
            Assert.True(queue.pop() == 3);
            Assert.True(queue.pop() == 2);
            Assert.True(queue.pop() == 1);

            queue = new MaxPriorityQ();
            queue.insert(3);
            queue.insert(4);
            queue.insert(5);
            queue.insert(2);
            queue.insert(1);
            queue.insert(6);

            Assert.True(queue.pop() == 6);
            Assert.True(queue.pop() == 5);
            Assert.True(queue.pop() == 4);
            Assert.True(queue.pop() == 3);
            Assert.True(queue.pop() == 2);
            Assert.True(queue.pop() == 1);
            Assert.Throws<InvalidOperationException>(() => queue.pop());
        }
    }
}
