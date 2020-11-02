package DataStructures.Graphs;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.PriorityQueue;

public class DijkstrasAlgorithm {
    class Node {
        int value;
        List<Edge> edges;

        int pathCost;

        Node(int valut) {
            this.value = valut;
            edges = new ArrayList();
            pathCost = Integer.MAX_VALUE;
        }
    }

    class Edge {
        Node target;
        int dist;

        Edge(int dist, Node target) {
            this.dist = dist;
            this.target = target;
        }
    }

    // This aproach deletes items from priorityQ on weight update. Other one without removing items could be found here
    // // https://github.com/chopdev/leetcode_tasks/tree/master/graph/743_network_delay_time

    //Time O(ElogE) in the heap implementation, as potentially every edge gets added to the heap
    // logE - here is add/remove operation to/from priorityQ, but seems that in java remove has O(N) complexity.
    //   solution is to use your own priority Q implementation (maintain an auxiliary data structure like
    //   a HashMap that maintains the mappings from a value in the priority queue to its position
    //   in the queue. So, at any given time - you would know the index position of any value.)
    //https://stackoverflow.com/questions/12719066/priority-queue-remove-complexity-time
    // Space O(E+N)
    public void getPath(int[][] edges, int startNode) {
        HashMap<Integer, Node> graph = new HashMap<>();
        // create graph
        for (int[] info : edges) {
            int source = info[0];
            int target = info[1];
            int weight = info[2];

            if(!graph.containsKey(source)) graph.put(source, new Node(source));
            if(!graph.containsKey(target)) graph.put(target, new Node(target));

            graph.get(source).edges.add(new Edge(weight, graph.get(target)));
        }

        // define min heap, and put startNode with pathCost = 0
        PriorityQueue<Node> heap = new PriorityQueue<>((o1, o2) -> Integer.compare(o1.pathCost, o2.pathCost));
        graph.get(startNode).pathCost = 0;
        heap.add(graph.get(startNode));

        for (int i = 0; i < graph.size(); i++) {
            if(heap.isEmpty()) break; // if heap.isEmpty() - there is no connection to startNode

            // remove from heap node with smallest weight
            Node curr = heap.poll();
            int distToCurr = curr.pathCost;
            for (Edge edge : curr.edges) {
                if(edge.dist + distToCurr < edge.target.pathCost) {
                    // distance to child node is bigger than from current node
                    heap.remove(edge.target);
                    edge.target.pathCost = edge.dist + distToCurr;
                    heap.add(edge.target);
                }
            }
        }
    }
}
