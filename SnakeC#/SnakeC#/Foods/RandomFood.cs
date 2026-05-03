using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeC_.Foods
{
    internal class RandomFood : FoodBase
    {
        private bool _isPositiveFood;

        private const int NEGATIVE_SCORE = -10;
        private const int POSITIVE_SCORE = 20;
        private const string POSITIVE_MESSAGE = "Eat good food";
        private const string NEGATIVE_MESSAGE = "Eat bad food";

        public RandomFood(Point point) : base(point)
        {
            var ranRes = Random.Shared.Next(2);
            _isPositiveFood = ranRes != 0;
        }

        public override void Effect(Snake snake)
        {
            if (_isPositiveFood)
            {
                snake.Eat();
                //snake.SetSpeed(0.75);
            }
            else
            {
                snake.Poisoned();
            }
        }

        public override char GetSymbol()
        {
            return '?';
        }

        public override int GetScore()
        {
            if (_isPositiveFood)
            {
                return POSITIVE_SCORE;
            }
            
            return NEGATIVE_SCORE;
        }

        public override string GetMessage()
        {
            if (_isPositiveFood)
            {
               return POSITIVE_MESSAGE;
            }
            return NEGATIVE_MESSAGE;
        }
    }
}

// fps effect speed
// верх и ниж гран скор 1 -- 5
// скорость синими звездами сложность 1к/с = 1 звезда