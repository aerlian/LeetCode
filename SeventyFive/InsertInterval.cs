using System;
using System.Collections.Generic;

namespace Main.SeventyFive
{
    /// <summary>
    /// https://leetcode.com/problems/insert-interval/
    /// </summary>
    public class InsertInterval
    {
        public static bool CanMerge(int[] a, int[] b)
        {            
            if (a[0] <= b[0])
            {
                return a[1] >= b[0];
            }

            return b[1] >= a[0];
        }

        public static int[] Merge(int[] a, int[] b)
        {
            return new int[] { Math.Min(a[0], b[0]), Math.Max(a[1], b[1]) };
        }

        public static void Execute()
        {
            var result = InsertIntervalImpl2(new int[][] {new int[] { 1, 2 }, new int[] { 3, 5 }, new int []{ 6, 7 }, new int []{ 8, 10 }, new int []{ 12, 16 } }, new int[] { 4, 8 });

            foreach(var arr in result)
            {
                Console.WriteLine(string.Join(',', arr));
            }
        }

        public static bool IsLessThan(int [] a, int[] b)
        {
            return a[1] < b[0];
        }

        public static bool IsGreaterThan(int [] a, int [] b)
        {
            return a[1] > b[0];
        }

        public static int[][] InsertIntervalImpl2(int[][] intervals, int[] newInterval)
        {
            var output = new List<int[]>();
            output.Add(newInterval);

            for (var i = 0; i < intervals.Length; i++)
            {
                var current = intervals[i];
                var tmp = output[output.Count - 1];
                if (CanMerge(current, tmp))
                {
                    var merged = Merge(current, tmp);
                    output[output.Count - 1] = merged;
                }
                else if (IsLessThan(current, tmp))
                {
                    output[output.Count - 1] = current;
                    output.Add(tmp);
                }
                else
                {
                    output[output.Count - 1] = tmp;
                    output.Add(current);
                }
            }

            return output.ToArray();
        }
    }
}
