﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Main.Patterns.Backtracking
{
    /// <summary>
    /// https://leetcode.com/problems/combination-sum/
    /// </summary>
    public class CombinationSum
    {
        public static void Execute()
        {
            IList<IList<int>> output = new List<IList<int>>();
            CombinationSumImpl(new int[] { 2, 3, 5 }, 0, 8, new List<int>(), output);
            Console.WriteLine(string.Join(Environment.NewLine, output.Select(rng => string.Join(",", rng))));
        }

        public static void CombinationSumImpl(int[] candidates, int offset, int target, IList<int> candidateList, IList<IList<int>> output)
        {
            if (target < 0)
            {
                return;
            }

            if (target == 0)
            {
                output.Add(new List<int>(candidateList));
                return;
            }

            for(var i = offset; i < candidates.Length; i++)
            {
                var current = candidates[i];
                candidateList.Add(current);
                CombinationSumImpl(candidates, i, target - current, candidateList, output);
                candidateList.RemoveAt(candidateList.Count - 1);
            }
        }
    }
}
