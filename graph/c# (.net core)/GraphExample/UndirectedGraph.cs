using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GraphExample
{
    public class UndirectedGraph<T> : IEnumerable<T>
    {
        private Dictionary<T, LinkedList<T>> _graph;

        public UndirectedGraph(IEnumerable<T> vertexes)
        {
            _graph = new Dictionary<T, LinkedList<T>>();

            foreach (var vertex in vertexes)
            {
                _graph[vertex] = new LinkedList<T>();
            }
        }

        public LinkedList<T> this[T vertex]
        {
            get
            {
                if (!_graph.ContainsKey(vertex))
                    throw new ArgumentException("Vertex is not present in graph");

                return _graph[vertex];
            }
        }

        public void AddEdge(T vertex1, T vertex2)
        {
            if (!_graph.ContainsKey(vertex1) || !_graph.ContainsKey(vertex2))
                throw new ArgumentException("Vertex is not present in graph");

            _graph[vertex1].AddLast(vertex2);
            _graph[vertex2].AddLast(vertex1);
        }

        public void AddVertex(T vertex)
        {
            if (_graph.ContainsKey(vertex))
                throw new ArgumentException("Vertex is not present in graph");

            _graph[vertex] = new LinkedList<T>();
        }

        public bool VertexExists(T vertex)
        {
            return _graph.ContainsKey(vertex);
        }

        #region IEnumerable implementation

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
