using DataStructures.Graphs;
using System;
using System.Linq;
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

        [Fact(DisplayName = "WeightedUndirectedGraph: AddEdgeCorrect")]
        public void AddEdgeCorrect()
        {
            Assert.False(_graph.HasVertex(5));
            Assert.False(_graph.HasEdge(5, 6));
            _graph.AddEdge(5, 6, 0.44);
            Assert.True(_graph.HasVertex(5));
            Assert.True(_graph.HasVertex(6));
            Assert.True(_graph.HasEdge(5, 6));
            Assert.True(_graph.HasEdge(6, 5));
        }

        [Fact(DisplayName = "WeightedUndirectedGraph: IteratorWorking")]
        public void IteratorWorking()
        {
            int i = 0;
            foreach (var vertex in _graph)
            {
                Assert.Equal(vertex, _vertexes[i]);
                i++;
            }
        }

        [Fact(DisplayName = "WeightedUndirectedGraph: GetEdgeCorrect")]
        public void GetEdgeCorrect()
        {
            _graph.AddEdge(5, 6, 0.44);
            _graph.AddEdge(5, 6, 0.5);
            _graph.AddEdge(5, 1, 0.3);
            _graph.AddEdge(5, 2, 0.3);
            var tempEdge = _graph.AddEdge(0, 4, 0.33);

            Assert.Equal(_graph.Count, 7);
            foreach (var edge in _graph.GetAdjacentEdges(5))
            {
                int otherVertice = edge.GetOther(5);
                Assert.True(otherVertice == 6 || otherVertice == 1 || otherVertice == 2);
            }

            Assert.True(_graph.GetAdjacentEdges(0).First().GetOther(0) == 4);
            Assert.True(_graph.GetAdjacentEdges(4).First().GetOther(4) == 0);
            Assert.True(_graph.GetAdjacentEdges(0).First() == tempEdge);
            Assert.True(_graph.GetAdjacentEdges(4).First() == tempEdge);
            Assert.True(tempEdge.Weight == 0.33);
        }
    }
}
