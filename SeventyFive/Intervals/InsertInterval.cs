using System;
using System.Collections.Generic;
using System.Linq;
using Main.Common;

namespace Main.SeventyFive.MergeIntervals
{
    public class InsertInterval
    {
        public static void Execute()
        {
            //var intervals = Interval.FromArray(new int[][] { new int[] { 1, 3 }, new int[] { 5, 7 }, new int[] { 8, 12 } });
            //var output = InsertIntervalImpl(intervals, new Interval(4, 6));

            //var intervals = Interval.FromArray(new int[][] { new int[] { 1, 3 }, new int[] { 5, 7 }, new int[] { 8, 12 } });
            //var output = InsertIntervalImpl(intervals, new Interval(4, 10));

            var intervals = Interval.FromArray(new int[][] { new int[] { 2, 3 }, new int[] { 5, 7 }});
            var output = InsertIntervalImpl(intervals, new Interval(1, 4));

            Interval.DumpIntervals(output);
        }

        public static Interval [] InsertIntervalImpl(Interval [] source, Interval item)
        {
            if (source.Length <= 1)
            {
                return source;
            }

            source = source.Concat(new[] { item }).ToArray();

            Array.Sort(source, (l, r) => l.Start - r.Start);

            var stack = new Stack<Interval>();
            stack.Push(source[0]);

            for (var i = 1; i < source.Length; i++)
            {
                var current = source[i];
                var last = stack.Pop();

                if (current.Start <= last.End)
                {
                    stack.Push(new Interval(Math.Min(last.Start, current.Start), Math.Max(last.End, current.End)));
                }
                else
                {
                    stack.Push(last);
                    stack.Push(current);
                }
            }

            return stack.Reverse().ToArray();
        }
    }
}
