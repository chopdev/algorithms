using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures.Graphs;

namespace UnitTests.DataStructures
{
    [TestClass]
    public class UndirectedGraphTests
    {
        int[] _vertexes;
        UndirectedGraph<int> _graph;

        [TestInitialize]
        public void InitializeGraph()
        {
            _vertexes = new[] { 1, 2, 3, 4, 0 };
            _graph = new UndirectedGraph<int>(_vertexes);
        }

        [TestMethod]
        public void AddVertexCorrect()
        {
            Assert.IsFalse(_graph.HasVertex(5));
            _graph.AddVertex(5);
            Assert.IsTrue(_graph.HasVertex(5));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddVertexThrowsException()
        {
            _graph.AddVertex(0);
        }

        [TestMethod]
        public void RemoveVertexCorrect()
        {
            Assert.IsTrue(_graph.HasVertex(4));
            _graph.RemoveVertex(4);
            Assert.IsFalse(_graph.HasVertex(4));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveVertexThrowsExceptions()
        {
            _graph.RemoveVertex(6);
        }

        [TestMethod]
        public void AddEdgeCorrect()
        {
            Assert.IsFalse(_graph.HasEdge(1, 0));
            Assert.IsFalse(_graph.HasEdge(1, 2));
            _graph.AddEdge(0, 1);
            _graph.AddEdge(1, 2);
            Assert.IsTrue(_graph.HasEdge(1, 0));
            Assert.IsTrue(_graph.HasEdge(1, 2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddEdgeThrowsException()
        {
            _graph.AddEdge(0, 65);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddEdgeThrowsExceptionOnDuplicate()
        {
            _graph.AddEdge(0, 3);
            _graph.AddEdge(0, 3);
        }

        [TestMethod]
        public void RemoveEdgeCorrect()
        {
            _graph.AddEdge(0, 1);
            Assert.IsTrue(_graph.HasEdge(1, 0));
            _graph.RemoveEdge(0, 1);
            Assert.IsFalse(_graph.HasEdge(1, 0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveEdgeThrowException()
        {
            _graph.RemoveEdge(0, 65);
        }

        [TestMethod]
        public void IteratorWorking()
        {
            int i = 0;
            foreach (var vertex in _graph)
            {
                Assert.AreEqual(vertex, _vertexes[i]);
                i++;
            }        
        }

        [TestMethod]
        public void BFSWorking()
        {
            _graph.AddEdge(0, 1);
            _graph.AddEdge(0, 4);
            _graph.AddEdge(1, 2);
            _graph.AddEdge(1, 3);
            _graph.AddEdge(1, 4);
            _graph.AddEdge(2, 3);
            _graph.AddEdge(3, 4);

            var level1 = _graph.BFS(0, 2);
            Assert.AreEqual(level1, 2);
            var level2 = _graph.BFS(0, 4);
            Assert.AreEqual(level2, 1);
            var level3 = _graph.BFS(0, 5);
            Assert.AreEqual(level3, null);
            var level4 = _graph.BFS(0, 0);
            Assert.AreEqual(level4, 0);
        }
    }
}
