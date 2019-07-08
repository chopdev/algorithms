using DataStructures.Heap;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Graphs.MinimumSpanningTree
{
    /*
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

            int currVertex = graph.GetEnumerator().Current; // take first random vertex
            
            // we suppose that graph is connected
            for (int i = 0; i < graph.Count - 1; i++)
            {
                _marked.Add(currVertex);
                foreach (var edge in graph.GetAdjacentEdges(currVertex))
                {
                    _heap.insert(edge);
                }

                WeightedEdge<int> shortestEdge = _heap.pop();
                while (_marked.Contains(shortestEdge.VertexA) && _marked.Contains(shortestEdge.VertexB))
                {
                    shortestEdge = _heap.pop();
                }

                _mstEdges.Enqueue(shortestEdge);
                Weight += shortestEdge.Weight;
                currVertex = _marked.Contains(shortestEdge.VertexA) ? shortestEdge.VertexB : shortestEdge.VertexA;
            }
        }

        public IEnumerable<WeightedEdge<int>> GetMST()
        {
            return _mstEdges;
        }
    }
}
