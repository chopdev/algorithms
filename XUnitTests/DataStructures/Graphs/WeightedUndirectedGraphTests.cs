using DataStructures.Graphs;
using System;
using Xunit;

namespace UnitTests.DataStructures.Graphs
{
    public class WeightedUndirectedGraphTests
    {
        int[] _vertexes;
        WeightedUndirectedGraph<int> _graph;

        public WeightedUndirectedGraphTests()
        {
            _vertexes = new[] { 1, 2, 3, 4, 0 };
            _graph = new WeightedUndirectedGraph<int>(_vertexes);
        }

        [Fact]
        public void AddVertexCorrect()
        {
            Assert.False(_graph.HasVertex(5));
            _graph.AddVertex(5);
            Assert.True(_graph.HasVertex(5));
        }

        [Fact]
        public void AddVertexThrowsException()
        {
            Assert.Throws<ArgumentException>(() => _graph.AddVertex(0));
        }

        [Fact]
        public void RemoveVertexCorrect()
        {
            Assert.True(_graph.HasVertex(4));
            _graph.RemoveVertex(4);
            Assert.False(_graph.HasVertex(4));
        }

        [Fact]
        public void RemoveVertexThrowsExceptions()
        {
            Assert.Throws<ArgumentException>(() => _graph.RemoveVertex(6));
        }

        [Fact]
        public void AddEdgeCorrect()
        {
            Assert.False(_graph.HasEdge(1, 0));
            Assert.False(_graph.HasEdge(1, 2));
            _graph.AddEdge(0, 1, 1.4);
            _graph.AddEdge(1, 2, 1.5);
            Assert.True(_graph.HasEdge(1, 0));
            Assert.True(_graph.HasEdge(1, 2));
        }

        [Fact]
        public void AddEdgeThrowsException()
        {
            Assert.Throws<ArgumentException>(() => _graph.AddEdge(0, 65, 1.5));
        }

        [Fact]
        public void AddEdgeThrowsExceptionOnDuplicate()
        {
            _graph.AddEdge(0, 3, 1.5);
            Assert.Throws<ArgumentException>(() => _graph.AddEdge(0, 3, 1.5));
        }

        [Fact]
        public void RemoveEdgeCorrect()
        {
            _graph.AddEdge(0, 1, 1.5);
            Assert.True(_graph.HasEdge(1, 0));
            _graph.RemoveEdge(0, 1);
            Assert.False(_graph.HasEdge(1, 0));
        }

        [Fact]
        public void RemoveEdgeThrowException()
        {
            Assert.Throws<ArgumentException>(() => _graph.RemoveEdge(0, 65));
        }

        [Fact]
        public void IteratorWorking()
        {
            int i = 0;
            foreach (var vertex in _graph)
            {
                Assert.Equal(vertex, _vertexes[i]);
                i++;
            }
        }

        [Fact]
        public void WeightedEdgeBehavesCorrect()
        {
            var test1 = new TestClass() { Temp = "test" };
            var weightedEdge1 = new WeightedEdge<TestClass>(test1);
            var weightedEdge2 = new WeightedEdge<TestClass>(new TestClass());
            var weightedEdge3 = new WeightedEdge<TestClass>(test1, 1.5);

            Assert.NotEqual(weightedEdge1, weightedEdge2);
            Assert.Equal(weightedEdge1, weightedEdge3);
        }

        [Fact]
        public void GetWeightWorkingRight()
        {
            _graph.AddEdge(1, 3, 1.6);
            _graph.AddEdge(1, 4, 2.8);

            var weight1 = _graph.GetWeight(1, 3);
            var weight2 = _graph.GetWeight(3, 1);
            var weight3 = _graph.GetWeight(1, 4);
            var weight4 = _graph.GetWeight(4, 1);
            Assert.Equal(weight1, 1.6);
            Assert.Equal(weight2, 1.6);
            Assert.Equal(weight3, 2.8);
            Assert.Equal(weight4, 2.8);
        }

        [Fact]
        public void ChangeWeightWorkingRight()
        {
            _graph.AddEdge(1, 3, 1.6);

            var weight1 = _graph.GetWeight(1, 3);
            var weight2 = _graph.GetWeight(3, 1);

            Assert.Equal(weight1, 1.6);
            Assert.Equal(weight2, 1.6);

            _graph.ChangeWeight(1, 3, 28.9);
            weight1 = _graph.GetWeight(1, 3);
            weight2 = _graph.GetWeight(3, 1);

            Assert.Equal(weight1, 28.9);
            Assert.Equal(weight2, 28.9);
        }
    }

    internal class TestClass {
        public string Temp { get; set; }
    }
}
