namespace Day08;

public static class Playground
{
    public static long JunctionCircuits(string[] input, bool isExample = false)
    {
        List<Coord3D> coords = [..input.Select(line => Array.ConvertAll(line.Split(','), int.Parse))
                                       .Select(c => new Coord3D(c[0], c[1], c[2]))];

        List<(int a, int b, int dist)> pairs = [];
        for (int i = 0; i < coords.Count; i++)
        {
            for (int j = i + 1; j < coords.Count; j++)
            {
                pairs.Add((i, j, coords[i].Distance(coords[j])));
            }
        }

        var sortedPairs = pairs.OrderBy(c => c.dist).ToList();
        CircuitNetwork network = new(coords.Count);

        int limit = isExample ? 10 : 1000;
        for (int pair = 0; pair < limit; pair++)
        {
            var (a, b, _) = sortedPairs[pair];
            network.Connect(a, b);
        }

        int[] sizes = network.GetSizes();

        return sizes.OrderByDescending(s => s).Take(3).Aggregate(1L, (acc, val) => acc * val);
    }

    public static long LastConnectionProduct(string[] input, bool isExample = false)
    {
        List<Coord3D> coords = [..input.Select(line => Array.ConvertAll(line.Split(','), int.Parse))
                                       .Select(c => new Coord3D(c[0], c[1], c[2]))];

        List<(int a, int b, int dist)> pairs = [];
        for (int i = 0; i < coords.Count; i++)
        {
            for (int j = i + 1; j < coords.Count; j++)
            {
                pairs.Add((i, j, coords[i].Distance(coords[j])));
            }
        }

        var sortedPairs = pairs.OrderBy(c => c.dist).ToList();
        CircuitNetwork network = new(coords.Count);

        foreach (var (a, b, _) in sortedPairs)
        {
            network.Connect(a, b);

            if (network.GetSizes().Length == 1)
            {
                return (long)coords[a].X * (long)coords[b].X;
            }
        }

        return 0;
    }
}