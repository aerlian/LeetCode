using System;
namespace Main.SeventyFive.TwoPointers
{
    //https://leetcode.com/problems/maximum-subarray/
    public class MaxSubArray
    {
        public static void  Execute()
        {
            Console.WriteLine(MaxSubArrayImpl(new[] { -2, -3, -5 }));
        }

        public static int MaxSubArrayImpl(int [] arr)
        {
            var maxSub = arr[0];
            var currentSum = 0;

            foreach(var n in arr)
            {
                if (currentSum < 0)
                {
                    currentSum = 0;
                }

                currentSum += n;
                maxSub = Math.Max(maxSub, currentSum);
            }

            return maxSub;
        }
    }
}
