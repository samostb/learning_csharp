using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC_
{
    internal class UserInputControler
    {
        private Thread? _thread;
        private Snake _snake;
        private int _height;

        public UserInputControler(Snake snake, int height)
        {
            _thread = new Thread(Listen);
            _thread.IsBackground = true;
            _snake = snake;
            _height = height;
        }

        public void StartListen()
        {
            _thread!.Start();
        }

        private void Listen()
        {
            while (true)
            {
                var keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        _snake.SetDirectionUp();
                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        _snake.SetDirectionDown();
                        break;
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        _snake.SetDirectionLeft();
                        break;
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        _snake.SetDirectionRight();
                        break;
                    case ConsoleKey.Escape:
                        Console.SetCursorPosition(0, _height);
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
