using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC_.Foods
{
    internal class BigFood : FoodBase
    {
        public BigFood(Point point) : base(point)
        {
        }

        public override void Effect(Snake snake)
        {
            Console.WriteLine("Eat big food");
        }

        public override char GetSymbol()
        {
            return '#';
        }
    }
}
