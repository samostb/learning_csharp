using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC_;

internal static class ColorConsole
{
    public static void WriteLineColor(string text, ConsoleColor color)
    {
        WriteColor(text, color);
        Console.WriteLine();
    }

    public static void WriteColor(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
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
