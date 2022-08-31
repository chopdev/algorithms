package DataStructures.Graphs;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.PriorityQueue;

public class DijkstrasAlgorithm {

    class Edge {
        int distance;
        int target;

        public Edge(int target, int distance) {
            this.target = target;
            this.distance = distance;
        }
    }

    /**
     * Time: O(E * logV) in the heap implementation.
     * V - number of verticies, E - number of edges
     * logV - here is add/remove operation to/from priorityQ.
     * Space: O(E+V)
     * https://stackoverflow.com/questions/26547816/understanding-time-complexity-calculation-for-dijkstra-algorithm
     *
     * Alternative implementations: https://github.com/chopdev/leetcode_tasks/tree/master/graph/743_network_delay_time
     *
     * @param edges - list {vertex1, vertex2, distance}
     * @param startNode - starting node, from which we calculate distances
     * @return - array of distances from starting node, where index is a vertex (node)
     * */
    public int[] dfs(int[][] edges, int startNode) {
        Map<Integer, List<Edge>> graph = new HashMap<>();

        // create graph, suppose that every edge is bidirectional
        for (int[] edge : edges) {
            if (!graph.containsKey(edge[0])) graph.put(edge[0], new ArrayList<>());
            if (!graph.containsKey(edge[1])) graph.put(edge[1], new ArrayList<>());

            graph.get(edge[0]).add(new Edge(edge[1], edge[2]));
            graph.get(edge[1]).add(new Edge(edge[0], edge[2]));
        }

        // final distance to node from startNode node
        int[] dist = new int[graph.size()];  // could be made as HashMap
        Arrays.fill(dist, Integer.MAX_VALUE); // initially everything is not reachable from starting node

        // heap make the algorithm greedy, we pick up the closest node from startingNode and update dist[]
        PriorityQueue<int[]> heap = new PriorityQueue<>((o1, o2) -> Integer.compare(o1[1], o2[1])); // int[] {node, dist to node}
        heap.add(new int[] {0, 0});

        while (!heap.isEmpty()) {
            int[] pair = heap.poll();
            int currNode = pair[0];
            int distToCurrentNode = pair[1];

            if (distToCurrentNode > dist[currNode]) {
                continue; // we have found more optimal path already
            }
            // update distance to current node
            dist[currNode] = distToCurrentNode;

            // add all adjacent nodes of current node
            for (Edge edge : graph.get(currNode)) {
                int targetNodeDist = distToCurrentNode + edge.distance;
                int targetNode = edge.target;

                if (targetNodeDist < dist[targetNode]) {
                    heap.add(new int[] {targetNode, targetNodeDist});
                }
            }
        }

        return dist;
    }
}
