using System;
using DataStructures.Graphs;
using Xunit;

namespace UnitTests.DataStructures.Graphs
{
    public class UndirectedGraphTests
    {
        int[] _vertexes;
        UndirectedGraph<int> _graph;

        public UndirectedGraphTests()
        {
            _vertexes = new[] { 1, 2, 3, 4, 0 };
            _graph = new UndirectedGraph<int>(_vertexes);
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
            Assert.Throws<ArgumentException>(()=> _graph.AddVertex(0));
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
            _graph.AddEdge(0, 1);
            _graph.AddEdge(1, 2);
            Assert.True(_graph.HasEdge(1, 0));
            Assert.True(_graph.HasEdge(1, 2));
        }

        [Fact]
        public void AddEdgeThrowsException()
        {
            Assert.Throws<ArgumentException>(() => _graph.AddEdge(0, 65));
        }

        [Fact]
        public void AddEdgeThrowsExceptionOnDuplicate()
        {
            _graph.AddEdge(0, 3);
            Assert.Throws<ArgumentException>(() => _graph.AddEdge(0, 3));
        }

        [Fact]
        public void RemoveEdgeCorrect()
        {
            _graph.AddEdge(0, 1);
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
    }
}
