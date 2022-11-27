namespace StatisticsGames
{
    public class Multipliers
    {
        public List<double> Odds { get; private set; }
        public List<(double First, double Second)> Data { get; private set;}
        public double PessimismCoefficient { get; private set;}
        public double InformationReliabilityCoefficient { get; private set;}
        public double Square { get; private set;}

        public Multipliers(string path, int offset)
        {
            var data = File.ReadAllLines(path);
            Odds = new();
            data[0].Split(' ').ToList().ForEach(x => Odds.Add(double.Parse(x)));
            PessimismCoefficient = double.Parse(data[1]) * offset;
            InformationReliabilityCoefficient = double.Parse(data[2]) + 0.1 * offset;
            Square = double.Parse(data[3]);
            Data = new();
            for (int i = 4; i < data.Length; i++)
            {
                var line = data[i].Split(' ');
                Data.Add((double.Parse(line[0]), double.Parse(line[1])));
            }
        }
    }
}
