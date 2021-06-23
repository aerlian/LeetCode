using System;
using System.Linq;
using Main.Common;

namespace Main.SeventyFive.MergeIntervals
{
    /// <summary>
    /// https://leetcode.com/problems/non-overlapping-intervals/
    ///
    /// The strategy here is to:
    /// 1. Sort the list by left side
    /// 2. Loop over list from element index 1 (variable called prior is set to element with index 0 at start)
    /// 3. If current item overlaps with prior then throw one away - determine which one to throw away by picking the one
    /// that has the lowest right hand edge value and making that the new prior
    /// 4. If there is no overlap then make the current item the new prior
    /// </summary>
    public class EraseOverlapIntervals
    {
        public static void Execute()
        {
            var intervals1 = new int[][] {
                new int[] {1,2},
                new int[] {2,3},
                new int[] {3,4},
                new int[] {1,3}
            };

            var intervals2 = new int[][] {
                new int[] {1,2},
                new int[] {1,2},
                new int[] {1,2},
            };

            var intervals = intervals2;

            Console.WriteLine(intervals.Dump());
            Console.WriteLine(EraseOverlapIntervalsImpl(intervals));
        }

        public static int EraseOverlapIntervalsImpl(int[][] intervals)
        {
            Array.Sort(intervals, (l, r) => l[0].CompareTo(r[0]));
            Console.WriteLine(intervals.Dump());

            var prior = intervals[0];
            var count = 0;

            for (var i = 1; i < intervals.Length; i++)
            {
                Console.WriteLine($"intervals[i]: {intervals[i].Dump()}");
                Console.WriteLine($"prior: {prior.Dump()}");

                // if prior overlaps current
                if (prior[1] > intervals[i][0])
                {
                    count += 1;
                    //pick the one that has the least right hand edge
                    prior = prior[1] < intervals[i][1] ? prior : intervals[i];
                }
                else
                {
                    prior = intervals[i];
                }
            }

            return count;
        }
    }
}
