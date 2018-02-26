using System;
using System.Collections.Generic;

namespace DataStructures.Graphs.Interfaces
{
    public interface IGraphBase<T> : IEnumerable<T>
    {
        /// <summary>
        /// Enables using of a graph as an array
        /// </summary>
        /// <param name="vertex">Vertex of a graph</param>
        /// <returns>List of the linked vertices</returns>
        IEnumerable<T> this[T vertex] { get; }
        /// <summary>
        /// Number of vertices
        /// </summary>
        int Count { get; }
    }

    public interface IChangebleGraph<T>
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
        /// Checks whether there is an edge between vertexes
        /// </summary>
        /// <param name="vertex1">First vertext</param>
        /// <param name="vertex2">Second vertext</param>
        bool HasEdge(T vertex1, T vertex2);
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
        /// <summary>
        /// Checks whether graph contains the vertex
        /// </summary>
        bool HasVertex(T vertex);
    }

    public interface IGraph<T> : IGraphBase<T>, IChangebleGraph<T> {}
}
