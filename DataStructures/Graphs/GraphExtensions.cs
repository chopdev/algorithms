using DataStructures.Graphs.Interfaces;
using System;
using System.Collections.Generic;

namespace DataStructures.Graphs
{
    public static class GraphExtensions
    {
        public static int? BFS<T>(this IGraph<T> graph, T startVertex, T searchVertex)
        {
            return BreadthFirstSearcher<T>.BfsRecursive(graph, startVertex, searchVertex);
        }

        public static IList<T> DFS<T>(this IGraph<T> graph, T startVertex, T searchVertex) where T : IComparable<T>
        {
            return DepthFirstSearcher<T>.DepthFirstSearchRecursivePath(graph, startVertex, searchVertex);
        }
    }
}
