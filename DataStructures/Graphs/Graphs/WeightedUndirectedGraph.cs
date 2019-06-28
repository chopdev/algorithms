using System;
using System.Collections;
using System.Collections.Generic;

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
        private Dictionary<T, LinkedList<WeightedEdge<T>>> _graph = new Dictionary<T, LinkedList<WeightedEdge<T>>>();

        public WeightedUndirectedGraph() {}

        /// <summary>
        /// Creates graph with specified vertexes without edges
        /// </summary>
        /// <param name="vertexes">List of vertexes of a graph</param>
        public WeightedUndirectedGraph(IEnumerable<T> vertexes)
        {
            foreach (var vertex in vertexes)
            {
                _graph[vertex] = new LinkedList<WeightedEdge<T>>();
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
        public WeightedEdge<T> AddEdge(T vertex1, T vertex2, double weight)
        {
            if (!_graph.ContainsKey(vertex1))
                _graph[vertex1] = new LinkedList<WeightedEdge<T>>();
            if(!_graph.ContainsKey(vertex2))
                _graph[vertex2] = new LinkedList<WeightedEdge<T>>();

            var edge = new WeightedEdge<T>(vertex1, vertex2, weight);
            _graph[vertex1].AddLast(edge);
            _graph[vertex2].AddLast(edge);
            return edge;
        }

        /// <summary>
        /// Checks whether there is an edge between vertexes
        /// </summary>
        /// <param name="vertex1">First vertext</param>
        /// <param name="vertex2">Second vertext</param>
        public bool HasEdge(T vertex1, T vertex2)
        {
            if (!_graph.ContainsKey(vertex1) || !_graph.ContainsKey(vertex2))
                return false;

            foreach (var edge in _graph[vertex1])
            {
                if (edge.GetOther(vertex1).Equals(vertex2))
                    return true;
            }

            return false;
        }

        #endregion

        #region Vertex operations

        /// <summary>
        /// Checks whether graph contains the vertex
        /// </summary>
        public bool HasVertex(T vertex)
        {
            return _graph.ContainsKey(vertex);
        }

        public IEnumerable<WeightedEdge<T>> GetAdjacentEdges(T vertex)
        {
            return _graph[vertex];
        }

        public IEnumerable<T> GetAdjacentVertices(T vertex)
        {
            var vertices = new HashSet<T>();
            foreach (var edge in _graph[vertex])
            {
                vertices.Add(edge.GetOther(vertex));
            }
            return vertices;
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
        public WeightedEdge(TVertex vertexA, TVertex vertexB) : this(vertexA, vertexB, 0)
        {
        }

        public WeightedEdge(TVertex vertexA, TVertex vertexB, double weight)
        {
            VertexA = vertexA;
            VertexB = vertexB;
            Weight = weight;
        }

        public TVertex VertexA { get; }
        public TVertex VertexB { get; }
        public double Weight { get; set; }

        public TVertex GetEither()
        {
            return VertexA;
        }

        public TVertex GetOther(TVertex vertex)
        {
            if (vertex == null) throw new ArgumentException("Invalid param vertex");
            if (vertex.Equals(VertexA)) return VertexB;
            if (vertex.Equals(VertexB)) return VertexA;
            throw new ArgumentException("Vertex is not belonging to edge");
        }
    }

}
