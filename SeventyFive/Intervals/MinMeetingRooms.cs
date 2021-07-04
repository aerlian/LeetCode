using System;
using System.Linq;

namespace Main.SeventyFive.Intervals
{
    /// <summary>
    /// https://leetcode.com/problems/meeting-rooms-ii/
    /// </summary>
    public class MinMeetingRooms
    {
        public static void Execute()
        {
            Console.WriteLine(MinMeetingRoomsImpl(new int[][] {
                new int [] {0, 30 },
                new int [] {5, 10 },
                new int [] {15, 20 }
            }));
        }

        public static int MinMeetingRoomsImpl(int[][] intervals)
        {
            if (intervals.Length == 0)
            {
                return 0;
            }

            var meetingStartTimes = intervals.Select(i => i[0]).OrderBy(i => i).ToArray();
            var meetingEndTimes = intervals.Select(i => i[1]).OrderBy(i => i).ToArray();

            var start = 0;
            var end = 0;
            var count = 0;
            var maxMeetingCount = 0;

            while (start < meetingStartTimes.Length)
            {
                if (meetingStartTimes[start] < meetingEndTimes[end])
                {
                    count += 1;
                    maxMeetingCount = Math.Max(maxMeetingCount, count);
                    start += 1;
                }
                else
                {
                    count -= 1;
                    end += 1;
                }
            }

            return maxMeetingCount;
        }
    }
}
