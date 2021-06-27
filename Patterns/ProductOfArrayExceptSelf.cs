using System;
using System.Linq;

namespace Main.Patterns
{
    /// <summary>
    /// https://leetcode.com/problems/product-of-array-except-self/
    /// </summary>
    public class ProductOfArrayExceptSelf
    {
        public static void Execute()
        {
            var input = new int[] { 1, 2, 3, 4 };
            var result = ProductExceptSelfImpl(input);
            Console.WriteLine(result.SequenceEqual(new int[] {24, 12, 8, 6 }));
        }

        public static int[] ProductExceptSelfImpl(int[] nums)
        {
            var prefix = new int[nums.Length];
            var postFix = new int[nums.Length];

            var currProduct = 1;
            for (var i = 0; i < nums.Length; i++)
            {
                currProduct *= nums[i];
                prefix[i] = currProduct;
            }

            currProduct = 1;
            for (var i = nums.Length - 1; i >= 0; i--)
            {
                currProduct *= nums[i];
                postFix[i] = currProduct;
            }

            var output = new int[nums.Length];
            for (var i = 0; i < nums.Length; i++)
            {
                var firstProduct = i - 1 >= 0 ? prefix[i - 1] : 1;
                var secondProduct = i + 1 <= nums.Length - 1 ? postFix[i + 1] : 1;
                output[i] = firstProduct * secondProduct;
            }

            return output;
        }
    }
}
