
using AdventUtilities;

Dictionary<string, string> filePaths = new()
{
    ["example"] = Path.Combine(InputData.GetSolutionDirectory(), "InputFiles", "Day09", "example1.txt"),
    ["input"] = Path.Combine(InputData.GetSolutionDirectory(), "InputFiles", "Day09", "input.txt")
};

string[] example = File.ReadAllLines(filePaths["example"]);
