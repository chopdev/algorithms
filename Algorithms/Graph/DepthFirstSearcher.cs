using System;
using System.Collections;
using System.Collections.Generic;
using DataStructures.Graphs;

namespace Algorithms.Graph
{
    /// <typeparam name="T">Graph vertex type</typeparam>
    public class DepthFirstSearcher<T> where T: IComparable<T>
    {
        #region Iterative approach
        /// <summary>
        /// Depth-first path search. Find first path between startVertex and searchVertex
        /// </summary>
        /// <param name="startVertex">Vertex from which DFS will be done</param>
        /// <param name="searchVertex">Vertex that is searched</param>
        /// <returns>path from the starting vertex to searched vertex</returns>
        public static List<T> DepthFirstSearchPath(UndirectedGraph<T> graph, T startVertex, T searchVertex) 
        {
            if (!graph.HasVertex(startVertex))
                throw new ArgumentException("Start vertex is not present in graph");

            if (!graph.HasVertex(searchVertex))
                throw new ArgumentException("Search vertex is not present in graph");

            var seenList = new Dictionary<T, bool>();
            
            var parents = new Dictionary<T, T>();
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

            var path = new List<T>();
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

        /// <summary>
        /// Depth-first search. Return sequence of vertices which DFS was processed
        /// </summary>
        /// <param name="startVertex">Vertex from which DFS will be done</param>
        /// <returns>sequence of vertices which DFS was processed</returns>
        public static List<T> DepthFirstSearch(UndirectedGraph<T> graph, T startVertex)
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
        /// Depth-first search. Return sequence of vertices which DFS was processed
        /// </summary>
        /// <param name="startVertex">Vertex from which DFS will be done</param>
        /// <returns>sequence of vertices which DFS was processed</returns>
        public static List<T> DepthFirstSearchRecursive(UndirectedGraph<T> graph, T startVertex)
        {
            var seenList = new Dictionary<T, bool>();
            var sequence = new List<T>();
            _depthFirstSearchRecursive(graph, startVertex, seenList, sequence);
            return sequence;
        }

        public static void _depthFirstSearchRecursive(UndirectedGraph<T> graph, T vertex, Dictionary<T, bool> seenList, List<T> sequence)
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
                    _depthFirstSearchRecursive(graph, item, seenList, sequence);
                }
            }
        }
        #endregion
    }
}
