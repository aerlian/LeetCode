using System;
namespace Main.SeventyFive.Intervals
{
    /// <summary>
    /// https://leetcode.com/problems/meeting-rooms/
    /// </summary>
    public class CanAttendMeetings
    {
        public static void Execute()
        {
            //Console.WriteLine(CanAttendMeetingsImpl(new int[][] {
            //    new int [] {0, 30 },
            //    new int [] {5, 10 },
            //    new int [] {15, 20 }
            //}));
            Console.WriteLine(CanAttendMeetingsImpl(new int[][] {
                new int [] {7, 10 },
                new int [] {2, 4 },
            }));
        }

        public static bool CanAttendMeetingsImpl(int[][] intervals)
        {
            if (intervals.Length <= 0)
            {
                return true;
            }

            Array.Sort(intervals, (a, b) => a[0] - b[0]);

            var isCanMeet = true;

            var i = 0;
            while (isCanMeet)
            {
                if (i + 1 > intervals.Length - 1)
                {
                    break;
                }

                var curr = intervals[i];
                var next = intervals[i + 1];

                if (curr[1] > next[0])
                {
                    isCanMeet = false;
                    break;
                }

                i += 1;
            }

            return isCanMeet;
        }
    }
}
