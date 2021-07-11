using System;
using System.Collections.Generic;
using Main.Common;

namespace Main.SeventyFive
{
    public class SpiralOrder
    {
        public static void Execute()
        {
            var matrix = Arrays.CreateFrom("[[1,2,3,4],[5,6,7,8],[9,10,11,12]]", int.Parse);
            //var matrix = Arrays.CreateFrom("[[1, 2, 3],[4, 5, 6],[7, 8, 9]]", int.Parse);
            var list = SpiralOrderImpl(matrix);
            Console.WriteLine(string.Join(',', list));
        }

        //The trick here is to create an articial wall around the matrix and close
        //the walls in as we walk the array in each direction ensuring the walls don't ever touch
        //NB edge case is matrix of single row or single column
        public static IList<int> SpiralOrderImpl(int[][] matrix)
        {
            var right = matrix[0].Length;
            var left = 0;
            var top = 0;
            var bottom = matrix.Length;

            var output = new List<int>();

            bool IsVerticalAvailable()
            {
                return top < bottom;
            }

            bool IsHorizontalAvailable()
            {
                return left < right;
            }

            while (true)
            {
                if (!IsHorizontalAvailable())
                {
                    break;
                }

                //go left to right
                for (var c = left; c < right; c++)
                {
                    output.Add(matrix[top][c]);
                }
                top += 1;

                if (!IsVerticalAvailable())
                {
                    break;
                }

                //go top to bottom
                for (var r = top; r < bottom; r++)
                {
                    output.Add(matrix[r][right - 1]);
                }
                right -= 1;

                if (!IsHorizontalAvailable())
                {
                    break;
                }

                //go right to left
                for (var c = right - 1; c >= left; c--)
                {
                    output.Add(matrix[bottom - 1][c]);
                }
                bottom -= 1;
                

                if (!IsVerticalAvailable())
                {
                    break;
                }

                //bottom to top
                for (var r = bottom - 1; r >= top; r--)
                {
                    output.Add(matrix[r][left]);
                }
                left += 1;
            }

            return output;
        }
    }
}
