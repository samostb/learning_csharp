namespace SnakeC_;

internal class Snake
{
    public Snake(int width, int height)
    {
        Body = [new Point { X = width / 2, Y = height / 2 }];
    }

    public char HeadSymbol { get; } = '0';
    public char BodySymbol { get; } = 'O';
    public List<Point> Body { get; }

    public void Draw()
    {
        var head = Body.First();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(head.X, head.Y);
        Console.Write(HeadSymbol);
        //foreach (var p in Body)
        //{

        //}
    }

}
