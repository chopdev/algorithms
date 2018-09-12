using DataStructures.Heap;
using System;
using Xunit;

namespace XUnitTests.DataStructures.Heap
{
    public class PriorityQTests
    {
        [Fact(DisplayName = "PriorityQ Insert Correct")]
        public void PriorityQInsertCorrect()
        {
            PriorityQ queue = new PriorityQ();
            queue.insert(1);
            queue.insert(2);
            queue.insert(3);
            queue.insert(4);
            queue.insert(5);
            Assert.True(queue.peek() == 5);

            queue = new PriorityQ();
            queue.insert(5);
            queue.insert(4);
            queue.insert(3);
            queue.insert(2);
            queue.insert(1);
            Assert.True(queue.peek() == 5);

            queue = new PriorityQ();
            queue.insert(3);
            queue.insert(4);
            queue.insert(5);
            queue.insert(2);
            queue.insert(1);
            Assert.True(queue.peek() == 5);
        }

        [Fact(DisplayName = "PriorityQ Pop Correct")]
        public void PriorityQPopCorrect()
        {
            PriorityQ queue = new PriorityQ();
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

            queue = new PriorityQ();
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
