using SnakeC_;
using SnakeC_.Foods;

var map = new Map();
map.DrawFullMap();

var snake = new Snake(map.Width, map.Height);

var judge = new Judge(map, snake);

var userControl = new UserInputControler(snake, map.Height);

userControl.StartListen();

var foodGenerator = new FoodGenerator(map, snake);


while (snake.Alive)
{
    map.DrawFoods();
    snake.Draw();
    snake.Move();
    judge.CheckAlive();
    Thread.Sleep(500);
}

snake.Draw();
map.PrintGameOver();
snake.Blink();


Console.SetCursorPosition(0, map.Height);
Console.ReadKey();
