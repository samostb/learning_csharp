using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _timer = new Timer(Elapsed, null, 0, 5000);
        }

        private void Elapsed(object? o)
        {
            
        }
    }
}
