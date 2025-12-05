
using Day05;
using AdventUtilities;

Dictionary<string, string> filePaths = new()
{
    ["example"] = Path.Combine(InputData.GetSolutionDirectory(), "InputFiles", "Day05", "example1.txt"),
    ["input"] = Path.Combine(InputData.GetSolutionDirectory(), "InputFiles", "Day05", "input.txt")
};

int part1 = FreshRanges.FreshIngredients(filePaths["input"]);
long part2 = FreshRanges.ValidIds();

Console.WriteLine($"Part 1: {part1}");
Console.WriteLine($"Part 2: {part2}");
