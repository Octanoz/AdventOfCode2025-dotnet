
using AdventUtilities;

using Day09;

Dictionary<string, string> filePaths = new()
{
    ["example"] = Path.Combine(InputData.GetSolutionDirectory(), "InputFiles", "Day09", "example1.txt"),
    ["input"] = Path.Combine(InputData.GetSolutionDirectory(), "InputFiles", "Day09", "input.txt")
};

string[] example = File.ReadAllLines(filePaths["example"]);

long example1 = MovieTheater.Tiling(example);
Console.WriteLine($"Example 1: {example1}");

string[] input = File.ReadAllLines(filePaths["input"]);
long part1 = MovieTheater.Tiling(input);
Console.WriteLine($"Part 1: {part1}");

// MovieTheater.Visualize(input);

long part2 = MovieTheater.RedGreenTilesArea(input);
Console.WriteLine($"Part 2: {part2}");
