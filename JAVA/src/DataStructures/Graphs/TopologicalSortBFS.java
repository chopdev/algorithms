package DataStructures.Graphs;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;
import java.util.Queue;

/**
 *  BFS topological sort is also called Kahn's algorithm
 *
 *  General info: https://en.wikipedia.org/wiki/Topological_sorting
 *  https://www.geeksforgeeks.org/topological-sorting-indegree-based-solution/
 *
 *  Topological sort - means creation of linear structure from a graph by removing nodes without dependencies one by one.
 *  A topological ordering is possible if and only if the graph has no directed cycles, that is, if it is a directed acyclic graph (DAG).
 *  Any DAG has at least one topological ordering.
 *
 *  Good example of tolopogical sort is build order of package and it's dependencies.
 *  https://leetcode.com/problems/course-schedule/discuss/162743/JavaC%2B%2BPython-BFS-Topological-Sorting-O(N-%2B-E)
 *  see also leetcode problems #207, #2115
 * */
public class TopologicalSortBFS {

    /**
     *  Get graph nodes in order by dependencies. This algorithm supposes that if a -> b, then a is dependend from b.
     *  Meaning that b should be processed first.
     *
     *  If a -> b means that a should be processed first, view this solution: https://leetcode.com/problems/course-schedule/discuss/162743/JavaC%2B%2BPython-BFS-Topological-Sorting-O(N-%2B-E)
     *
     * Algorithm: Steps involved in finding the topological ordering of a DAG:
     * Step-1: Compute in-degree (number of outgoing edges) for each of the vertex present in the GRAPH.
     * Step-2: Pick all the vertices with in-degree as 0 and add them into a queue (Enqueue operation)
     * Step-3: Remove a vertex from the queue (Dequeue operation) and enque decrease in-degree by 1 for all its neighbouring nodes
     *
     *  O(V+E) time complexity
     *  O(V) space complexity
     *
     * @param graph - node to the list of adjacent/child nodes
     * @return list of ordered nodes
     * */
    public List<Integer> getInOrder(Map<Integer, List<Integer>> graph) {
        if (graph == null || graph.isEmpty()) return new ArrayList<>();

        Queue<Integer> queue = new LinkedList<>();
        Map<Integer, Integer> nodeToDegree = new HashMap<>(); // number of outgoing edges

        Map<Integer, List<Integer>> reversedGraph = reverseGraph(graph); // get reversed graph to know what nodes are referencing current node (they are dependent on it)
        List<Integer> nodesInOrder = new ArrayList<>(); // result

        for (Integer node : graph.keySet()) {
            nodeToDegree.put(node, graph.get(node).size());
            if (nodeToDegree.get(node) == 0)
                queue.add(node);
        }

        while (!queue.isEmpty()) {
            int currentNode = queue.poll();
            nodesInOrder.add(currentNode);
            for (int referencingNode : reversedGraph.get(currentNode)) {
                nodeToDegree.put(referencingNode, nodeToDegree.get(referencingNode) - 1); // decrease degree of referencing nodes as current node is processed
                if (nodeToDegree.get(referencingNode) == 0) // if degree == 0, all dependencies are processed
                    queue.add(referencingNode);
            }
        }

        if (nodesInOrder.size() != graph.size()) {
            throw new IllegalArgumentException("Graph has a direct cycle, topological sort is not possible");
        }

        return nodesInOrder;
    }

    /**
     * Creates a graph of Node to List of referencing nodes.
     * */
    private Map<Integer, List<Integer>> reverseGraph(Map<Integer, List<Integer>> graph) {
        Map<Integer, List<Integer>> reversed = new HashMap<>();
        for (Integer node : graph.keySet()) reversed.put(node, new ArrayList<>());
        for (Map.Entry<Integer, List<Integer>> entry : graph.entrySet()) {
            for(Integer adjNode : entry.getValue()) reversed.get(adjNode).add(entry.getKey());
        }
        return reversed;
    }
}
