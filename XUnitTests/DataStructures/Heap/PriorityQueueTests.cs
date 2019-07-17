using DataStructures.Graphs;
using DataStructures.Heap;
using System;
using Xunit;
using XUnitTests.DataStructures.Graphs.source;
using System.Linq;

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

        [Fact(DisplayName = "PriorityQ objects weight correct")]
        public void KruskalMSTCorrect2()
        {
            var graph = GraphCreator.GetWeightedGraph("tiny-midEWG.txt");
            var res = new double[] { 0.02, 0.16, 0.17, 0.19, 0.22, 0.26, 0.28, 0.29, 0.32, 0.32, 0.34, 0.35, 0.36, 0.37, 0.38, 0.4, 0.43, 0.44, 0.52, 0.58, 0.8, 0.93 };

            PriorityQ<WeightedEdge<int>> queue = new PriorityQ<WeightedEdge<int>>();
            MinHeap<WeightedEdge<int>> minHeap = new MinHeap<WeightedEdge<int>>();
            foreach (var edge in graph.GetEdges())
            {
                queue.insert(edge);
                minHeap.add(edge);
            }

            for (int i = 0; i < res.Length; i++)
            {
                var edge = queue.pop();
                var edge2 = minHeap.pop();
                Assert.True(edge.Weight == res[i]);
                Assert.True(edge2.Weight == res[i]);
            }            
        }
    }
}
