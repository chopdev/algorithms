using System;
using System.Collections.Generic;
using System.Linq;
using DataStructures.Graphs.Interfaces;

namespace DataStructures.Graphs
{
    /// <typeparam name="T">Graph vertex type</typeparam>
    public class DepthFirstSearcher<T> where T: IComparable<T>
    {
        #region Iterative approach
        /// <summary>
        /// Depth-first search. Return sequence of vertices which DFS was processed
        /// </summary>
        /// <param name="startVertex">Vertex from which DFS will be done</param>
        /// <returns>sequence of vertices which DFS was processed</returns>
        public static List<T> DepthFirstSearch(IGraph<T> graph, T startVertex)
        {
            var seenList = new Dictionary<T, bool>();

            var sequence = new List<T>();
            var s = new Stack<T>();
            s.Push(startVertex);
            seenList[startVertex] = true;
            while (s.Count != 0)
            {
                var v = s.Pop();

                sequence.Add(v);
               
                foreach (var item in graph[v])
                {                  
                    if (!seenList.ContainsKey(item))
                    {
                        s.Push(item);
                        seenList[item] = true;
                    }
                }
                
            }

            return sequence;
        }
        #endregion

        #region Recursive approach
        /// <summary>
        /// Depth-first search
        /// </summary>
        /// <param name="startVertex">Vertex from which DFS will be done</param>
        /// <returns>sequence of vertices processed by DFS</returns>
        public static IList<T> DepthFirstSearchRecursive(IGraph<T> graph, T startVertex)
        {
            var seenList = new Dictionary<T, bool>(graph.Count);
            var sequence = new List<T>(graph.Count);
            DepthFirstSearchRecursiveInternal(graph, startVertex, seenList, sequence);
            return sequence;
        }

        private static void DepthFirstSearchRecursiveInternal(IGraph<T> graph, T vertex, Dictionary<T, bool> seenList, IList<T> sequence)
        {
            
            if (seenList.ContainsKey(vertex))
            {
                return;
            }

            sequence.Add(vertex);
            seenList[vertex] = true;
            
            foreach (var item in graph[vertex])
            {
                if (!seenList.ContainsKey(item))
                {
                    DepthFirstSearchRecursiveInternal(graph, item, seenList, sequence);
                }
            }
        }
        #endregion

        #region Finding path iterative
        /// <summary>
        /// Depth-first path search. Find first path between startVertex and searchVertex
        /// </summary>
        /// <param name="startVertex">Vertex from which DFS will be done</param>
        /// <param name="searchVertex">Vertex that is searched</param>
        /// <returns>path from the starting vertex to searched vertex</returns>
        public static IList<T> DepthFirstSearchPath(IGraph<T> graph, T startVertex, T searchVertex)
        {
            if (!graph.HasVertex(startVertex))
                throw new ArgumentException("Start vertex is not present in graph");

            if (!graph.HasVertex(searchVertex))
                throw new ArgumentException("Search vertex is not present in graph");

            var seenList = new Dictionary<T, bool>(graph.Count);

            var parents = new Dictionary<T, T>(graph.Count);
            var s = new Stack<T>();
            s.Push(startVertex);
            seenList[startVertex] = true;
            while (s.Count != 0)
            {
                var v = s.Pop();

                foreach (var item in graph[v])
                {

                    if (!seenList.ContainsKey(item))
                    {
                        parents[item] = v;
                        s.Push(item);
                        seenList[item] = true;
                    }
                }
            }

            var path = new List<T>(graph.Count);
            var currentVertex = searchVertex;
            path.Add(currentVertex);
            while (currentVertex.CompareTo(startVertex) != 0)
            {
                if (!parents.ContainsKey(currentVertex))
                {
                    return path;
                }
                currentVertex = parents[currentVertex];
                path.Add(currentVertex);
            }
            path.Reverse();
            return path;
        }
        #endregion

        #region Finding path recursively
        /// <summary>
        /// Depth-first search. Find first path between startVertex and searchVertex
        /// </summary>
        /// <param name="startVertex">Vertex from which DFS will be done</param>
        /// <returns>first path between startVertex and searchVertex</returns>
        public static IList<T> DepthFirstSearchRecursivePath(IGraph<T> graph, T startVertex, T searchVertex)
        {
            var seenList = new Dictionary<T, bool>(graph.Count);
            var path = new Stack<T>(graph.Count);
            DepthFirstSearchRecursivePathInternal(graph, startVertex, searchVertex, seenList, path);
            return path.Reverse().ToArray();
        }

        private static bool DepthFirstSearchRecursivePathInternal(IGraph<T> graph, T vertex, T searchVertex, Dictionary<T, bool> seenList, Stack<T> path)
        {
            seenList[vertex] = true; // mark vertex as seen
            path.Push(vertex); // add vertex to path

            if (vertex.CompareTo(searchVertex) == 0) 
                return true; // path is found

            foreach (var item in graph[vertex])
            {
                if (seenList.ContainsKey(item))
                    continue;

                bool found = DepthFirstSearchRecursivePathInternal(graph, item, searchVertex, seenList, path);

                if (!found) 
                    path.Pop(); // if path not found, remove last vertex from the path
                else
                    return true;
            }

            return false; // nowhere to go, path not found
        }
        #endregion
    }
}
