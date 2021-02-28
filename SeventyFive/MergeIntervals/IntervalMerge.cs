using System;
using System.Collections.Generic;
using Main.Common;

namespace Main.SeventyFive.MergeIntervals
{
    public class IntervalMerge
    {
        public static void Execute()
        {
            //Interval [] input = new []
            //{
            //    new Interval(1, 4),
            //    new Interval(2, 5),
            //    new Interval(7, 9)
            //};

            Interval[] input = new[]
            {
                new Interval(1, 4),
                new Interval(2, 6),
                new Interval(3, 5)
            };

            Interval.DumpIntervals(IntervalMergeImpl(input));
        }

        public static Interval [] IntervalMergeImpl(Interval [] input)
        {
            if (input.Length <= 1)
            {
                return input;
            }

            Array.Sort(input, (l, r) => l.Start - r.Start);

            var output = new Stack<Interval>(new[] { input[0]});

            for(var i = 1; i < input.Length; i++)
            {
                var current = input[i];
                var last = output.Pop();

                if (current.Start <= last.End)
                {
                    output.Push(new Interval(Math.Min(current.Start, last.Start), Math.Max(current.End, last.End)));
                }
                else
                {
                    output.Push(last);
                    output.Push(current);                    
                }
            }

            return output.ToArray();
        }
    }
}
