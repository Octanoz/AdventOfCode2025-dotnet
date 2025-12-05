
using Day01;
using AdventUtilities;

Dictionary<string, string> filePaths = new()
{
    ["example1"] = Path.Combine(InputData.GetSolutionDirectory(), "InputFiles", "Day01", "example1.txt"),
    ["input"] = Path.Combine(InputData.GetSolutionDirectory(), "InputFiles", "Day01", "input.txt")
};

ReadOnlySpan<string> lines = File.ReadAllLines(filePaths["input"]);
int part1 = SafeCracker.TimesZero(lines);
int part2 = SafeCracker.TimesZero(lines, partTwo: true);


Console.WriteLine($"Part 1: {part1}");
Console.WriteLine($"Part 2: {part2}");
