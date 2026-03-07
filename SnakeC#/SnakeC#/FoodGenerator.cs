using SnakeC_.Foods;

namespace SnakeC_
{
    internal class FoodGenerator
    {
        private Map _map;
        private Snake _snake;
        private Timer _timer;

        public FoodGenerator(Map map, Snake snake)
        {
            _snake = snake;
            _map = map;
            _timer = new Timer(Elapsed, null, 0, 1000);
        }

        private void Elapsed(object? o)
        {
            var coord = GenerateSafePoint();
            var food = GenerateFood(coord);
            _map.AddFood(food);
        }

        private Point GeneratePoint()
        {
            var x = Random.Shared.Next(1, _map.Width - 1);
            var y = Random.Shared.Next(1, _map.Height - 1);
            return new Point { X = x, Y = y} ;
        }

        private Point GenerateSafePoint()
        {
            var coord = GeneratePoint();
            while (_snake.HitCoordinates(coord))
            {
                coord = GeneratePoint();
            }
            return coord;
        }

        private FoodBase GenerateFood(Point safePoint)
        {
            var food = Random.Shared.Next(0, 3);
            switch (food)
            {
                case 0:
                    return new BigFood(safePoint);
                    break;
                case 1:
                    return new RandomFood(safePoint);
                    break;
                case 2:
                    return new SimpleFood(safePoint);
                    break;
            }
            throw new NotImplementedException("Такой тип еды не существует.");
        }
    }
}
