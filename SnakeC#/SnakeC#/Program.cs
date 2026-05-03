using SnakeC_;
using SnakeC_.Foods;

var map = new Map();
var dashboard = new Dashboard(map.Width, map.Height);
map.DrawFullMap();
dashboard.Draw();
Console.CursorVisible = false;

var snake = new Snake(map.Width, map.Height);

var judge = new Judge(map, snake, dashboard);

var userControl = new UserInputControler(snake, map.Height);

userControl.StartListen();

var foodGenerator = new FoodGenerator(map, snake);


var lastTime = DateTime.Now;
while (snake.Alive)
{
    map.DrawFoods();
    dashboard.DrawInfo();
    snake.Draw();
    var frameRate = DateTime.Now - lastTime;
    var fps = 1 / frameRate.TotalSeconds;
    Console.WriteLine((int)fps);
    snake.Move(frameRate);
    judge.CheckEatedFood();
    judge.CheckAlive();
    lastTime = DateTime.Now;
    Thread.Sleep(10);
}

snake.Draw();
map.PrintGameOver();
snake.Blink();


Console.SetCursorPosition(0, map.Height);
Console.ReadKey();
