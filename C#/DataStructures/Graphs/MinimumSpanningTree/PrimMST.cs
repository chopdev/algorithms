using DataStructures.Heap;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Graphs.MinimumSpanningTree
{
    /*
     * https://algs4.cs.princeton.edu/43mst/PrimMST.java.html
     
     A minimum spanning tree (MST) or minimum weight spanning tree is a subset of the
     edges of a CONNECTED, edge-weighted UNDIRECTED graph that connects all the 
     vertices together, without any cycles and with the MINIMUM possible total edge 
     weight.

    Basic idea of the algorithm is to keep track of the shortest distance from MST to each vertex that is not in MST.
    */
    public class PrimMST
    {
        // vertex to the shortest edge that connects this vertex to MST
        private Dictionary<int, WeightedEdge<int>> _vertexToShortestEdge;
        // vertices that belong to MST
        private HashSet<int> _marked;
        private MinHeap<WeightedEdge<int>> _heap;

        public double Weight { get; private set; }

        public PrimMST(IWeightedGraph<int> graph)
        {
            _vertexToShortestEdge = new Dictionary<int, WeightedEdge<int>>();
            _marked = new HashSet<int>(graph.Count);
            _heap = new MinHeap<WeightedEdge<int>>();

            // run Prim from all vertices to get a minimum spanning forest
            foreach (int vertex in graph)
                if (!_marked.Contains(vertex)) DefineMST(graph, vertex);
        }

        public IEnumerable<WeightedEdge<int>> GetMST()
        {
            return _vertexToShortestEdge.Values;
        }

        private void DefineMST(IWeightedGraph<int> graph, int currVertex)
        {
            Scan(graph, currVertex);
            // get MST of connected vertices
            while (_heap.length() > 0)
            {
                WeightedEdge<int> shortestEdge = _heap.pop();
                if (_marked.Contains(shortestEdge.VertexA) && _marked.Contains(shortestEdge.VertexB))
                    continue;

                Weight += shortestEdge.Weight;
                if (!_marked.Contains(shortestEdge.VertexA)) Scan(graph, shortestEdge.VertexA);
                else Scan(graph, shortestEdge.VertexB);
            }
        }

        private void Scan(IWeightedGraph<int> graph, int currVertex)
        {
            _marked.Add(currVertex);
            foreach (var edge in graph.GetAdjacentEdges(currVertex))
            {
                int otherVertex = edge.GetOther(currVertex);
                if (_marked.Contains(otherVertex)) continue;

                if (!_vertexToShortestEdge.ContainsKey(otherVertex) || _vertexToShortestEdge[otherVertex].Weight > edge.Weight)
                {
                    if(_vertexToShortestEdge.ContainsKey(otherVertex)) _heap.remove(_vertexToShortestEdge[otherVertex]);
                    _vertexToShortestEdge[otherVertex] = edge;
                    _heap.add(edge);
                }
            }
        }
    }
}
