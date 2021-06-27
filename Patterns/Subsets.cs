using System;
using System.Collections.Generic;
using System.Linq;

namespace Main.Patterns
{
    /// <summary>
    /// https://leetcode.com/problems/subsets/
    /// To produce the next set:
    ///     - produce the prior list of sets
    ///     - combine the current value into each set of said list as a new list
    ///     - union the prior and current
    /// </summary>
    public class Subsets
    {
        public static void Execute()
        {
            var nums = new int[] { 1, 2, 3 };
            var result = SubsetsImpl(new HashSet<int>(nums));
            var output = result.Select(r => $"[{string.Join(",", r)}]");

            Console.WriteLine(string.Join(",", output));
        }

        public static ISet<ISet<int>> SubsetsImpl(ISet<int> numSet)
        {
            if (numSet.Count == 0)
            {
                return new HashSet<ISet<int>>() { new HashSet<int>() };
            }

            var firstElem = numSet.First();
            numSet.Remove(firstElem);
            var priorSubset = SubsetsImpl(numSet);
            var nextSet = priorSubset.Select(s => new HashSet<int>(s) { firstElem });
            var output = new HashSet<ISet<int>>(nextSet.Union(priorSubset));
            return output;
        }
    }
}
