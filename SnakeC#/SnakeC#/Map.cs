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

    public FoodBase? GetFood(Point x)
    {
        foreach (var food in _foods)
        {
            if (food.Point == x)
            {
                return food;
            }
        }
        return null;
    }

    public void DeleteFood(FoodBase food)
    {
        _foods.Remove(food);
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
        InterfaceDrawer.DrawHorizontalLine(BordersSymbol, Width, ConsoleColor.Red);
        InterfaceDrawer.DrawVerticalColumns(BordersSymbol, Width, Height, ConsoleColor.Red);
        InterfaceDrawer.DrawHorizontalLine(BordersSymbol, Width, ConsoleColor.Red);
    }

    public void PrintGameOver()
    {
        Console.SetCursorPosition(Width / 2 - 5, Height / 2);
        Console.Write("Game Over");
    }


}
