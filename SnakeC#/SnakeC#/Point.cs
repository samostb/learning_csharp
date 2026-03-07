using System.Diagnostics.CodeAnalysis;

namespace SnakeC_;

internal struct Point
{
    public int X { get; set; }

    public int Y { get; set; }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        var other = (Point)obj!;
        return X == other.X && Y == other.Y;
    }

    public static bool operator == (Point a, Point b)
    {
        return a.Equals(b);
    }

    public static bool operator != (Point a, Point b)
    {
        return !a.Equals(b);
    }
}
