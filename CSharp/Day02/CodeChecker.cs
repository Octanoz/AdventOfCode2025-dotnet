namespace Day02;

public static class CodeChecker
{
    public static long SumInvalidCodeSplits(string input)
    {
        long invalidSum = 0L;
        var ranges = input.Split(',')
                          .Select(s => Array.ConvertAll(s.Split('-'), long.Parse))
                          .Select(arr => (arr[0], arr[1]));

        foreach (var (start, end) in ranges)
        {
            for (long i = start; i <= end; i++)
            {
                string current = i.ToString();
                if (current.Length % 2 != 0)
                    continue;

                int mid = current.Length / 2;
                if (current.AsSpan(0, mid).SequenceEqual(current.AsSpan(mid, mid)))
                    invalidSum += i;
            }
        }

        return invalidSum;
    }

    public static long SumInvalidCodes(string input)
    {
        long invalidSum = 0L;
        var ranges = input.Split(',')
                          .Select(s => Array.ConvertAll(s.Split('-'), long.Parse))
                          .Select(arr => (arr[0], arr[1]));

        foreach (var (start, end) in ranges)
        {
            for (long i = start; i <= end; i++)
            {
                if (IsInvalid(i.ToString()))
                    invalidSum += i;
            }
        }

        return invalidSum;
    }

    private static bool IsInvalid(string number)
    {
        int length = number.Length;
        for (int chunk = 1; chunk <= length / 2; chunk++)
        {
            if (length % chunk != 0)
                continue;

            bool allMatch = true;
            for (int i = chunk; i < length; i++)
            {
                if (number[i] != number[i % chunk])
                {
                    allMatch = false;
                    break;
                }
            }

            if (allMatch)
                return true;
        }

        return false;
    }
}