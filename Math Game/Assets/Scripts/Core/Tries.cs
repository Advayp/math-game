namespace MathGame
{
    public class Tries
    {
        public int remainingTries;

        public Tries(int maxTries)
        {
            remainingTries = maxTries;
        }

        public virtual bool UseTry()
        {
            remainingTries--;
            return remainingTries > 0;
        }
    }
}