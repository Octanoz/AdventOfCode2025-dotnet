namespace Day06;

public static class CephalodMath
{
    public static long TotalSum(string[] input)
    {
        List<long> results = [];
        List<string> numbers = [];
        string[][] mathProblems = [.. input.Select(s => s.Split(' ', StringSplitOptions.RemoveEmptyEntries))];
        var (row, col) = (0, 0);

        while (col < mathProblems[0].Length)
        {
            string current = mathProblems[row][col];

            if (Char.IsDigit(current[0]))
            {
                numbers.Add(current);
                row++;
                continue;
            }

            results.Add(current[0] switch
            {
                '*' => MultiplyStrings(numbers),
                '+' => AddStrings(numbers),
                _ => throw new ArgumentException($"Unknown operator given: {current[0]}")
            });

            // next column and reset
            numbers.Clear();
            col++;
            row = 0;
        }

        return results.Sum();
    }

    public static long RTLSum(string[] input)
    {
        List<long> results = [];
        List<long> numbers = [];
        List<char> currentNumber = [];
        char action = '\0';
        bool isLastRow = false;
        var (maxRow, row, col) = (input.Length - 1, 0, 0);

        while (col < input[0].Length)
        {
            char current = input[row][col];
            isLastRow = row == maxRow;

            if (Char.IsDigit(current))
            {
                currentNumber.Add(current);
            }
            else if (!Char.IsDigit(current) && isLastRow)
            {
                if (current != ' ')
                {
                    action = current; // '*' or '+'
                }
                else if (currentNumber.Count is 0)
                {
                    results.Add(action switch
                    {
                        '*' => numbers.Aggregate(1L, (acc, val) => acc * val),
                        '+' => numbers.Aggregate(0L, (acc, val) => acc + val),
                        _ => throw new ArgumentException($"Unknown operator given: {action}")
                    });

                    // new column and equation reset
                    numbers.Clear();
                    col++;
                    row = 0;
                    continue;
                }

                numbers.Add(BuildNumber(currentNumber));

                // new column reset
                currentNumber.Clear();
                row = -1;
                col++;
            }

            row++;
        }

        // Final calculation not triggered inside the loop
        results.Add(action switch
        {
            '*' => numbers.Aggregate(1L, (acc, val) => acc * val),
            '+' => numbers.Aggregate(0L, (acc, val) => acc + val),
            _ => throw new ArgumentException($"Unknown operator given: {action}")
        });

        return results.Sum();
    }

    private static long MultiplyStrings(List<string> numbers) => numbers.Aggregate(1L, (acc, val) => acc * long.Parse(val));

    private static long AddStrings(List<string> numbers) => numbers.Aggregate(0L, (acc, val) => acc + long.Parse(val));

    private static long BuildNumber(List<char> digits)
    {
        long number = 0;
        foreach (var digit in digits)
        {
            number *= 10;
            number += digit - '0';
        }

        return number;
    }
}
