
using Day03;
using AdventUtilities;

Dictionary<string, string> filePaths = new()
{
    ["example"] = Path.Combine(InputData.GetSolutionDirectory(), "InputFiles", "Day03", "example1.txt"),
    ["input"] = Path.Combine(InputData.GetSolutionDirectory(), "InputFiles", "Day03", "input.txt")
};

ReadOnlySpan<string> example = File.ReadAllLines(filePaths["example"]);
ReadOnlySpan<string> input = File.ReadAllLines(filePaths["input"]);
long part1 = Joltage.GetJoltage(input);
long part2 = Joltage.GetJoltage(input, partTwo: true);

Console.WriteLine($"Part 1: {part1}");
Console.WriteLine($"Part 2: {part2}");
