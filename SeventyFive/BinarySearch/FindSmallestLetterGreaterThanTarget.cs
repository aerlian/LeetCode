using System;
namespace Main.SeventyFive.BinarySearch
{
    public class FindSmallestLetterGreaterThanTarget
    {
        public static void Execute()
        {
            var data = "cfj".ToCharArray();
            //Console.WriteLine(FindSmallestLetterGreaterThanTargetImpl(data.ToCharArray(), 'a', 0, data.Length - 1) == 'c');
            //Console.WriteLine(FindSmallestLetterGreaterThanTargetImpl(data.ToCharArray(), 'c', 0, data.Length - 1) == 'f');
            Console.WriteLine(FindSmallestLetterGreaterThanTargetImpl(data, 'd', 0, data.Length - 1, data[0], int.MaxValue) == 'd');
        }

        public static char FindSmallestLetterGreaterThanTargetImpl(char[] letters, char target, int lo, int hi, int closestValue, int closestDiff)
        {
            if (lo > hi)
            {
                return letters[0];  
            }

            var mid = lo + (hi - lo) / 2;

            if (letters[mid] == target)
            {
                if (mid + 1 >= letters.Length)
                {
                    return letters[mid];
                }

                return letters[mid + 1];
            }

            if (target < letters[mid])
            {
    
                //return FindSmallestLetterGreaterThanTargetImpl(letters, target, lo, mid - 1);
            }
            else if (target > letters[mid])
            {
                //return FindSmallestLetterGreaterThanTargetImpl(letters, target, mid + 1, hi);
            }

            return letters[mid + 1];
        }
    }
}
