
using Day07;
using AdventUtilities;

Dictionary<string, string> filePaths = new()
{
    ["example"] = Path.Combine(InputData.GetSolutionDirectory(), "InputFiles", "Day07", "example1.txt"),
    ["input"] = Path.Combine(InputData.GetSolutionDirectory(), "InputFiles", "Day07", "input.txt")
};

string[] example = File.ReadAllLines(filePaths["example"]);
string[] input = File.ReadAllLines(filePaths["input"]);

long part1 = BeamSplitter.SplitBeams(input);
long part2 = BeamSplitter.SplitBeams(input, partTwo: true);

Console.WriteLine($"Part 1: {part1}");
Console.WriteLine($"Part 2: {part2}");
