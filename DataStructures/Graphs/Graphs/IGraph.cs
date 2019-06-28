using System;
using System.Collections.Generic;

namespace DataStructures.Graphs
{
    public interface IGraph<T> : IEnumerable<T> 
    {
        /// <summary>
        /// List of the linked vertices
        /// </summary>
        /// <param name="vertex">Vertex of a graph</param>
        IEnumerable<T> GetAdjacentVertices(T vertex);
        /// <summary>
        /// Number of vertices
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Checks whether graph contains the vertex
        /// </summary>
        bool HasVertex(T vertex);
        /// <summary>
        /// Checks whether there is an edge between vertexes
        /// </summary>
        /// <param name="vertex1">First vertext</param>
        /// <param name="vertex2">Second vertext</param>
        bool HasEdge(T vertex1, T vertex2);
    }

    public interface IUnweightedGraph<T> : IGraph<T>
    {
        /// <summary>
        /// Adds an edge between two vertexes
        /// </summary>
        /// <param name="vertex1">First vertext to connect</param>
        /// <param name="vertex2">Second vertext to connect</param>
        void AddEdge(T vertex1, T vertex2);
        /// <summary>
        /// Removes an edge between two vertexes
        /// </summary>
        /// <param name="vertex1">First vertext</param>
        /// <param name="vertex2">Second vertext</param>
        void RemoveEdge(T vertex1, T vertex2);
        /// <summary>
        /// Adds new vertex to graph
        /// </summary>
        /// <param name="vertex">New vertex</param>
        void AddVertex(T vertex);
        /// <summary>
        /// Remove the vertex from the graph
        /// </summary>
        /// <param name="vertex">Vertex to remove</param>
        void RemoveVertex(T vertex);
    }

    public interface IWeightedGraph<T> : IGraph<T>
    {
        /// <summary>
        /// Adds an edge between two vertexes
        /// </summary>
        /// <param name="vertex1">First vertext to connect</param>
        /// <param name="vertex2">Second vertext to connect</param>
        /// <param name="weight">Weight of an edge between vertices</param>
        WeightedEdge<T> AddEdge(T vertex1, T vertex2, double weight);
        /// <summary>
        /// Get adjacent edges of vertix
        /// </summary>
        IEnumerable<WeightedEdge<T>> GetAdjacentEdges(T vertex);
    }
}
