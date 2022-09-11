package DataStructures.Graphs;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 *  General info: https://en.wikipedia.org/wiki/Topological_sorting
 *  Topological sort - means creation of linear structure from a graph by removing nodes without dependencies one by one.
 *  A topological ordering is possible if and only if the graph has no directed cycles, that is, if it is a directed acyclic graph (DAG).
 *  Any DAG has at least one topological ordering.
 *
 *  Good example of tolopogical sort is build order of package and it's dependencies.
 *  see also leetcode problems #207, #2115
 * */
public class TopologicalSortDFS {

    public enum NodeStatus {
        NOT_TOUCHED,
        VISITING,
        VISITED
    }

    /**
     * Get graph nodes in order by dependencies. This algorithm supposes that if a -> b, then a is dependend from b.
     * Meaning that b should be processed first.
     * O(V+E) time complexity
     * O(V) space complexity
     *
     *
     * @param graph - node to the list of adjacent/child nodes
     * @return list of ordered nodes
     * */
    public List<Integer> getInOrder(Map<Integer, List<Integer>> graph) {
        if (graph == null || graph.isEmpty()) return new ArrayList<>();

        Map<Integer, NodeStatus> nodeToStatus = new HashMap<>();
        for (Integer key : graph.keySet())
            nodeToStatus.put(key, NodeStatus.NOT_TOUCHED);

        // might be used stack to reverse the result
        List<Integer> nodesInOrder = new ArrayList<>();

        for (Integer node : graph.keySet()) {
            if (!dfs(node, nodeToStatus, graph, nodesInOrder)) {
                throw new IllegalArgumentException("Graph has a direct cycle, topological sort is not possible");
            }
        }

        return nodesInOrder;
    }


    /**
     * @return returns false if loop is detected, meaning it's not possible to order nodes
     * */
    private boolean dfs(int currentNode, Map<Integer, NodeStatus> nodeToStatus,
                        Map<Integer, List<Integer>> graph,
                        List<Integer> result) {
        if (nodeToStatus.get(currentNode) == NodeStatus.VISITED)
            return true;

        if (nodeToStatus.get(currentNode) == NodeStatus.VISITING)
            return false; // found a cycle (loop), topological sort is not possible

        nodeToStatus.put(currentNode, NodeStatus.VISITING);

        for (Integer adjacentNode : graph.get(currentNode)) {
            if (!dfs(adjacentNode, nodeToStatus, graph, result)) {
                return false;
            }
        }

        nodeToStatus.put(currentNode, NodeStatus.VISITED);
        result.add(currentNode);
        return true;
    }
}
