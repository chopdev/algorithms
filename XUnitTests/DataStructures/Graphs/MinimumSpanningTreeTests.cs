using DataStructures.Graphs;
using DataStructures.Graphs.MinimumSpanningTree;
using System.Collections.Generic;
using Xunit;
using XUnitTests.DataStructures.Graphs.source;
using System.Linq;
using System;

namespace XUnitTests.DataStructures.Graphs
{
    public class MinimumSpanningTreeTests
    {
        // https://algs4.cs.princeton.edu/43mst/
        // MST test tree from Algorithms 4th Edition by Robert Sedgewick, page 614, 615
        [Fact(DisplayName = "MST: small graph")]
        public void TinyGraph()
        {
            var graph = GraphCreator.GetWeightedGraph();
            var kruskal = new KruskalMST(graph);
            var prim = new PrimMST(graph);
            var lazyMST = new LazyPrimMST(graph);

            Assert.True(kruskal.Weight == 1.81);
            Assert.True(prim.Weight == 1.81);
            Assert.True(lazyMST.Weight == 1.81);
        }

        [Fact(DisplayName = "MST: tiny mid graph")]
        public void TinyMidGraph()
        {
            var graph = GraphCreator.GetWeightedGraph("tiny-midEWG.txt");
            var kruskal = new KruskalMST(graph);
            var prim = new PrimMST(graph);
            var lazyMST = new LazyPrimMST(graph);

            Assert.True(Math.Round(kruskal.Weight, 2) == 2.37);
            Assert.True(Math.Round(prim.Weight, 2) == 2.37);
            Assert.True(Math.Round(lazyMST.Weight, 2) == 2.37);
        }

        [Fact(DisplayName = "MST: medium graph correct")]
        public void MidGraph()
        {
            var graph = GraphCreator.GetWeightedGraph("mediumEWG.txt");
            var kruskal = new KruskalMST(graph);
            var prim = new PrimMST(graph);
            var lazyMST = new LazyPrimMST(graph);

            HashSet<WeightedEdge<int>> set = new HashSet<WeightedEdge<int>>();

            foreach (var item in lazyMST.GetMST())
            {
                set.Add(item);
            }

            foreach (var item in kruskal.GetMST())
            {
                if (!set.Contains(item))
                {
                    int t = 4;
                }

                set.Add(item);
            }

            foreach (var item in prim.GetMST())
            {
                set.Add(item);
            }


            Assert.True(Math.Round(kruskal.Weight, 5) == 10.46351);
            Assert.True(Math.Round(lazyMST.Weight, 5) == 10.46351);
            Assert.True(Math.Round(prim.Weight, 5) == 10.46351);
        }
    }
}
