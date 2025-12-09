namespace Day08;

public record Coord3D(int X, int Y, int Z)
{
    public int Distance(Coord3D other) =>
        (int)Math.Sqrt(Math.Pow(X - other.X, 2) +
                       Math.Pow(Y - other.Y, 2) +
                       Math.Pow(Z - other.Z, 2));
}