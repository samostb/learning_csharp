using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC_.Foods
{
    internal class SimpleFood : FoodBase
    {
        public SimpleFood(Point point) : base(point)
        {
        }

        public override void Effect(Snake snake)
        {
            snake.Eat();
            //Console.WriteLine("Eat simple food");
        }

        public override char GetSymbol()
        {
            return '*';
        }
    }
}
