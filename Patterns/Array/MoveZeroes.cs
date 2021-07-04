using System;
namespace Main.Patterns.Array
{
    /// <summary>
    /// https://leetcode.com/problems/move-zeroes/
    /// </summary>
    public class MoveZeroes
    {
        public static void Execute()
        {
            char a = '1';
            int b = '1' - '0';


            var input = new int[] { 0, 1, 0, 3, 12 };
            MoveZeroesImpl(input);
            Console.WriteLine(string.Join(", ", input));
        }

        public static void MoveZeroesImpl(int[] nums)
        {
            var priorNonZeroOffset = 0;

            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    continue;
                }

                var tmp = nums[priorNonZeroOffset];
                nums[priorNonZeroOffset] = nums[i];
                nums[i] = tmp;
                priorNonZeroOffset += 1;
            }
        }
    }
}
