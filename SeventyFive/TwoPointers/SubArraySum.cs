using System;
namespace Main.SeventyFive.TwoPointers
{
    public class SubArraySum
    {
        public static void Execute()
        {
            Console.WriteLine(SubArraySumImpl(new int[] { 2, 1, 5, 2, 8 }, 7));
        }

        public static int SubArraySumImpl(int [] arr, int target)
        {
            var l = 0;
            var r = 0;
            var sum = 0;
            var winLen = int.MaxValue;

            while(r < arr.Length)
            {
                sum += arr[r];

                while(sum >= target)
                {
                    winLen = Math.Min(winLen, r - l + 1);
                    sum -= arr[l];
                    l += 1;                                  
                }

                r += 1;
            }

            return winLen;
        }
    }
}
