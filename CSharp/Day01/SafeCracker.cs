namespace Day01;

public static class SafeCracker
{
    public static int TimesZero(ReadOnlySpan<string> input, bool partTwo = false)
    {
        int dial = 50;
        int zeroes = 0;

        foreach (var line in input)
        {
            var (direction, number) = ParseLine(line);

            dial = MoveDial(dial, direction, number);

            zeroes += partTwo switch
            {
                false => dial is 0 ? 1 : 0,
                true => CountZeroesDuringRotation(dial, direction, number)
            };
        }

        return zeroes;
    }

    private static (char, int) ParseLine(string line) => (line[0], int.Parse(line[1..]));

    private static int MoveDial(int current, char direction, int distance)
    {
        int remainder = distance % 100; // Skip full cycles
        return direction switch
        {
            'L' => (current - remainder + 100) % 100, // Force positive remainder for modulo functionality
            'R' => (current + remainder) % 100,
            _ => throw new ArgumentException($"Unknown direction: {direction}")
        };
    }

    private static int CountZeroesDuringRotation(int dial, char direction, int number)
    {
        int zeroCount = number / 100; // Add full cycles upfront
        int remainder = number % 100;

        if (dial is not 0
        && (direction is 'L' && dial - remainder <= 0
        || direction is 'R' && dial + remainder >= 100))
        {
            zeroCount++;
        }

        return zeroCount;
    }
}