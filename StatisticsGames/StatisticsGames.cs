namespace StatisticsGames
{
    public class StatisticsGames
    {
        Matrix matrix;
        Multipliers multipliers;
        public StatisticsGames(Matrix inputMatrix, Multipliers multipliers)
        {
            double[,] matrix = new double[multipliers.Data.Count, multipliers.Odds.Count];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = (inputMatrix.At(0, j) * multipliers.Data[i].First + inputMatrix.At(1, j) * multipliers.Data[i].Second) * multipliers.Square;
                }
            }
            this.matrix = new(matrix);
            this.multipliers = multipliers;
        }

        public int BayesCriterion()
        {
            var max = 0.0;
            var pos = 0;
            for (int i = 0; i < matrix.Height; i++)
            {
                var sum = 0.0;
                for (int j = 0; j < matrix.Width; j++)
                {
                    sum += matrix.At(i, j) * multipliers.Odds[j];
                }

                if (max > sum)
                {
                    max = sum;
                    pos = i;
                }
            }

            return pos;
        }

        public int LaplaceCriterion()
        {
            var max = matrix.RowAverage(0);
            var pos = 0;
            for (int i = 1; i < matrix.Height; i++)
            {
                var data = matrix.RowAverage(i);
                if (data > max)
                {
                    max = data;
                    pos = i;
                }
            }

            return pos;
        }

        public int MaximinWaldCriterion()
        {
            var max = matrix.RowMin(0);
            var pos = 0;
            for (int i = 1; i < matrix.Height; i++)
            {
                var data = matrix.RowMin(i);
                if (data > max)
                {
                    max = data;
                    pos = i;
                }
            }

            return pos;
        }

        public int HurwitzPessimismOptimismCriterion()
        {
            var max = matrix.RowMin(0) * multipliers.PessimismCoefficient + matrix.RowMax(0) * (1 - multipliers.PessimismCoefficient);
            var pos = 0;
            for (int i = 1; i < matrix.Height; i++)
            {
                var data = matrix.RowMin(i) * multipliers.PessimismCoefficient + matrix.RowMax(i) * (1 - multipliers.PessimismCoefficient);
                if (data > max)
                {
                    max = data;
                    pos = i;
                }
            }

            return pos;
        }
        
        public int HodgeLehmannCriterion()
        {
            var max = 0.0;
            var pos = 0;
            for (int i = 0; i < matrix.Height; i++)
            {
                var value = 0.0;
                for (int j = 0; j < matrix.Width; j++)
                {
                    value += matrix.At(i, j) * multipliers.Odds[j];
                }

                value = multipliers.InformationReliabilityCoefficient * value + (1 - multipliers.InformationReliabilityCoefficient) * matrix.RowMin(i);
                if (max > value)
                {
                    max = value;
                    pos = i;
                }
            }

            return pos;
        }

        public int SavagesMinimaxRiskTest()
        {
            Matrix newMatrix = new(matrix);
            var max = newMatrix.RowMax(0);
            var pos = 0;
            for (int i = 0; i < matrix.Height; i++)
            {
                var data = newMatrix.RowMax(i);
                if (data > max)
                {
                    max = data;
                    pos = i;
                }
            }

            return pos;
        }
    }
}
