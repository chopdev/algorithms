using DataStructures.Graphs.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Graphs
{
    public static class BreadthFirstSearcher<T>
    {
        #region Iterative approach
        /// <summary>
        /// Breadth-first search. Detects the distance from the node to search node
        /// </summary>
        /// <param name="startVertex">Vertex from which BFS will be done</param>
        /// <param name="searchVertex">Vertex that is searched</param>
        /// <returns>distance from the starting vertex, null - if searched vertex not found</returns>
        public static int? BFS(IGraph<T> graph, T startVertex, T searchVertex)
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

                foreach (var item in graph[vertex])
                {
                    if (seenList.ContainsKey(item))
                        continue;

                    vertexQueue.Enqueue(item);
                    levelQueue.Enqueue(level + 1);
                }
            }

            return null;
        }
        #endregion

        #region Recursive approach
        /// <summary>
        /// Breadth-first search recursive. Detects the distance from the node to search node
        /// </summary>
        /// <param name="startVertex">Vertex from which BFS will be done</param>
        /// <param name="searchVertex">Vertex that is searched</param>
        /// <returns>distance from the starting vertex, null - if searched vertex not found</returns>
        public static int? BfsRecursive(IGraph<T> graph, T startVertex, T searchVertex)
        {
            var vertexQueue = new Queue<T>(); // also linked list can be used
            var levelQueue = new Queue<int>(); // distance from main node (deepness or level)
            levelQueue.Enqueue(0);

            var seenList = new Dictionary<T, bool>();
            return BfsRecursiveInternal(graph, startVertex, searchVertex, vertexQueue, levelQueue, seenList);
        }

        private static int? BfsRecursiveInternal(IGraph<T> graph, T currentVertex, T searchVertex, Queue<T> queue, Queue<int> levelQueue, IDictionary<T, bool> seenList)
        {
            int level = levelQueue.Dequeue();
            if (currentVertex.Equals(searchVertex))
                return level;

            seenList[currentVertex] = true;
            level++;
            foreach (var vertex in graph[currentVertex])
            {
                if (seenList.ContainsKey(vertex))
                    continue;

                queue.Enqueue(vertex);
                levelQueue.Enqueue(level);
            }

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                return BfsRecursiveInternal(graph, vertex, searchVertex, queue, levelQueue, seenList);
            }
            return null;
        }
        #endregion
    }
}
