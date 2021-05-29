namespace Main.Common
{
    public class Matrix
    {
        public static int[][] GenerateMatrix(int dimensions)
        {
            var number = 1;
            var matrix = new int[dimensions][];

            for (var i = 0; i < dimensions; i++)
            {
                var currentRow = new int[dimensions];
                for (var j = 0; j < dimensions; j++)
                {
                    currentRow[j] = number++;
                }

                matrix[i] = currentRow;
            }

            return matrix;
        }
    }
}
