namespace Day05;

public class FreshRange(long start, long finish)
{
    public long Start { get; init; } = start;
    public long Finish { get; set; } = finish;

    public bool Includes(long value) => value >= Start && value <= Finish;

    public bool Wraps(FreshRange other) => Includes(other.Start) && Includes(other.Finish);

    public bool Overlaps(FreshRange other) => Includes(other.Start);
}
