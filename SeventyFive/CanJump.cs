using System;
using System.Collections.Generic;

namespace Main.SeventyFive
{
    public class CanJump
    {
        public static void Execute()
        {            
            //Console.WriteLine(CanJumpImpl(new int[] { 2, 3, 1, 1, 4 }, 0, new HashSet<int>()));
            //Console.WriteLine(CanJumpImpl(new int[] { 3, 2, 1, 0, 4 }, 0, new HashSet<int>()));
            Console.WriteLine(CanJumpImplLinear(new int[] { 2, 3, 1, 1, 4 }));
        }
        public static bool CanJumpImplLinear(int[] nums)
        {
            var target = nums.Length - 1;
            
            for(var i = target; i >= 0; i--)
            {
                if (i + nums[i] >= target)
                {
                    target = i;
                }
            }

            return target == 0;
        }

        public static bool CanJumpImpl(int[] nums, int index, ISet<int> nogoSet)
        {
            if (nogoSet.Contains(index))
            {
                return false;
            }

            if (index >= nums.Length)
            {
                return false;
            }

            if (index == nums.Length - 1)
            {
                return true;
            }

            for (var jump = 1; jump <= nums[index]; jump++)
            {
                var nextIndex = index + jump;
                var isJump = CanJumpImpl(nums, nextIndex, nogoSet);
                if (isJump)
                {
                    return true;
                }

                nogoSet.Add(index);
            }

            return false;
        }
    }
}
