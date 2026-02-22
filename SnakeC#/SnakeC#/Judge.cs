namespace SnakeC_;

internal class Judge
{
    private Map _map;
    private Snake _snake;

    public Judge(Map m, Snake s)
    {
        _map = m;
        _snake = s;
    }

    public void CheckAlive()
    {
        if(!CheckBorders())
        {
            _snake.Kill();
        }
    }

    private bool CheckBorders()
    {
        var head = _snake.Body.First();
        if (head.X <= 0 || head.X >= _map.Width - 1)
        {
            return false;
        }
        if (head.Y <= 0 || head.Y >= _map.Height - 1)
        {
            return false;
        }

        return true;
    }
}

