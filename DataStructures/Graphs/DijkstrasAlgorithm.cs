using System;
using System.Collections.Generic;
using System.Text;
using DataStructures.Graphs.SimplifiedGraphs;

namespace DataStructures.Graphs
{
    // NOTE: DIJKSTRA's algorithm works correctly only with POSITIVE weights of the edges
    public class DijkstrasAlgorithm
    {
        public IList<Node> GetShortestPath(WeightedGraph graph, Node fromNode) {
            if (graph == null || graph.nodes == null) return null;

            HashSet<Node> visited = new HashSet<Node>();
            HashSet<Node> unvisited = new HashSet<Node>(graph.nodes);
            Dictionary<Node, int> nodeToShortestDist = new Dictionary<Node, int>(graph.nodes.Count);
            Dictionary<Node, Node> nodeToPrev = new Dictionary<Node, Node>(graph.nodes.Count);
            foreach (var item in graph.nodes)
            {
                if (item == fromNode)
                {
                    nodeToShortestDist[item] = 0;
                    nodeToPrev[item] = item;
                }
                else
                    nodeToShortestDist[item] = int.MaxValue;
            }

            while(unvisited.Count > 0)
            {
                Node currNode = getClosestNode(nodeToShortestDist);
                int distToCurrNode = nodeToShortestDist[currNode];

                foreach (var edge in currNode.edges)
                {
                    Node child = edge.destination;
                    if (visited.Contains(child))
                        continue;

                    int childShortest = nodeToShortestDist[child];

                    if (childShortest > distToCurrNode + edge.weight)
                    {
                        nodeToShortestDist[child] = distToCurrNode + edge.weight;
                        nodeToPrev[child] = currNode;
                    }
                }

                unvisited.Remove(currNode);
                visited.Add(currNode);
            }

            List<Node> res = new List<Node>(graph.nodes.Count);
            Node temp = fromNode;
            while(nodeToPrev.ContainsKey(temp))
            {
                res.Add(temp);
                temp = nodeToPrev[temp];
            }

            return res;
        }

        private Node getClosestNode(Dictionary<Node, int> nodeToShortestDist) {
            Node closest = null;
            foreach (var item in nodeToShortestDist)
            {
                if (closest == null)
                {
                    closest = item.Key;
                    continue;
                }

                if(closest.value < item.Value)
                {
                    closest = item.Key;
                }
            }

            return closest;
        }
    }
}
