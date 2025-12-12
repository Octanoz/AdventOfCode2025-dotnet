namespace Day09;

using AdventUtilities;

using CommunityToolkit.HighPerformance;

using System.Drawing;

public static class MovieTheater
{
    public static long Tiling(string[] input)
    {
        List<Coord> coords = GetCoords(input);

        long maxArea = 0;
        for (int i = 0; i < coords.Count - 1; i++)
        {
            Coord first = coords[i];
            for (int j = i + 1; j < coords.Count; j++)
            {
                Coord second = coords[j];

                var (topLeft, bottomRight) = Square(first, second);
                long area = Area(topLeft, bottomRight);

                maxArea = Math.Max(maxArea, area);
            }
        }

        return maxArea;
    }

    public static long RedGreenTilesArea(string[] input)
    {
        // Visualized findings
        // ! Wedge Row 2300 - 94860
        // ! Wedge Col 50400 - 48400

        List<Coord> coords = GetCoords(input);
        List<(Coord a, Coord b)> lines = [.. coords.Zip(coords.Skip(1))];
        lines.Add((coords.Last(), coords.First()));

        long maxArea = 0;
        for (int i = 0; i < coords.Count - 1; i++)
        {
            Coord first = coords[i];
            for (int j = i + 1; j < coords.Count; j++)
            {
                bool isValid = true;
                Coord second = coords[j];
                var (topLeft, bottomRight) = Square(first, second);
                if (topLeft.Col < 50400 && bottomRight.Col > 48400)
                    continue;

                foreach (var (a, b) in lines)
                {
                    if (a.Row == b.Row)
                    {
                        int startCol = Math.Min(a.Col, b.Col);
                        int endCol = Math.Max(a.Col, b.Col);

                        if (a.Row <= topLeft.Row || a.Row >= bottomRight.Row)
                        {
                            continue;
                        }

                        // Check column
                        if (topLeft.Col < endCol && bottomRight.Col > startCol)
                        {
                            isValid = false;
                            break;
                        }
                    }

                    int startRow = Math.Min(a.Row, b.Row);
                    int endRow = Math.Max(a.Row, b.Row);

                    if (a.Col <= topLeft.Col || a.Col >= bottomRight.Col)
                    {
                        continue;
                    }

                    // Check row
                    if (topLeft.Row < endRow && bottomRight.Row > startRow)
                    {
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                {
                    long area = Area(topLeft, bottomRight);
                    maxArea = Math.Max(maxArea, area);
                }
            }
        }

        return maxArea;
    }

    public static void Visualize(string[] input)
    {
        List<Coord> coords = [.. GetCoords(input).Select(c => new Coord(c.Row / 1000, c.Col / 1000))];
        int maxRow = 100;
        int maxCol = 100;

        char[,] visualGrid = GridExtensions.New2DGridBlank(maxRow, maxCol);
        Span2D<char> visualSpan = visualGrid.AsSpan2D();

        Coord prev = coords[0];

        visualSpan.SetCharAt('#', prev);
        for (int i = 1; i < coords.Count; i++)
        {
            Coord current = coords[i];
            if (prev.Row == current.Row)
            {
                while (prev.Col < current.Col)
                {
                    prev = prev.Right;
                    visualSpan.SetCharAt('#', prev);
                }

                while (prev.Col > current.Col)
                {
                    prev = prev.Left;
                    visualSpan.SetCharAt('#', prev);
                }
            }
            else
            {
                while (prev.Row < current.Row)
                {
                    prev = prev.Down;
                    visualSpan.SetCharAt('#', prev);
                }

                while (prev.Row > current.Row)
                {
                    prev = prev.Up;
                    visualSpan.SetCharAt('#', prev);
                }
            }
        }

        visualSpan.Draw2DGridTight();
    }

    private static (Coord topLeft, Coord bottomRight) Square(Coord a, Coord b)
    {
        int minRow = Math.Min(a.Row, b.Row);
        int minCol = Math.Min(a.Col, b.Col);
        int maxRow = Math.Max(a.Row, b.Row);
        int maxCol = Math.Max(a.Col, b.Col);

        return (new(minRow, minCol), new(maxRow, maxCol));
    }

    private static long Area(Coord topLeft, Coord bottomRight) => (1L + bottomRight.Row - topLeft.Row) * (1L + bottomRight.Col - topLeft.Col);

    private static List<Coord> GetCoords(string[] input) =>
        [..input.Select(line => Array.ConvertAll(line.Split(','), int.Parse))
                .Select(arr => new Coord(arr[0], arr[1]))];
}
