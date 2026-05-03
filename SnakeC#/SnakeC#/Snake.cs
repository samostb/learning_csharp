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
    public DirectionsEnum Direction { get; private set; }
    public List<Point> RemovableOldPoints { get; }
    public bool Alive { get; private set; }

    private int _countEat = 0;
    private TimeSpan _moveDuration = TimeSpan.Zero;


    /// <summary>
    /// Square per second
    /// </summary>
    private double _speed = 4.5;

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



    public void Move(TimeSpan timeSpan)
    {
        _moveDuration += timeSpan;
        var path = (int)(_moveDuration.Milliseconds / 1000.0 * _speed);
        while (path >= 1)
        {
            Move();
            path--;
            _moveDuration -= TimeSpan.FromMilliseconds(1.0 / (_speed / 1000));
        }
    }
    
    private void Move()
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
        var lastElement = Body.Last();
        RemovableOldPoints.Add(lastElement);
        if (_countEat > 0)
        {
            _countEat--;
        }
        else
        {
            Body.Remove(lastElement);
        }
    }

    public void Kill()
    {
        Alive = false;

    }

    public void Blink()
    {
        while (true)
        {
            Clear();
            Thread.Sleep(200);
            Draw();
            Thread.Sleep(200);
        }
    }

    public void SetDirectionUp()
    {
        if (Direction == DirectionsEnum.Up || Direction == DirectionsEnum.Down)
            return;
        Direction = DirectionsEnum.Up;
    }

    public void SetDirectionDown()
    {
        if (Direction == DirectionsEnum.Up || Direction == DirectionsEnum.Down)
            return;
        Direction = DirectionsEnum.Down;
    }

    public void SetDirectionLeft()
    {
        if (Direction == DirectionsEnum.Left || Direction == DirectionsEnum.Right)
            return;
        Direction = DirectionsEnum.Left;
    }

    public void SetDirectionRight()
    {
        if (Direction == DirectionsEnum.Left || Direction == DirectionsEnum.Right)
            return;
        Direction = DirectionsEnum.Right;
    }

    public bool HitCoordinates(Point p)
    {
        foreach (var i in Body)
        {
            if (p == i)
            {
                return true;
            }
        }
        return false;
    }

    public void Eat()
    {
        _countEat++;
        
    }

    public void Poisoned()
    {
        //var lastElement = Body.Last();
        //Body.Remove(lastElement);
    }
}
