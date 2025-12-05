
using Day04;
using AdventUtilities;

Dictionary<string, string> filePaths = new()
{
    ["example"] = Path.Combine(InputData.GetSolutionDirectory(), "InputFiles", "Day04", "example1.txt"),
    ["input"] = Path.Combine(InputData.GetSolutionDirectory(), "InputFiles", "Day04", "input.txt")
};

Span<string> example = File.ReadAllLines(filePaths["example"]);
Span<string> input = File.ReadAllLines(filePaths["input"]);


int part1 = PaperTracker.AccessibleRolls(input);
Console.WriteLine($"Part 1: {part1}");

int part2 = PaperTracker.AccessibleRollsRepeated(input);
Console.WriteLine($"Part 2: {part2}");
