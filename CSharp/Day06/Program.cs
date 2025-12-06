
using Day06;
using AdventUtilities;

Dictionary<string, string> filePaths = new()
{
    ["example"] = Path.Combine(InputData.GetSolutionDirectory(), "InputFiles", "Day06", "example1.txt"),
    ["input"] = Path.Combine(InputData.GetSolutionDirectory(), "InputFiles", "Day06", "input.txt")
};

string[] example = File.ReadAllLines(filePaths["example"]);
string[] input = File.ReadAllLines(filePaths["input"]);
long part1 = CephalodMath.TotalSum(input);
long part2 = CephalodMath.RTLSum(input);

Console.WriteLine(part1);
Console.WriteLine(part2);
