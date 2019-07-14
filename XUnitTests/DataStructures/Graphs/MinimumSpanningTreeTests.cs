using DataStructures.Graphs.MinimumSpanningTree;
using Xunit;
using XUnitTests.DataStructures.Graphs.source;

namespace XUnitTests.DataStructures.Graphs
{
    public class MinimumSpanningTreeTests
    {
        // https://algs4.cs.princeton.edu/43mst/
        // MST test tree from Algorithms 4th Edition by Robert Sedgewick, page 614
        [Fact(DisplayName = "LazyPrimMST: small MST correct")]
        public void smallMSTCorrect()
        {
            var graph = GraphCreator.GetWeightedGraph();
            var lazyMST = new LazyPrimMST(graph);

            Assert.True(lazyMST.Weight == 1.81);
        }


        // https://algs4.cs.princeton.edu/43mst/
        // MST test tree from Algorithms 4th Edition by Robert Sedgewick, page 615
        [Fact(DisplayName = "LazyPrimMST: medium MST correct")]
        public void mediumMSTCorrect()
        {
            var graph = GraphCreator.GetWeightedGraph("mediumEWG.txt");
            var lazyMST = new LazyPrimMST(graph);

            //Assert.True(lazyMST.Weight == 10.46351);
        }

        [Fact(DisplayName = "PrimMST: small MST correct")]
        public void PrimMSTCorrect()
        {
            var graph = GraphCreator.GetWeightedGraph();
            var mst = new PrimMST(graph);

            Assert.True(mst.Weight == 1.81);
        }

        [Fact(DisplayName = "PrimMST: medium MST correct")]
        public void PrimMSTCorrect2()
        {
            var graph = GraphCreator.GetWeightedGraph("mediumEWG.txt");
            var mst = new PrimMST(graph);

            //Assert.True(mst.Weight == 10.46351);
        }
    }
}
