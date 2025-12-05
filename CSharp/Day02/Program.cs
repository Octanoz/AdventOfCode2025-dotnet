
using AdventUtilities;
using Day02;

Dictionary<string, string> filePaths = new()
{
    ["example"] = Path.Combine(InputData.GetSolutionDirectory(), "InputFiles", "Day02", "example1.txt"),
    ["input"] = Path.Combine(InputData.GetSolutionDirectory(), "InputFiles", "Day02", "input.txt")
};

string example = File.ReadAllText(filePaths["example"]);
string input = File.ReadAllText(filePaths["input"]);

Console.WriteLine($"Part 1: {CodeChecker.SumInvalidCodeSplits(input)}");
Console.WriteLine($"Part 2: {CodeChecker.SumInvalidCodes(input)}");

