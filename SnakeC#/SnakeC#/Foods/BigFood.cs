using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC_.Foods
{
    internal class BigFood : FoodBase
    {
        private const int SCORE = 20;
        private const string MESSAGE = "Eat BIG food";


        public BigFood(Point point) : base(point)
        {
        }

        public override void Effect(Snake snake)
        {
            snake.Eat();
            snake.Eat();
        }

        public override char GetSymbol()
        {
            return '#';
        }

        public override int GetScore()
        {
            return SCORE;
        }

        public override string GetMessage()
        {
            return MESSAGE;
        }
    }
}
