using System;
using System.Collections.Generic;
using System.Linq;

namespace Main.Patterns
{
    /// <summary>
    /// https://leetcode.com/problems/find-all-duplicates-in-an-array/
    /// The trick is to:
    /// Convert the numeric value into an array index and then negate the value at that index if it's not already negated (i.e. marking that
    /// value as having been seen). Every number you see in the array, convert the value to an index and if the number at that index is negative
    /// then you found a dup
    /// </summary>
    public class FindAllDuplicatesInAnArray
    {
        public static void Execute()
        {
            var output = FindDuplicates(new int[] { 4, 3, 2, 7, 8, 2, 3, 1 });
            Console.WriteLine(output.SequenceEqual(new int[] { 2, 3 }));
        }

        public static IList<int> FindDuplicates(int[] nums)
        {
            var output = new List<int>();

            for(var i = 0; i < nums.Length; i++)
            {
                var indexToNegate = Math.Abs(nums[i]) - 1;

                if (nums[indexToNegate] < 0)
                {
                    output.Add(Math.Abs(nums[i]));
                }
                else
                {
                    nums[indexToNegate] *= -1;
                }
            }

            return output;
        }
    }
}
