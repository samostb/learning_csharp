using SnakeC_.Foods;

namespace SnakeC_;

internal class Map
{
    public char BordersSymbol { get; set; } = '#';

    public int Height { get; set; } = 50;

    public int Width { get; set; } = 100;

    private List<FoodBase> _foods = [];

    private static object _lock = new object();

    public void AddFood(FoodBase food)
    {
        lock (_lock)
        {
            _foods.Add(food);
        }
    }

    public void DrawFoods()
    {
        char symbol;
        lock (_lock)
        {
            foreach (var food in _foods)
            {
                symbol = food.GetSymbol();
                Console.SetCursorPosition(food.Point.X, food.Point.Y);
                Console.Write(symbol);
            }
        }
    }

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
    public void PrintGameOver()
    {
        Console.SetCursorPosition(Width / 2 - 5, Height / 2);
        Console.Write("Game Over");
    }


}
