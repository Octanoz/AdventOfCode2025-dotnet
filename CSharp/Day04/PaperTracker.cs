namespace Day04;

using AdventUtilities;

using CommunityToolkit.HighPerformance;

public static class PaperTracker
{
    public static int AccessibleRolls(Span<string> input)
    {
        int accessible = 0;
        char[,] grid = input.New2DGridWithDimensions<char>(out int rows, out int cols);
        Span2D<char> gridSpan = grid.AsSpan2D();

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Coord current = new(row, col);
                if (gridSpan.GetValueAt(current) is '.')
                    continue;

                var neighbours = current.GetAllNeighbours(rows, cols);
                if (HasLessThanFourRolls(gridSpan, neighbours))
                {
                    gridSpan.SetCharAt('x', current);
                    accessible++;
                }
            }
        }

        gridSpan.Draw2DGridTight();

        return accessible;
    }

    public static int AccessibleRollsRepeated(Span<string> input)
    {
        int accessible = 0;
        int currentAccessible;
        char[,] grid = input.New2DGridWithDimensions<char>(out int rows, out int cols);
        Span2D<char> gridSpan = grid.AsSpan2D();

        do
        {
            currentAccessible = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Coord current = new(row, col);
                    if (gridSpan.GetValueAt(current) is '.')
                        continue;

                    var neighbours = current.GetAllNeighbours(rows, cols);
                    if (HasLessThanFourRolls(gridSpan, neighbours))
                    {
                        gridSpan.SetCharAt('x', current);
                        currentAccessible++;
                    }
                }
            }

            accessible += currentAccessible;
            CleanGrid(gridSpan, rows, cols);
        } while (currentAccessible > 0);

        gridSpan.Draw2DGridTight();

        return accessible;
    }

    private static bool HasLessThanFourRolls(Span2D<char> grid, IEnumerable<Coord> coords)
    {
        int rolls = 0;
        foreach (var coord in coords)
        {
            if (grid.GetValueAt(coord) is '@' or 'x')
            {
                rolls++;
            }
        }

        return rolls < 4;
    }

    private static void CleanGrid(Span2D<char> grid, int rows, int cols)
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Coord current = new(row, col);
                if (grid.GetValueAt(current) is 'x')
                {
                    grid.SetCharAt('.', current);
                }
            }
        }
    }
}