namespace SnakeC_.Foods
{
    internal abstract class FoodBase
    {
        public Point Point { get; }

        private const char Symbol = '@';
        private const int DEFAULT_SCORE = 10;
        private const string MESSAGE = "Eat food";

        public FoodBase(Point point)
        {
            Point = point;
        }

        public abstract void Effect(Snake snake);

        public virtual int GetScore()
        {
            return DEFAULT_SCORE;
        }

        public virtual char GetSymbol()
        {
            return Symbol;
        }

        public virtual string GetMessage()
        {
            return MESSAGE;
        }

    }
}
