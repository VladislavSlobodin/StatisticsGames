namespace StatisticsGames
{
    public class Matrix
    {
        private double[,] matrix;
        private int height;
        private int width;

        public double At(int x, int y) => matrix[x, y];
        public int Height => height;
        public int Width => width;

        public Matrix(Matrix matrix)
        {
            double[,] matrixData = new double[matrix.Height, matrix.Width];
            for (int i = 0; i < matrix.Width; i++)
            {
                var columnMax = matrix.ColumnMax(i);
                for (int j = 0; j < matrix.Width; j++)
                {
                    matrixData[j, i] = columnMax - matrix.At(j, i);
                }
            }

            this.matrix = matrixData;
            height = matrix.Height;
            width = matrix.Width;
        }

        public Matrix(double[,] matrix)
        {
            this.matrix = matrix;
            height = matrix.GetLength(0);
            width = matrix.GetLength(1);
        }

        public Matrix(string path, int offset)
        {
            var data = File.ReadAllLines(path);
            height = data.Length;
            width = data[0].Split(' ').Length;
            matrix = new double[height, width];
            for (int i = 0; i < height; i++)
            {
                var line = data[i].Split(' ');
                for (int j = 0; j < width; j++)
                {
                    matrix[i, j] = double.Parse(line[j]) + offset;
                }
            }
        }

        public double RowAverage(int index)
        {
            var sum = 0.0;
            for (int i = 0; i < width; i++)
            {
                sum += matrix[index, i];
            }
            return sum / width;
        }

        public double RowMin(int index)
        {
            var min = matrix[index, 0];
            for (int i = 1; i < width; i++)
            {
                if (matrix[index, i] < min)
                {
                    min = matrix[index, i];
                }
            }
            return min;
        }
        public double RowMax(int index)
        {
            var max = matrix[index, 0];
            for (int i = 1; i < width; i++)
            {
                if (matrix[index, i] > max)
                {
                    max = matrix[index, i];
                }
            }
            return max;
        }

        public double ColumnMax(int index)
        {
            var max = matrix[0, index];
            for (int i = 1; i < height; i++)
            {
                if (matrix[i, index] > max)
                {
                    max = matrix[i, index];
                }
            }
            return max;
        }
    }
}
