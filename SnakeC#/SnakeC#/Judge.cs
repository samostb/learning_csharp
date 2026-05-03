using System.Reflection;

namespace SnakeC_;

internal class Judge
{
    private Map _map;
    private Snake _snake;
    private Dashboard _board;

    public Judge(Map m, Snake s, Dashboard b)
    {
        _map = m;
        _snake = s;
        _board = b;
    }

    public void CheckAlive()
    {
        if (!CheckBorders())
        {
            _snake.Kill();
        }
    }

    public void CheckEatedFood()
    {
        var head = _snake.Body.First();
        var food = _map.GetFood(head);
        if (food != null)
        {
            food.Effect(_snake);
            var score = food.GetScore();
            _board.AddScore(score);
            _map.DeleteFood(food);
            var message = food.GetMessage();
            _board.SetMessage(message);
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

