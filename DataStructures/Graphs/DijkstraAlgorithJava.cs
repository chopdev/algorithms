using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Graphs
{
    /*
    
    // https://github.com/chopdev/leetcode_tasks/tree/master/graph/743_network_delay_time

     public class DejkstrasAlgorithm {
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

     //Time O(ElogE) in the heap implementation, as potentially every edge gets added to the heap
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

      */
}
