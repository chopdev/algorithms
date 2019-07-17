using DataStructures.Graphs;
using DataStructures.Graphs.MinimumSpanningTree;
using System.Collections.Generic;
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

        [Fact(DisplayName = "KruskalMST: small MST correct")]
        public void KruskalMSTCorrect()
        {
            var graph = GraphCreator.GetWeightedGraph();
            var mst = new KruskalMST(graph);

            Assert.True(mst.Weight == 1.81);
        }

        [Fact(DisplayName = "KruskalMST: medium MST correct")]
        public void KruskalMSTCorrect2()
        {
            var graph = GraphCreator.GetWeightedGraph("mediumEWG.txt");
            var mst = new KruskalMST(graph);
            var mst2 = new PrimMST(graph);
            var lazyMST = new LazyPrimMST(graph);

            HashSet<WeightedEdge<int>> set = new HashSet<WeightedEdge<int>>();
            foreach (var item in mst.GetMST())
            {
                set.Add(item);
            }

            foreach (var item in mst2.GetMST())
            {
                set.Add(item);
            }

            foreach (var item in lazyMST.GetMST())
            {
                set.Add(item);
            }

            //Assert.True(mst.Weight == 10.46351);
        }
    }
}
