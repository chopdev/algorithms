using System.Collections.Generic;
using DataStructures.Graphs.SimplifiedGraphs;

namespace DataStructures.Graphs
{
    // NOTE: DIJKSTRA's algorithm works correctly only with POSITIVE weights of the edges
    public class DijkstrasAlgorithm
    {
        // Time Complexity - O(V^2 + E+ V) = O(V^2)
        public IList<Node> GetShortestPath(WeightedGraph graph, Node fromNode, Node toNode) {
            if (graph == null || graph.nodes == null) return null;

            HashSet<Node> visited = new HashSet<Node>();
            HashSet<Node> unvisited = new HashSet<Node>(graph.nodes);
            Dictionary<Node, int> nodeToShortestDist = new Dictionary<Node, int>(graph.nodes.Count);
            Dictionary<Node, Node> nodeToPrev = new Dictionary<Node, Node>(graph.nodes.Count);
            // O(V)
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

            // O(V^2 + E) - why? we are going through all unvisited vertices O(V) and get looking for closest one (V)
            // O(V^2) in result. But also for each vertex we are looking adjecent edges, all edges in sum give us O(E)
            // why (+ E), and not (*E), because for each vertex we are not looking all the edges of the graph, but only adjecent
            while (unvisited.Count > 0)
            {
                Node currNode = getClosestNode(nodeToShortestDist, visited);
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
                        child.dist = distToCurrNode + edge.weight;
                        nodeToPrev[child] = currNode;
                    }
                }

                unvisited.Remove(currNode);
                visited.Add(currNode);
            }

            List<Node> res = new List<Node>(graph.nodes.Count);
            Node temp = toNode;
            while(nodeToPrev.ContainsKey(temp))
            {
                res.Add(temp);
                temp = nodeToPrev[temp];
                if (nodeToPrev[temp] == temp) {
                    res.Add(temp);
                    break;
                }   
            }

            return res;
        }

        // we could use min heap here
        private Node getClosestNode(Dictionary<Node, int> nodeToShortestDist, HashSet<Node> visited) {
            Node closest = null;
            foreach (var item in nodeToShortestDist)
            {
                if (visited.Contains(item.Key))
                    continue;

                if (closest == null)
                {
                    closest = item.Key;
                    continue;
                }

                if(nodeToShortestDist[closest] > item.Value)
                {
                    closest = item.Key;
                }
            }

            return closest;
        }
    }
}
