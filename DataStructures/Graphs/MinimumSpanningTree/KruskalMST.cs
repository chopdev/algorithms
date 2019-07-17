using DataStructures.Heap;
using System.Collections.Generic;

namespace DataStructures.Graphs.MinimumSpanningTree
{
    /*https://algs4.cs.princeton.edu/43mst/KruskalMST.java.html 

     A minimum spanning tree (MST) or minimum weight spanning tree is a subset of the
     edges of a CONNECTED, edge-weighted UNDIRECTED graph that connects all the 
     vertices together, without any cycles and with the MINIMUM possible total edge 
     weight.

    Basic idea of the algorithm is to fill the heap of all edges. Then process each min edge, if vertices are both not in MST (not connected in union find)
    then add the edge to MST. 
    */
    public class KruskalMST
    {
        private UnionFind _uf;  // to detect cycles (if two vertices are already connected)
        private Queue<WeightedEdge<int>> _mstEdges; // result queue of edges
        private PriorityQ<WeightedEdge<int>> _heap;   // min heap of all edges of a graph

        public double Weight { get; private set; }

        public KruskalMST(IWeightedGraph<int> graph)
        {
            _uf = new UnionFind(graph.Count);
            _mstEdges = new Queue<WeightedEdge<int>>(graph.Count - 1);
            _heap = new PriorityQ<WeightedEdge<int>>();

            foreach (var edge in graph.GetEdges())
            {
                _heap.insert(edge);
            }

            DefineMST(graph);
        }

        public IEnumerable<WeightedEdge<int>> GetMST()
        {
            return _mstEdges;
        }

        private void DefineMST(IWeightedGraph<int> graph)
        {
            while (!_heap.empty() || _mstEdges.Count < graph.Count - 1)
            {
                var minEdge = _heap.pop();
                if (_uf.Connected(minEdge.VertexA, minEdge.VertexB)) continue;

                _uf.Union(minEdge.VertexA, minEdge.VertexB);
                Weight += minEdge.Weight;
                _mstEdges.Enqueue(minEdge);
            }
        }
    }
}
