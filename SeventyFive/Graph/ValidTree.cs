using System;
using System.Collections.Generic;
using Main.Common;

namespace Main.SeventyFive.Graph
{
    public class ValidTree
    {
        public static void Execute()
        {
            //var edges = Arrays.CreateFrom("[[0,1],[1,2],[2,3],[1,3],[1,4]]");
            var edges = Arrays.CreateFrom("[[0,1],[0,2],[0,3],[1,4]]");
            Console.WriteLine(ValidTreeImpl(5, edges));
        }

        private static void AddEdge(int[] edge, Dictionary<int, List<int>> graph)
        {
            List<int> l;
            if (!graph.ContainsKey(edge[0]))
            {
                l = new List<int>();
                graph.Add(edge[0], l);
            }
            else
            {
                l = graph[edge[0]];
            }

            l.Add(edge[1]);
        }

        public static bool ValidTreeImpl(int n, int[][] edges)
        {
            var graph = new Dictionary<int, List<int>>();

            foreach (var e in edges)
            {
                AddEdge(e, graph);
                AddEdge(new int[] { e[1], e[0] }, graph);
            }

            var visited = new HashSet<int>();

            return dfs(0, graph, visited, int.MinValue) && n == visited.Count;
        }

        public static bool dfs(int n, Dictionary<int, List<int>> graph, ISet<int> visited, int prior)
        {
            if (visited.Contains(n))
            {
                return false;
            }

            visited.Add(n);

            if (graph.ContainsKey(n))
            {
                foreach (var e in graph[n])
                {
                    if (e == prior)
                    {
                        continue;
                    }
                    if (!dfs(e, graph, visited, n))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
