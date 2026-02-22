namespace SnakeC_;

internal class Snake
{
    public Snake(int width, int height)
    {
        Body =
            [
                new Point { X = width / 2, Y = height / 2 },
                new Point { X = width / 2, Y = height / 2 + 1 },
                new Point { X = width / 2, Y = height / 2 + 2 }
            ];
        Direction = DirectionsEnum.Up;
        RemovableOldPoints = [];
        Alive = true;
    }

    public char HeadSymbol { get; } = '0';
    public char BodySymbol { get; } = 'O';
    public List<Point> Body { get; }
    public DirectionsEnum Direction { get; }
    public List<Point> RemovableOldPoints { get; }
    public bool Alive { get; private set; }

    public void Draw()
    {
        var head = Body.First();

        Clear();
        Console.SetCursorPosition(head.X, head.Y);
        ColorConsole.WriteColor(HeadSymbol, ConsoleColor.Green);
        foreach (var p in Body.Skip(1))
        {
            Console.SetCursorPosition(p.X, p.Y);
            ColorConsole.WriteColor(BodySymbol, ConsoleColor.Green);
        }
    }

    public void Clear()
    {
        foreach (var p in Body)
        {
            Console.SetCursorPosition(p.X, p.Y);
            Console.Write(" ");
        }

        foreach (var p in RemovableOldPoints)
        {
            Console.SetCursorPosition(p.X, p.Y);
            Console.Write(" ");
        }
        RemovableOldPoints.Clear();
    }



    public void Move()
    {
        switch (Direction)
        {
            case DirectionsEnum.Up:
                Body.Insert(0, new Point { X = Body.First().X, Y = Body.First().Y - 1 });
                break;
            case DirectionsEnum.Down:
                Body.Insert(0, new Point { X = Body.First().X, Y = Body.First().Y + 1 });
                break;
            case DirectionsEnum.Left:
                Body.Insert(0, new Point { X = Body.First().X - 1, Y = Body.First().Y });
                break;
            case DirectionsEnum.Right:
                Body.Insert(0, new Point { X = Body.First().X + 1, Y = Body.First().Y });
                break;
        }
        var LastElement = Body.Last();
        RemovableOldPoints.Add(LastElement);
        Body.Remove(LastElement);
    }

    public void Kill()
    {
        Alive = false;

    }
}
