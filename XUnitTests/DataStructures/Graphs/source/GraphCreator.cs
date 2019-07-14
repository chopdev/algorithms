using DataStructures.Graphs;
using System;
using System.IO;

namespace XUnitTests.DataStructures.Graphs.source
{
    public static class GraphCreator
    {
        public static IWeightedGraph<int> GetWeightedGraph(string textFileName = "tinyEWG.txt")
        {
            var textFilePath = Path.Combine(Environment.CurrentDirectory, @"DataStructures/Graphs/source", textFileName);
            var graph = new WeightedUndirectedGraph<int>();
            using (StreamReader file = new StreamReader(textFilePath))
            {
                string row = null;
                while ((row = file.ReadLine()) != null)
                {
                    var cols = row.Split(" ");
                    if (cols.Length < 3) continue;

                    graph.AddEdge(int.Parse(cols[0]), int.Parse(cols[1]), double.Parse(cols[2]));
                }
            }
            return graph;
        }
    }
}
