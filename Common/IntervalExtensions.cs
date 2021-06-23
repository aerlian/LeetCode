using System;
using System.Linq;

namespace Main.Common
{
    public static class IntervalExtensions
    {
        public static string Dump(this int [][] intervals)
        {
            return string.Join(",", intervals.Select(i => Dump(i)));
        }

        public static string Dump(this int[] interval)
        {
            return $"({interval[0]}:{interval[1]})";
        }
    }
}
