using System;
using System.Collections.Generic;
using System.Linq;

namespace Main.Patterns.Backtracking
{
    /// <summary>
    /// https://leetcode.com/problems/combinations/
    /// </summary>
    public class Combinations
    {
        public static void Execute()
        {
            var current = new List<int>();
            var output = new List<List<int>>();

            CombinationsImpl(1, 4, 3, current, output);
            Console.WriteLine(string.Join(Environment.NewLine, output.Select(rng => string.Join(",", rng))));
        }

        public static void CombinationsImpl(int start, int n, int k, List<int> current, List<List<int>> output)
        {
            if (current.Count == k)
            {
                output.Add(new List<int>(current));
                return;
            }

            for(var i = start; i <= n; i++)
            {
                current.Add(i);
                CombinationsImpl(i + 1, n, k, current, output);
                current.RemoveAt(current.Count - 1);
            }
        }
    }
}
