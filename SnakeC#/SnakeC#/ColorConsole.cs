using static System.Console;

namespace SnakeC_;

internal static class ColorConsole
{
    public static void WriteLineColor(string text, ConsoleColor color)
    {
        WriteColor(text, color);
        WriteLine();
    }

    public static void WriteColor(string text, ConsoleColor color)
    {
        ForegroundColor = color;
        Write(text);
    }

    public static void WriteLineColor(char text, ConsoleColor color)
    {
        WriteLineColor(text.ToString(), color);
    }
    public static void WriteColor(char text, ConsoleColor color)
    {
        WriteColor(text.ToString(), color);
    }
}
