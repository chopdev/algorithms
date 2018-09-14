using System;
using System.Collections;
using System.Collections.Generic;
using DataStructures.Graphs.Interfaces;

namespace DataStructures.Graphs
{
    /// <summary>
    /// Undirected unweighted graph structure
    /// </summary>
    /// <typeparam name="T">Vertex type</typeparam>
    public class UndirectedGraph<T> : IUnweightedGraph<T>
    {
        /// <summary>
        /// Contains list of vertexes related to some vertex
        /// </summary>
        private Dictionary<T, LinkedList<T>> _graph;

        /// <summary>
        /// Creates graph with specified vertexes without edges
        /// </summary>
        /// <param name="vertexes">List of vertexes of a graph</param>
        public UndirectedGraph(IEnumerable<T> vertexes)
        {
            _graph = new Dictionary<T, LinkedList<T>>();

            foreach (var vertex in vertexes)
            {
                _graph[vertex] = new LinkedList<T>();
            }
        }

        /// <summary>
        /// Enables using of a graph as an array
        /// </summary>
        /// <param name="vertex">Vertex of a graph</param>
        /// <returns>List of the linked vertexes</returns>
        public IEnumerable<T> this[T vertex]
        {
            get
            {
                if (!_graph.ContainsKey(vertex))
                    throw new ArgumentException("Vertex is not present in graph");

                return _graph[vertex];
            }
        }

        /// <summary>
        /// Number of vertices
        /// </summary>
        public int Count => _graph.Count;

        #region Edge operations

        /// <summary>
        /// Adds an edge between two vertexes
        /// </summary>
        /// <param name="vertex1">First vertext to connect</param>
        /// <param name="vertex2">Second vertext to connect</param>
        public void AddEdge(T vertex1, T vertex2)
        {
            if (!_graph.ContainsKey(vertex1) || !_graph.ContainsKey(vertex2))
                throw new ArgumentException("Vertex is not present in graph");

            if(HasEdge(vertex1, vertex2))
                throw new ArgumentException("Edge is already exists");

            _graph[vertex1].AddLast(vertex2);
            _graph[vertex2].AddLast(vertex1);
        }

        /// <summary>
        /// Removes an edge between two vertexes
        /// </summary>
        /// <param name="vertex1">First vertext</param>
        /// <param name="vertex2">Second vertext</param>
        public void RemoveEdge(T vertex1, T vertex2)
        {
            if (!_graph.ContainsKey(vertex1) || !_graph.ContainsKey(vertex2))
                throw new ArgumentException("Vertex is not present in graph");

            _graph[vertex1].Remove(vertex2);
            _graph[vertex2].Remove(vertex1);
        }

        /// <summary>
        /// Checks whether there is an edge between vertexes
        /// </summary>
        /// <param name="vertex1">First vertext</param>
        /// <param name="vertex2">Second vertext</param>
        public bool HasEdge(T vertex1, T vertex2)
        {
            if (!_graph.ContainsKey(vertex1) || !_graph.ContainsKey(vertex2))
                throw new ArgumentException("Vertex is not present in graph");

            return _graph[vertex1].Contains(vertex2);
        }

        #endregion

        #region Vertex operations

        /// <summary>
        /// Adds new vertex to graph
        /// </summary>
        /// <param name="vertex">New vertex</param>
        public void AddVertex(T vertex)
        {
            if (_graph.ContainsKey(vertex))
                throw new ArgumentException("Vertex is already in the graph");

            _graph[vertex] = new LinkedList<T>();
        }

        /// <summary>
        /// Remove the vertex from the graph
        /// </summary>
        /// <param name="vertex">Vertex to remove</param>
        public void RemoveVertex(T vertex)
        {
            if (!_graph.ContainsKey(vertex))
                throw new ArgumentException("Vertex is not present in graph");

            // remove all links
            while (_graph[vertex].Count > 0)
            {
                this.RemoveEdge(vertex, _graph[vertex].First.Value);
            }

            // remove vertex from graph
            _graph.Remove(vertex);
        }

        /// <summary>
        /// Checks whether graph contains the vertex
        /// </summary>
        public bool HasVertex(T vertex)
        {
            return _graph.ContainsKey(vertex);
        }

        #endregion

        #region IEnumerable implementation

        /// <summary>
        /// Enables itaration by graph (e.g. foreach)
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _graph)
            {
                yield return item.Key;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
