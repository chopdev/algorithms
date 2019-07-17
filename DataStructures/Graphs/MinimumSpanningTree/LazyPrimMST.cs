using DataStructures.Heap;
using System.Collections.Generic;

namespace DataStructures.Graphs.MinimumSpanningTree
{
    /*
     * https://algs4.cs.princeton.edu/43mst/LazyPrimMST.java.html 
     
     A minimum spanning tree (MST) or minimum weight spanning tree is a subset of the
     edges of a CONNECTED, edge-weighted UNDIRECTED graph that connects all the 
     vertices together, without any cycles and with the MINIMUM possible total edge 
     weight.

    Basic idea of the algorithm is to find a the edge with the smallest weight between edges that
    are already in MST and those vertices that are not
    */
    public class LazyPrimMST
    {
        // result MST edges
        private Queue<WeightedEdge<int>> _mstEdges;
        // vertices that belong to MST
        private HashSet<int> _marked;
        private PriorityQ<WeightedEdge<int>> _heap;

        public double Weight { get; private set; }

        public LazyPrimMST(IWeightedGraph<int> graph)
        {
            _mstEdges = new Queue<WeightedEdge<int>>(graph.Count - 1);
            _marked = new HashSet<int>(graph.Count);
            _heap = new PriorityQ<WeightedEdge<int>>();

            // run Prim from all vertices to get a minimum spanning forest
            foreach (int vertex in graph)
                if (!_marked.Contains(vertex)) DefineMST(graph, vertex);
        }

        public IEnumerable<WeightedEdge<int>> GetMST()
        {
            return _mstEdges;
        }

        private void DefineMST(IWeightedGraph<int> graph, int currVertex)
        {
            Scan(graph, currVertex);
            // get MST of connected vertices
            while (!_heap.empty())
            {
                WeightedEdge<int> shortestEdge = _heap.pop();
                if (_marked.Contains(shortestEdge.VertexA) && _marked.Contains(shortestEdge.VertexB))
                    continue;

                _mstEdges.Enqueue(shortestEdge);
                Weight += shortestEdge.Weight;
                if (!_marked.Contains(shortestEdge.VertexA)) Scan(graph, shortestEdge.VertexA);
                else Scan(graph, shortestEdge.VertexB);
            }
        }

        // add edges other vertice of which has not yet been scanned
        private void Scan(IWeightedGraph<int> graph, int currVertex)
        {
            _marked.Add(currVertex);
            foreach (var edge in graph.GetAdjacentEdges(currVertex))
            {
                if(!_marked.Contains(edge.GetOther(currVertex)))
                    _heap.insert(edge);
            }
        }
    }
}
