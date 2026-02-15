using SnakeC_;

var map = new Map();
map.DrawFullMap();

var snake = new Snake(map.Width, map.Height);
snake.Draw();

Console.SetCursorPosition(0, map.Height);
Console.ReadKey();



Console.WriteLine("Hello 1");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Hello 2");


