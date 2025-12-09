
using Day08;
using AdventUtilities;

Dictionary<string, string> filePaths = new()
{
    ["example"] = Path.Combine(InputData.GetSolutionDirectory(), "InputFiles", "Day08", "example1.txt"),
    ["input"] = Path.Combine(InputData.GetSolutionDirectory(), "InputFiles", "Day08", "input.txt")
};

string[] example = File.ReadAllLines(filePaths["example"]);

long example1 = Playground.JunctionCircuits(example, isExample: true);
Console.WriteLine($"Example 1: {example1}");

string[] input = File.ReadAllLines(filePaths["input"]);
long part1 = Playground.JunctionCircuits(input);
Console.WriteLine($"Part 1: {part1}");

long part2 = Playground.LastConnectionProduct(input);
Console.WriteLine($"Part 2: {part2}");
