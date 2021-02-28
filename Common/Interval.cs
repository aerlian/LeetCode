using System;
using System.Collections.Generic;
using System.Linq;

namespace Main.Common
{
    public class Interval
    {
        public int Start;
        public int End;

        public Interval(int start, int end)
        {
            Start = start;
            End = end;
        }

        public override string ToString()
        {
            return $"{Start}:{End}";
        }

        public static void DumpIntervals(Interval[] intervals)
        {
            Console.WriteLine(string.Join(",", intervals.Select(i => i)));
        }

        public static Interval [] FromArray(int [][] source)
        {
            IEnumerable<Interval> Create()
            {
                foreach (var p in source)
                {
                    yield return new Interval(p[0], p[1]);
                }
            }

            return Create().ToArray();
        }
    }
}
