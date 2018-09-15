using System;
using System.Collections.Generic;
using System.Text;
using DataStructures.Graphs.SimplifiedGraphs;
using Xunit;
using DataStructures.Graphs;

namespace XUnitTests.DataStructures.Graphs
{
    //https://www.youtube.com/watch?v=pVfj6mxhdMw 
    public class DijkstrasAlgorithmTests
    {
        public class Lol : IComparable<Lol> {
            public int val;

            public int CompareTo(Lol other)
            {
                return this.val > other.val ? 1 : -1;
            }
        }
        [Fact(DisplayName = "Temp")]
        public void Temp() {
            Lol l1 = new Lol() { val = 1 };
            Lol l2 = new Lol() { val = 2 };
            Lol l3 = new Lol() { val = -1 };
            Lol l4 = new Lol() { val = 4 };

            SortedDictionary<Lol, int> ttt = new SortedDictionary<Lol, int>();
            ttt.Add(l1, 1);
            ttt.Add(l2, 2);
            ttt.Add(l3, 3);

           // l3.val = -1; modification do not updates sequence of the dictionary
            ttt.Add(l4, 4);
            foreach (var item in ttt)
            {

            }
            Assert.True(true);
        }

        [Fact(DisplayName = "Dijkstras ShortestPassCorrect")]
        public void ShortestPassCorrect() {
            Node a = new Node() { name = "A" };
            Node b = new Node() { name = "B" };
            Node c = new Node() { name = "C" };
            Node d = new Node() { name = "D" };
            Node e = new Node() { name = "E" };

            Edge e1 = new Edge() { destination = d, weight = 1 };
            Edge e2 = new Edge() { destination = b, weight = 6 };
            a.edges.Add(e1);
            a.edges.Add(e2);

            Edge e3 = new Edge() { destination = a, weight = 1 };
            Edge e4 = new Edge() { destination = b, weight = 2 };
            Edge e5 = new Edge() { destination = e, weight = 1 };
            d.edges.Add(e3);
            d.edges.Add(e4);
            d.edges.Add(e5);

            Edge e6 = new Edge() { destination = a, weight = 6 };
            Edge e7 = new Edge() { destination = d, weight = 2 };
            Edge e8 = new Edge() { destination = e, weight = 2 };
            b.edges.Add(e6);
            b.edges.Add(e7);
            b.edges.Add(e8);

            Edge e9 = new Edge() { destination = d, weight = 1 };
            Edge e10 = new Edge() { destination = b, weight = 2 };
            Edge e11 = new Edge() { destination = c, weight = 5 };
            e.edges.Add(e9);
            e.edges.Add(e10);
            e.edges.Add(e11);

            Edge e12 = new Edge() { destination = b, weight = 5 };
            Edge e13 = new Edge() { destination = e, weight = 5 };
            c.edges.Add(e12);
            c.edges.Add(e13);

            WeightedGraph graph = new WeightedGraph(new Node[] { a,b,c,d,e});
            DijkstrasAlgorithm dijkstrasAlgorithm = new DijkstrasAlgorithm();
            IList<Node> nodes = dijkstrasAlgorithm.GetShortestPath(graph, a, c);

            Assert.True(nodes[0] == c);
            Assert.True(nodes[1] == e);
            Assert.True(nodes[2] == d);
            Assert.True(nodes[3] == a);

            Assert.True(a.dist == 0);
            Assert.True(d.dist == 1);
            Assert.True(b.dist == 3);
            Assert.True(e.dist == 2);
            Assert.True(c.dist == 7);
        }
    }
}
