namespace SnakeC_;

internal class Map
{
    public char BordersSymbol { get; set; } = '#';

    public int Height { get; set; } = 50;

    public int Width { get; set; } = 100;

    public void DrawFullMap()
    {
        DrawHorizontalLine();
        DrawVerticalLine();
        DrawHorizontalLine();
    }

    private void DrawHorizontalLine()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(new string(BordersSymbol, Width));
    }

    private void DrawVerticalLine()
    {
        var line = $"{BordersSymbol}{new string(' ', Width - 2)}{BordersSymbol}";
        for (int i = 0; i < Height - 2; i++)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(line);
        }
    }
}
