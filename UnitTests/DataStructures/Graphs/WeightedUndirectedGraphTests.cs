using DataStructures.Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests.DataStructures.Graphs
{
    [TestClass]
    class WeightedUndirectedGraphTests
    {
        int[] _vertexes;
        WeightedUndirectedGraph<int> _graph;

        [TestInitialize]
        public void InitializeGraph()
        {
            _vertexes = new[] { 1, 2, 3, 4, 0 };
            _graph = new WeightedUndirectedGraph<int>(_vertexes);
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
            _graph.AddEdge(0, 1, 1.4);
            _graph.AddEdge(1, 2, 1.5);
            Assert.IsTrue(_graph.HasEdge(1, 0));
            Assert.IsTrue(_graph.HasEdge(1, 2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddEdgeThrowsException()
        {
            _graph.AddEdge(0, 65, 1.5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddEdgeThrowsExceptionOnDuplicate()
        {
            _graph.AddEdge(0, 3, 1.5);
            _graph.AddEdge(0, 3, 1.5);
        }

        [TestMethod]
        public void RemoveEdgeCorrect()
        {
            _graph.AddEdge(0, 1, 1.5);
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
        public void WeightedEdgeBehavesCorrect()
        {
            var test1 = new TestClass() { Temp = "test" };
            var weightedEdge1 = new WeightedEdge<TestClass>(test1);
            var weightedEdge2 = new WeightedEdge<TestClass>(new TestClass());
            var weightedEdge3 = new WeightedEdge<TestClass>(test1, 1.5);

            Assert.AreNotEqual(weightedEdge1, weightedEdge2);
            Assert.AreEqual(weightedEdge1, weightedEdge3);
        }

        [TestMethod]
        public void GetWeightWorkingRight()
        {
            _graph.AddEdge(1, 3, 1.6);
            _graph.AddEdge(1, 4, 2.8);

            var weight1 = _graph.GetWeight(1, 3);
            var weight2 = _graph.GetWeight(3, 1);
            var weight3 = _graph.GetWeight(1, 4);
            var weight4 = _graph.GetWeight(4, 1);
            Assert.AreEqual(weight1, 1.6);
            Assert.AreEqual(weight2, 1.6);
            Assert.AreEqual(weight3, 2.8);
            Assert.AreEqual(weight4, 2.8);
        }

        [TestMethod]
        public void ChangeWeightWorkingRight()
        {
            _graph.AddEdge(1, 3, 1.6);

            var weight1 = _graph.GetWeight(1, 3);
            var weight2 = _graph.GetWeight(3, 1);

            Assert.AreEqual(weight1, 1.6);
            Assert.AreEqual(weight2, 1.6);

            _graph.ChangeWeight(1, 3, 28.9);
            weight1 = _graph.GetWeight(1, 3);
            weight2 = _graph.GetWeight(3, 1);

            Assert.AreEqual(weight1, 28.9);
            Assert.AreEqual(weight2, 28.9);
        }
    }

    internal class TestClass {
        public string Temp { get; set; }
    }
}
