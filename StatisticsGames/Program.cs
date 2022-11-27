using StatisticsGames;
using Statistics = StatisticsGames.StatisticsGames;

const string matrixPath = @"D:\StatisticsGames\matrix.txt";
const string path = @"D:\StatisticsGames\coefficients.txt";
const int option = 14;
Matrix matrix = new(matrixPath, option);
Multipliers multipliers = new(path, option);
Statistics statisticsGames = new(matrix, multipliers);
Console.WriteLine($"Оптимальный выбор по критерию Байеса - {statisticsGames.BayesCriterion() + 1}");
Console.WriteLine($"Оптимальный выбор по критерию недостаточного основания Лапласа - { statisticsGames.LaplaceCriterion() + 1}");
Console.WriteLine($"Оптимальный выбор по максиминному критерий Вальда - { statisticsGames.MaximinWaldCriterion() + 1}");
Console.WriteLine($"Оптимальный выбор по критерию пессимизма-оптимизма Гурвица - { statisticsGames.HurwitzPessimismOptimismCriterion() + 1}");
Console.WriteLine($"Оптимальный выбор по критерию Ходжа-Лемана - { statisticsGames.HodgeLehmannCriterion() + 1}");
Console.WriteLine($"Оптимальный выбор по критерию минимаксого риска Сэвиджа - { statisticsGames.SavagesMinimaxRiskTest() + 1}");