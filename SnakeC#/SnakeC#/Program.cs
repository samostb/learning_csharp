using SnakeC_;

var map = new Map();
map.DrawFullMap();

var snake = new Snake(map.Width, map.Height);

var judge = new Judge(map, snake);

while (snake.Alive)
{
    snake.Draw();
    snake.Move();
    judge.CheckAlive();
    Thread.Sleep(500);
}

snake.Draw();

Console.SetCursorPosition(0, map.Height);
Console.ReadKey();

