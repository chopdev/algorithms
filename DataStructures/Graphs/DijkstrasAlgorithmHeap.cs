using DataStructures.Graphs.SimplifiedGraphs;
using System;
using System.Collections.Generic;
using System.Text;
using DataStructures.Heap;

namespace DataStructures.Graphs
{
    public class DijkstrasAlgorithmHeap
    {
        public IList<Node> GetShortestPath(WeightedGraph graph, Node fromNode, Node toNode)
        {
            if (graph == null || graph.nodes == null) return null;

            var nodeToPrev = new Dictionary<Node, Node>(graph.nodes.Count);
            var heap = new MinHeap<Node>();

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
                var currNode = heap.pop();  // get closest to initial node

                foreach (var edge in currNode.edges)
                {
                    Node child = edge.destination;
                    int childHeapInd = heap.getIndex(child);

                    if (childHeapInd < 0) continue; // this vertex is processed already

                    if (child.dist > currNode.dist + edge.weight)
                    {
                        nodeToPrev[child] = currNode;
                        child.dist = currNode.dist + edge.weight; // update weight
                        heap.heapify(childHeapInd); // change position in heap, bubble element up
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
