namespace Day05;

public static class FreshRanges
{
    private static List<FreshRange> freshRanges = [];

    public static int FreshIngredients(string filePath)
    {
        List<long> freshIngredients = ParseInput(filePath);
        CombineRanges();
        return freshIngredients.Count(i => freshRanges.Any(r => r.Includes(i)));
    }

    public static long ValidIds() => freshRanges.Sum(r => r.Finish - r.Start + 1);

    private static List<long> ParseInput(string filePath)
    {
        List<long> ids = [];
        using StreamReader sr = new(filePath);

        bool parseIds = false;
        while (!sr.EndOfStream)
        {
            string current = sr.ReadLine()!;
            if (String.IsNullOrEmpty(current))
            {
                parseIds = true;
                continue;
            }

            if (!parseIds)
            {
                long[] range = Array.ConvertAll(current.Split('-'), long.Parse);
                freshRanges.Add(new(range[0], range[1]));

                continue;
            }

            ids.Add(long.Parse(current));
        }

        return ids;
    }

    private static void CombineRanges()
    {
        List<FreshRange> sortedRanges = [.. freshRanges.OrderBy(r => r.Start)];
        var currentRange = sortedRanges[0];

        int index = 1;
        while (index < sortedRanges.Count)
        {
            var otherRange = sortedRanges[index];
            if (currentRange.Wraps(otherRange))
            {
                sortedRanges.RemoveAt(index);
                continue;
            }

            if (currentRange.Overlaps(otherRange))
            {
                currentRange.Finish = otherRange.Finish;
                sortedRanges.RemoveAt(index);
            }
            else
            {
                currentRange = otherRange;
                index++;
            }
        }

        freshRanges = sortedRanges;
    }
}