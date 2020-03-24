using System;
using System.Collections.Generic;
using DataStructures.Graphs;
using Xunit;

namespace UnitTests.DataStructures.Graphs
{
    public class Room : IComparable<Room>
    {
        public Room(string name)
        {
            Name = name;
        }
        public string Name { get; set; }

        public int CompareTo(Room other)
        {
            return Name.CompareTo(other.Name);
        }
    }

    public class DepthFirstSearchTests
    {
        [Fact]
        public void IsDepthFirstSearchRecursiveSequenceCorrect()
        {
            var list = new List<Room>();
            var roomA = new Room("A");
            list.Add(roomA);
            var roomB = new Room("B");
            list.Add(roomB);
            var roomC = new Room("C");
            list.Add(roomC);
            var roomD = new Room("D");
            list.Add(roomD);
            var roomE = new Room("E");
            list.Add(roomE);
            var roomF = new Room("F");
            list.Add(roomF);

            var graph = new UndirectedGraph<Room>(list);
            graph.AddEdge(roomA, roomC);
            graph.AddEdge(roomC, roomD);
            graph.AddEdge(roomD, roomB);
            graph.AddEdge(roomD, roomE);
            graph.AddEdge(roomD, roomF);

            var sequence = DepthFirstSearcher<Room>.DepthFirstSearchRecursive(graph, roomA);
            Console.WriteLine(sequence);
            var expectedSequence = new List<Room>(new Room[] { roomA, roomC, roomD, roomB, roomE, roomF });
            Assert.Equal(expectedSequence.Count, sequence.Count);
            for (int i = 0; i < expectedSequence.Count; i++)
            {
                Assert.Same(expectedSequence[i], sequence[i]);
            }
        }

        [Fact]
        public void IsDepthFirstSearchSequenceCorrect()
        {
            var list = new List<Room>();
            var roomA = new Room("A");
            list.Add(roomA);
            var roomB = new Room("B");
            list.Add(roomB);
            var roomC = new Room("C");
            list.Add(roomC);
            var roomD = new Room("D");
            list.Add(roomD);
            var roomE = new Room("E");
            list.Add(roomE);
            var roomF = new Room("F");
            list.Add(roomF);

            var graph = new UndirectedGraph<Room>(list);
            graph.AddEdge(roomA, roomC);
            graph.AddEdge(roomC, roomD);
            graph.AddEdge(roomD, roomB);
            graph.AddEdge(roomD, roomE);
            graph.AddEdge(roomD, roomF);

            var sequence = DepthFirstSearcher<Room>.DepthFirstSearch(graph, roomA);
            Console.WriteLine(sequence);
            var expectedSequence = new List<Room>(new Room[] { roomA, roomC, roomD, roomF, roomE, roomB });
            Assert.Equal(expectedSequence.Count, sequence.Count);
            for (int i = 0; i < expectedSequence.Count; i++)
            {
                Assert.Same(expectedSequence[i], sequence[i]);
            }
        }

        [Fact]
        public void IsDepthFirstSearchPathCorrect()
        {
            var list = new List<Room>();
            var roomA = new Room("A");
            list.Add(roomA);
            var roomB = new Room("B");
            list.Add(roomB);
            var roomC = new Room("C");
            list.Add(roomC);
            var roomD = new Room("D");
            list.Add(roomD);
            var roomE = new Room("E");
            list.Add(roomE);
            var roomF = new Room("F");
            list.Add(roomF);

            var graph = new UndirectedGraph<Room>(list);
            graph.AddEdge(roomA, roomC);
            graph.AddEdge(roomC, roomD);
            graph.AddEdge(roomD, roomB);
            graph.AddEdge(roomD, roomE);
            graph.AddEdge(roomD, roomF);

            var path = DepthFirstSearcher<Room>.DepthFirstSearchPath(graph, roomA, roomE);
            
            var expectedPath = new List<Room>(new Room[] { roomA, roomC, roomD, roomE });
            Assert.Equal(expectedPath.Count, path.Count);
            for (int i = 0; i < expectedPath.Count; i++)
            {
                Assert.Same(expectedPath[i], path[i]);
            }
        }

        [Fact]
        public void IsDepthFirstRecursiveSearchPathCorrect()
        {
            var list = new List<Room>();
            var roomA = new Room("A");
            list.Add(roomA);
            var roomB = new Room("B");
            list.Add(roomB);
            var roomC = new Room("C");
            list.Add(roomC);
            var roomD = new Room("D");
            list.Add(roomD);
            var roomE = new Room("E");
            list.Add(roomE);
            var roomF = new Room("F");
            list.Add(roomF);

            var graph = new UndirectedGraph<Room>(list);
            graph.AddEdge(roomA, roomC);
            graph.AddEdge(roomC, roomD);
            graph.AddEdge(roomD, roomB);
            graph.AddEdge(roomD, roomE);
            graph.AddEdge(roomD, roomF);

            var path = DepthFirstSearcher<Room>.DepthFirstSearchRecursivePath(graph, roomA, roomE);

            var expectedPath = new List<Room>(new Room[] { roomA, roomC, roomD, roomE });
            Assert.Equal(expectedPath.Count, path.Count);
            for (int i = 0; i < expectedPath.Count; i++)
            {
                Assert.Same(expectedPath[i], path[i]);
            }
        }
    }
}
