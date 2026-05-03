using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC_
{
    internal static class InterfaceDrawer
    {
        
        public static void DrawHorizontalLine(char symbol, int length, ConsoleColor color)
        {
            ColorConsole.WriteLineColor(new string(symbol, length), color);
        }

        public static void DrawVerticalColumns(char symbol, int width, int height, ConsoleColor color)
        {
            var left = Console.CursorLeft;
            var line = $"{symbol}{new string(' ', width - 2)}{symbol}";
            for (int i = 0; i < height - 2; i++)
            {
                Console.CursorLeft = left;
                ColorConsole.WriteLineColor(line, color);
            }
        }


    }
}
