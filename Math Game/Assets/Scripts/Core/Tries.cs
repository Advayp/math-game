namespace MathGame.Core
{
    public class Tries
    {
        public int RemainingTries;

        public Tries(int maxTries)
        {
            RemainingTries = maxTries;
        }

        public bool UseTry()
        {
            RemainingTries--;
            return RemainingTries > 0;
        }
    }
}