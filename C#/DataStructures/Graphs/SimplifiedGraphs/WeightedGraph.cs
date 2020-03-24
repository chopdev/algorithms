using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Graphs.SimplifiedGraphs
{
    public class WeightedGraph
    {
        public List<Node> nodes;

        public WeightedGraph(IList<Node> list) {
            nodes = new List<Node>(list);
        }
    }

    public class Node : IComparable<Node> {
        public string name { get; set; }
        /// <summary>
        /// distance from starting node
        /// </summary>
        public int dist { get; set; }
        public List<Edge> edges;

        public Node() {
            edges = new List<Edge>();
        }

        public Node(IList<Edge> list) {
            edges = new List<Edge>(list);
        }

        public int CompareTo(Node other)
        {
            return this.dist > other.dist ? 1 : -1;
        }
    }

    public class Edge {
        public Node destination { get; set; }
        public int weight { get; set; }
    }
}
