using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC_.Foods
{
    internal abstract class FoodBase
    {
        public Point Point { get; }

        private const char Symbol = '@';

        public FoodBase(Point point)
        {
            Point = point;
        }

        public abstract void Effect(Snake snake);

        public virtual char GetSymbol()
        {
            return Symbol;
        }
    }
}
