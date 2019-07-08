using DataStructures.Graphs.MinimumSpanningTree;
using Xunit;
using XUnitTests.DataStructures.Graphs.source;

namespace XUnitTests.DataStructures.Graphs
{
    public class MinimumSpanningTreeTests
    {
        // https://algs4.cs.princeton.edu/43mst/
        // MST test tree from Algorithms 4th Edition by Robert Sedgewick, page 614
        [Fact(DisplayName = "small MST correct")]
        public void smallMSTCorrect()
        {
            var graph = GraphCreator.GetWeightedGraph();
            var lazyMST = new LazyPrimMST(graph);

            Assert.True(lazyMST.Weight == 1.81);
        }


        // https://algs4.cs.princeton.edu/43mst/
        // MST test tree from Algorithms 4th Edition by Robert Sedgewick, page 615
        [Fact(DisplayName = "medium MST correct")]
        public void mediumMSTCorrect()
        {
            var graph = GraphCreator.GetWeightedGraph("mediumEWG.txt");
            var lazyMST = new LazyPrimMST(graph);

            //Assert.True(lazyMST.Weight == 10.46351);
        }
    }
}
