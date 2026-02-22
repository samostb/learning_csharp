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
        ColorConsole.WriteLineColor(new string(BordersSymbol, Width), ConsoleColor.Red);
    }

    private void DrawVerticalLine()
    {
        var line = $"{BordersSymbol}{new string(' ', Width - 2)}{BordersSymbol}";
        for (int i = 0; i < Height - 2; i++)
        {
            ColorConsole.WriteLineColor(line, ConsoleColor.Red);
        }
    }
}
