using DataStructures.Graphs.SimplifiedGraphs;
using System.Collections.Generic;
using DataStructures.Heap;

namespace DataStructures.Graphs
{
    // Basically Dijkstras algorithm sets shortest distance form start node to each node in the tree
    // NOTE: DIJKSTRA's algorithm works correctly only with POSITIVE weights of the edges
    public class DijkstrasAlgorithmHeap
    {
        // Time complexity O(E*log(V) + V) = O(E*logV)
        public IList<Node> GetShortestPath(WeightedGraph graph, Node fromNode, Node toNode)
        {
            if (graph == null || graph.nodes == null) return null;

            var nodeToPrev = new Dictionary<Node, Node>(graph.nodes.Count);
            var heap = new MinHeap<Node>();

            // O(V), because all the nodes except one have equal priority (distance from starting point) 
            foreach (var node in graph.nodes)
            {
                if (node == fromNode)
                {
                    nodeToPrev[node] = node;
                    node.dist = 0;
                }
                else {
                    node.dist = int.MaxValue;
                }

                heap.add(node);
            }

            while (heap.length() > 0) {
                var currNode = heap.pop();  // get closest to initial node, O(log(V))

                // O(E*log(V)) - for E edges we will do heapify O(logV)
                // we have E*log(V) here, because we always remove vertex when we update the distane to it
                // if we would just add each time new dist to heap, we would have O(E*logE) complexity, as in 
                // heap we will have E items
                foreach (var edge in currNode.edges)
                {
                    Node child = edge.destination;

                    // processed vertexes will have less dist
                    if (child.dist > currNode.dist + edge.weight)
                    {
                        nodeToPrev[child] = currNode;
                        child.dist = currNode.dist + edge.weight; // update weight
                        heap.remove(child); // change position in heap, bubble element up
                        heap.add(child);
                    }
                }
            }

            var res = new List<Node>();
            while (nodeToPrev.ContainsKey(toNode)) {
                res.Add(toNode);
                toNode = nodeToPrev[toNode];
                if (nodeToPrev.ContainsKey(toNode) && toNode == nodeToPrev[toNode]) {
                    res.Add(toNode);
                    break;
                }
            }

            return res;
        }
    }
}
