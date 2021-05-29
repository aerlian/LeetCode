using System;
using System.Collections.Generic;

namespace Main.SeventyFive
{
    public class SpiralOrder
    {
        public static void Execute()
        {
            var matrix = Common.Matrix.GenerateMatrix(3);
            var list = SpiralOrderImpl(matrix);
            Console.WriteLine(string.Join(',', list));
        }

        public static IList<int> SpiralOrderImpl(int[][] matrix)
        {
            var left = 0;
            var top = 0;
            var bottom = matrix.Length;
            var right = matrix[0].Length;

            var output = new List<int>();
            

            while (left < right && top < bottom)
            {
                for (var i = left; i < right; i++)
                {
                    output.Add(matrix[top][i]);
                }

                top += 1;

                for (var i = top; i < bottom; i++)
                {
                    output.Add(matrix[i][right - 1]);
                }

                right -= 1;

                if (!(left < right && top < bottom))
                {
                    break;
                }

                for (var i = right - 1; i >= left; i--)
                {
                    output.Add(matrix[bottom - 1][i]);
                }

                bottom -= 1;

                for (var i = bottom - 1; i >= top; i--)
                {
                    output.Add(matrix[i][left]);
                }

                left += 1;
            }

            return output;
        }
    }
}
