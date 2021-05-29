using System;
using System.Collections.Generic;

namespace Main.SeventyFive.MergeIntervals
{
    /// <summary>
    /// https://leetcode.com/problems/merge-intervals/
    /// </summary>
    public class MergeIntervalsLC
    {
        public static void Execute()
        {
            var test = new int[][] { new int[] { 1, 3 }, new int[] { 2, 6 }, new int[] { 8, 10 }, new int[] { 15, 18 } };
            var result = MergeImpl(test);

            foreach (var arr in result)
            {
                Console.WriteLine(string.Join(',', arr));
            }
        }

        public static bool CanMerge(int[] first, int[] second)
        {
            return first[1] >= second[0];
        }

        public static int[] Merge(int[] first, int[] second)
        {
            var start = Math.Min(first[0], second[0]);
            var end = Math.Max(first[1], second[1]);
            return new int[] { start, end };
        }

        public static int[][] MergeImpl(int[][] intervals)
        {
            Array.Sort(intervals, (int[] l, int[] r) => l[0] - r[0]);
            var output = new List<int[]>();

            output.Add(intervals[0]);

            for (var i = 1; i < intervals.Length; i++)
            {
                var current = intervals[i];
                var last = output[output.Count - 1];
                if (CanMerge(last, current))
                {
                    current = Merge(last, current);
                    output[output.Count - 1] = current;
                }
                else
                {
                    output.Add(current);
                }
            }

            return output.ToArray();
        }
    }
}
