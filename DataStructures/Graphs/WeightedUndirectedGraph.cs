using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataStructures.Graphs.Interfaces;

namespace DataStructures.Graphs
{
    /// <summary>
    /// Undirected weighted graph structure
    /// </summary>
    /// <typeparam name="T">Vertex type</typeparam>
    public class WeightedUndirectedGraph<T> : IWeightedGraph<T>
    {
        /// <summary>
        /// Contains list of vertexes related to some vertex
        /// </summary>
        private Dictionary<T, LinkedList<WeightedEdge<T>>> _graph;

        /// <summary>
        /// Creates graph with specified vertexes without edges
        /// </summary>
        /// <param name="vertexes">List of vertexes of a graph</param>
        public WeightedUndirectedGraph(IEnumerable<T> vertexes)
        {
            _graph = new Dictionary<T, LinkedList<WeightedEdge<T>>>();

            foreach (var vertex in vertexes)
            {
                _graph[vertex] = new LinkedList<WeightedEdge<T>>();
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

                return _graph[vertex].Select(x => x.Vertex).ToArray();
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
        public void AddEdge(T vertex1, T vertex2, double weight)
        {
            if (!_graph.ContainsKey(vertex1) || !_graph.ContainsKey(vertex2))
                throw new ArgumentException("Vertex is not present in graph");

            if (HasEdge(vertex1, vertex2))
                throw new ArgumentException("Edge is already exists");

            _graph[vertex1].AddLast(new WeightedEdge<T>(vertex2, weight));
            _graph[vertex2].AddLast(new WeightedEdge<T>(vertex1, weight));
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

            _graph[vertex1].Remove(new WeightedEdge<T>(vertex2));
            _graph[vertex2].Remove(new WeightedEdge<T>(vertex1));
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

            return _graph[vertex1].Contains(new WeightedEdge<T>(vertex2));
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

            _graph[vertex] = new LinkedList<WeightedEdge<T>>();
        }

        /// <summary>
        /// Remove the vertex from the graph
        /// </summary>
        /// <param name="vertex">Vertex to remove</param>
        public void RemoveVertex(T vertex)
        {
            if (!_graph.ContainsKey(vertex))
                throw new ArgumentException("Vertex is not present in graph");

            // remove all links, because graph is undirected
            while (_graph[vertex].Count > 0)
            {
                this.RemoveEdge(vertex, _graph[vertex].First.Value.Vertex);
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

        #region Weighted graph operations
        /// <summary>
        /// Get weight between two vertices
        /// </summary>
        /// <returns>weight</returns>
        public double GetWeight(T vertex1, T vertex2)
        {
            if (!_graph.ContainsKey(vertex1) || !_graph.ContainsKey(vertex2))
                throw new ArgumentException("Vertex is not present in graph");

            if (!HasEdge(vertex1, vertex2))
                throw new ArgumentException("The edge between vertices doesn't exist");

            return _graph[vertex1].Find(new WeightedEdge<T>(vertex2)).Value.Weight;
        }

        public void ChangeWeight(T vertex1, T vertex2, double weight)
        {
            if (!_graph.ContainsKey(vertex1) || !_graph.ContainsKey(vertex2))
                throw new ArgumentException("Vertex is not present in graph");

            if (!HasEdge(vertex1, vertex2))
                throw new ArgumentException("The edge between vertices doesn't exist");

            _graph[vertex1].Find(new WeightedEdge<T>(vertex2)).Value.Weight = weight;
            _graph[vertex2].Find(new WeightedEdge<T>(vertex1)).Value.Weight = weight;

        }
        #endregion

        #region Search

        /// <summary>
        /// Breadth-first search. Detects the distance from the node to search node
        /// </summary>
        /// <param name="startVertex">Vertex from which BFS will be done</param>
        /// <param name="searchVertex">Vertex that is searched</param>
        /// <returns>distance from the starting vertex, null - if searched vertex not found</returns>
        public int? BFS(T startVertex, T searchVertex)
        {
            var seenList = new Dictionary<T, bool>();
            var vertexQueue = new Queue<T>(); // also linked list can be used
            var levelQueue = new Queue<int>(); // distance from main node (deepness or level)
            vertexQueue.Enqueue(startVertex);
            levelQueue.Enqueue(0);

            while (vertexQueue.Count > 0)
            {
                var vertex = vertexQueue.Dequeue();
                var level = levelQueue.Dequeue();

                seenList[vertex] = true;

                if (vertex.Equals(searchVertex))
                {
                    return level;
                }

                foreach (var edge in _graph[vertex])
                {
                    var item = edge.Vertex;
                    if (seenList.ContainsKey(item))
                        continue;

                    vertexQueue.Enqueue(item);
                    levelQueue.Enqueue(level + 1);
                }
            }

            return null;
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


    public class WeightedEdge<TVertex>
    {
        public WeightedEdge(TVertex vertex) : this(vertex, 0)
        {
        }

        public WeightedEdge(TVertex vertex, double weight)
        {
            Vertex = vertex;
            Weight = weight;
        }

        public TVertex Vertex { get; }
        public double Weight { get; set; }

        /// <summary>
        /// Two weighted edges are supposed to be equal if they have the same vertex
        /// </summary>
        public override bool Equals(object obj)
        {
            var edge = obj as WeightedEdge<TVertex>;
            return edge != null &&
                   EqualityComparer<TVertex>.Default.Equals(Vertex, edge.Vertex);
        }
    }

}
