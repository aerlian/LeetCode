using System;
namespace Main.SeventyFive.TwoPointers
{
    public class MaximumSubArraySizeN
    {
        public static void Execute()
        {
            Console.WriteLine(MaximumSubArraySizeNImpl(new[] { 2, 1, 5, 1, 3, 2 }, 3));
        }

        public static int MaximumSubArraySizeNImpl(int [] arr, int k)
        {
            var left = 0;
            var currentSum = 0;
            var maxSum = 0;

            if (arr.Length < k)
            {
                return 0;
            }

            for(var right = 0; right < arr.Length; right++)
            {
                currentSum += arr[right];

                if (right >= k - 1)
                {                    
                    maxSum = Math.Max(maxSum, currentSum);
                    currentSum -= arr[left];
                    left += 1;
                }
            }

            return maxSum;
        }
    }
}
