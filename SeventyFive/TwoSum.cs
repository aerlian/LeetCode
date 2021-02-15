using System;
using System.Linq;
using Main.Common;

namespace Main.DynamicProgramming
{
    /// <summary>
    /// https://leetcode.com/problems/two-sum/
    /// </summary>
    public class TwoSum
    {
        public static void Execute()
        {
            var arr = new[] { 2, 5, 5, 11 };
            var target = 10;

            Console.WriteLine(string.Join(",", TwoSumImpl(arr, target)));
        }

        public static int [] TwoSumImpl(int [] arr, int target)
        {
            for(var i = 0; i < arr.Length; i++)
            {
                for(var j = 0; j < arr.Length; j++)
                {
                    if (j == 0)
                    {
                        continue;
                    }

                    if (arr[i] + arr[j] == target)
                    {
                        return new[] { i, j };
                    }
                }
            }

            return Array.Empty<int>();            
        }
    }
}
