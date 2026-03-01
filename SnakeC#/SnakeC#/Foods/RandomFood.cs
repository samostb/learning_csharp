using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC_.Foods
{
    internal class RandomFood : FoodBase
    {
        public RandomFood(Point point) : base(point)
        {
        }

        public override void Effect(Snake snake)
        {
            var ranRes = Random.Shared.Next(2);
            if (ranRes == 0)
            {
                Console.WriteLine("Eat bad random food ");
            }
            else
            {
                Console.WriteLine("Eat good random food");
            }
        }

        public override char GetSymbol()
        {
            return '?';
        }
    }
}
