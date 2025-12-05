namespace Day03;

public static class Joltage
{
    public static long GetJoltage(ReadOnlySpan<string> banks, bool partTwo = false)
    {
        long totalJoltage = 0;
        foreach (var bank in banks)
        {
            totalJoltage += partTwo switch
            {
                true => CheckSlidingJoltage(bank),
                false => CheckJoltage(bank)
            };
        }

        return totalJoltage;
    }

    private static int CheckJoltage(string bank)
    {
        char tens = bank[..(bank.Length - 1)].Max();
        int startIndex = bank.IndexOf(tens) + 1;
        char ones = bank[startIndex..].Max();

        return (tens - '0') * 10 + (ones - '0');
    }

    private static long CheckSlidingJoltage(string bank)
    {
        int length = bank.Length;
        Span<char> jolts = stackalloc char[12];

        jolts[0] = bank[..(length - 11)].Max();
        int startIndex = bank.IndexOf(jolts[0]) + 1;

        for (int i = 1; i < 12; i++)
        {
            int endIndex = length - (12 - i) + 1;
            var window = bank[startIndex..endIndex];
            jolts[i] = window.Max();
            startIndex = bank.IndexOf(jolts[i], startIndex) + 1;
        }

        return long.Parse(new string(jolts));
    }
}