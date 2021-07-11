using System;
using System.Linq;
using Main.Common;

namespace Main.SeventyFive.Graph
{
    /// <summary>
    /// https://leetcode.com/problems/number-of-connected-components-in-an-undirected-graph/
    /// </summary>
    public class NumberOfConnectedComponentsInAnUndirectedGraph
    {
        public static void Execute()
        {
            var edges = Arrays.CreateFrom("[[0,1],[1,2],[2,3],[3,4]]", p => int.Parse(p));
            Console.WriteLine(NumberOfConnectedComponentsInAnUndirectedGraphImpl(5, edges));
            //var edges = Arrays.CreateFrom("[[0,1],[1,2],[3,4]]", p => int.Parse(p));
            //Console.WriteLine(NumberOfConnectedComponentsInAnUndirectedGraphImpl(5, edges));
        }

        public static int NumberOfConnectedComponentsInAnUndirectedGraphImpl(int n, int[][] edges)
        {
            var parent = Enumerable.Range(0, n).ToArray();
            var rank = Enumerable.Repeat(1, n).ToArray();

            var result = n;
            foreach (var e in edges)
            {
                var e1 = e[0];
                var e2 = e[1];
                result -= union(e1, e2);
            }

            return result;

            int find(int n1)
            {
                var result = n1;

                while (result != parent[result])
                {
                    parent[result] = parent[parent[result]];
                    result = parent[result];
                }

                return result;
            }

            int union(int n1, int n2)
            {
                var p1 = find(n1);
                var p2 = find(n2);

                if (p1 == p2)
                {
                    return 0;
                }

                if (rank[p2] > rank[p1])
                {
                    parent[p1] = p2;
                    rank[p2] += rank[p1];
                }
                else
                {
                    parent[p2] = p1;
                    rank[p1] += rank[p2];
                }

                return 1;
            }
        }
    }
}
