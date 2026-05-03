using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC_
{
    internal class Dashboard
    {
        private char BordersSymbol { get; set; } = '*';

        private int _height;

        private int _width = 20;

        public int MapHeight { get; private set; }

        public int MapWidth { get; private set; }

        public int Score { get; private set; }

        public string Message { get; private set; }

        public Dashboard(int mapWidth, int mapHeight)
        {
            MapHeight = mapHeight;
            MapWidth = mapWidth;
            _height = MapHeight;
        }

        public void Draw()
        {
            Console.SetCursorPosition(MapWidth, 0);
            InterfaceDrawer.DrawHorizontalLine(BordersSymbol, _width, ConsoleColor.Green);
            Console.SetCursorPosition(MapWidth, 1);
            InterfaceDrawer.DrawVerticalColumns(BordersSymbol, _width, _height, ConsoleColor.Green);
            Console.SetCursorPosition(MapWidth, _height - 1);
            InterfaceDrawer.DrawHorizontalLine(BordersSymbol, _width, ConsoleColor.Green);
        }

        public void DrawInfo()
        {
            var i = 4;
            var scoreText = $"Score:{Score}";
            Console.SetCursorPosition(MapWidth + _width / 2 - scoreText.Length / 2, i);
            i += 4;
            ColorConsole.WriteLineColor(scoreText, ConsoleColor.Green);

            Console.SetCursorPosition(MapWidth + 1, i);
            i += 4;
            InterfaceDrawer.DrawHorizontalLine(BordersSymbol, _width - 1, ConsoleColor.Green);


            if (Message != null)
            {
                var messageText = Message.Length >= _width - 1 ? Message.Substring(0, _width - 1) : Message;
                Console.SetCursorPosition(MapWidth + 1, i);
                InterfaceDrawer.DrawHorizontalLine(' ', _width - 2, ConsoleColor.Green);
                Console.SetCursorPosition(MapWidth + _width / 2 - messageText.Length / 2, i);
                ColorConsole.WriteLineColor(messageText, ConsoleColor.Green);
            }
            i += 4;

            Console.SetCursorPosition(MapWidth + 1, i);
            i += 4;
            InterfaceDrawer.DrawHorizontalLine(BordersSymbol, _width - 1, ConsoleColor.Green);
        }

        public void AddScore(int score)
        {
            Score += score;
        }

        public void SetMessage(string message)
        {
            Message = message;
        }

    }
}
