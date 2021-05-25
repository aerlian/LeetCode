using System;
namespace Main.SeventyFive.BinarySearch
{
    public class FindRotationPointBinarySearch
    {
        public static void Execute()
        {
            //var source = new[] { 6, 7, 8, 1, 2, 3, 4, 5 };
            var source = new[] { 3, 4, 5, 6, 7, 8, 1, 2};
            //Console.WriteLine(RotatedBinarySearchIml(source, 2, 0, source.Length - 1) == 4);
            //Console.WriteLine(RotatedBinarySearchImpl(source, 6, 0, source.Length - 1) == 0);
            Console.WriteLine(FindRotationPointBinarySearchImpl(source, 0, source.Length - 1) == 6);
        }
       
        public static int FindRotationPointBinarySearchImpl(int [] source, int lo, int hi)
        {
            while (lo < hi)
            {
                var mid = (lo + hi) / 2;
                if (source[mid] > source[hi])
                {
                    lo = mid + 1;
                }
                else
                {
                    hi = mid;
                }
            }

            return lo;
        }
    }
}
