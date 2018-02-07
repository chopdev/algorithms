﻿using System;
using System.Collections.Generic;

namespace GraphExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            UndirectedGraph<int> graph = new UndirectedGraph<int>(new [] { 1, 2, 3, 4, 0});

            graph.AddEdge(0, 1);
            graph.AddEdge(0, 4);
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(1, 4);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 4);

            var t = graph[0];

            graph.AddVertex(5);
            graph.AddEdge(5, 0);

            var g = graph[0];

            foreach (var vertex in graph)
            {
                Console.WriteLine(vertex);
            }

            Console.Read();
        }
    }
}
