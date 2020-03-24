using DataStructures.Graphs;
using Xunit;

namespace XUnitTests.DataStructures.Graphs
{
    public class BreadthFirstSearchTests
    {
        public BreadthFirstSearchTests()
        { }

        [Fact]
        public void BFSWorkingForUndirectedGraph()
        {
            var vertexes = new[] { 1, 2, 3, 4, 0 };
            var graph = new UndirectedGraph<int>(vertexes);

            graph.AddEdge(0, 1);
            graph.AddEdge(0, 4);
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(1, 4);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 4);

            var level1 = BreadthFirstSearcher<int>.BFS(graph, 0, 2);
            Assert.Equal(level1, 2);
            var level2 = BreadthFirstSearcher<int>.BFS(graph, 0, 4);
            Assert.Equal(level2, 1);
            var level3 = BreadthFirstSearcher<int>.BFS(graph, 0, 5);
            Assert.Equal(level3, null);
            var level4 = BreadthFirstSearcher<int>.BFS(graph, 0, 0);
            Assert.Equal(level4, 0);
        }

        [Fact]
        public void BFSWorkingForWeightedUndirectedGraph()
        {
            var vertexes = new[] { 1, 2, 3, 4, 0 };
            var graph = new WeightedUndirectedGraph<int>(vertexes);

            graph.AddEdge(0, 1, 1.5);
            graph.AddEdge(0, 4, 1.5);
            graph.AddEdge(1, 2, 1.5);
            graph.AddEdge(1, 3, 1.5);
            graph.AddEdge(1, 4, 1.5);
            graph.AddEdge(2, 3, 1.5);
            graph.AddEdge(3, 4, 1.5);

            var level1 = BreadthFirstSearcher<int>.BFS(graph, 0, 2);
            Assert.Equal(level1, 2);
            var level2 = BreadthFirstSearcher<int>.BFS(graph, 0, 4);
            Assert.Equal(level2, 1);
            var level3 = BreadthFirstSearcher<int>.BFS(graph, 0, 5);
            Assert.Equal(level3, null);
            var level4 = BreadthFirstSearcher<int>.BFS(graph, 0, 0);
            Assert.Equal(level4, 0);
        }

        [Fact]
        public void BfsRecursiveWorking()
        {
            var _vertexes = new[] { 1, 2, 3, 4, 0 };
            var graph = new UndirectedGraph<int>(_vertexes);

            graph.AddEdge(0, 1);
            graph.AddEdge(0, 4);
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(1, 4);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 4);

            var level1 = BreadthFirstSearcher<int>.BfsRecursive(graph, 0, 2);
            Assert.Equal(level1, 2);
            var level2 = BreadthFirstSearcher<int>.BfsRecursive(graph, 0, 4);
            Assert.Equal(level2, 1);
            var level3 = BreadthFirstSearcher<int>.BfsRecursive(graph, 0, 5);
            Assert.Equal(level3, null);
            var level4 = BreadthFirstSearcher<int>.BfsRecursive(graph, 0, 0);
            Assert.Equal(level4, 0);
        }
    }
}
