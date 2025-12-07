namespace Day07;

using AdventUtilities;

using CommunityToolkit.HighPerformance;

public static class BeamSplitter
{
    private const char Beam = '|';
    private const char Splitter = '^';

    public static int Splits(Span<string> input)
    {
        char[,] grid = input.New2DGrid<char>();
        Span2D<char> gridSpan = grid.AsSpan2D();

        Span<char> firstRow = gridSpan.GetRowSpan(0);
        SetFirstBeam(firstRow);

        return PropagateBeam(gridSpan);
    }

    private static void SetFirstBeam(Span<char> firstRow)
    {
        for (int col = 0; col < firstRow.Length; col++)
        {
            if (firstRow[col] is 'S')
            {
                firstRow[col] = Beam;
                return;
            }
        }
    }

    private static int PropagateBeam(Span2D<char> grid)
    {
        int splits = 0;

        for (int row = 1; row < grid.Height; row++)
        {
            var topRow = grid.GetRowSpan(row - 1);
            var currentRow = grid.GetRowSpan(row);

            for (int col = 0; col < grid.Width; col++)
            {
                if (topRow[col] is Beam)
                {
                    if (currentRow[col] is Splitter)
                    {
                        currentRow[col - 1] = Beam;
                        currentRow[col + 1] = Beam;
                        splits++;
                    }
                    else
                    {
                        currentRow[col] = Beam;
                    }
                }
            }
        }

        return splits;
    }

    public static long Timelines(Span<string> input)
    {
        char[,] grid = input.New2DGrid<char>();
        Span2D<char> gridSpan = grid.AsSpan2D();

        Span<char> firstRow = gridSpan.GetRowSpan(0);
        SetFirstBeam(firstRow);

        return BeamTimelines(gridSpan);
    }

    private static long BeamTimelines(Span2D<char> grid)
    {
        long[,] counts = new long[grid.Height, grid.Width];
        Span2D<long> countSpan = counts.AsSpan2D();

        int column = 0;
        foreach (var cell in grid.GetRow(0))
        {
            if (cell is Beam)
                break;

            column++;
        }

        countSpan[0, column] = 1;
        for (int row = 0; row < grid.Height - 1; row++)
        {
            var currentRow = grid.GetRowSpan(row);
            var nextRow = countSpan.GetRowSpan(row + 1);

            for (int col = 0; col < grid.Width; col++)
            {
                if (countSpan[row, col] == 0)
                    continue;

                long timelineCount = countSpan[row, col];
                if (currentRow[col] is Splitter)
                {
                    nextRow[col - 1] += timelineCount;
                    nextRow[col + 1] += timelineCount;
                }
                else
                {
                    nextRow[col] += timelineCount;
                }
            }
        }

        long total = 0;
        var lastRow = countSpan.GetRowSpan(grid.Height - 1);
        for (int c = 0; c < grid.Width; c++)
        {
            total += lastRow[c];
        }

        return total;
    }
}
