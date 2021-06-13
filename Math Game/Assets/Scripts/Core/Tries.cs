namespace Discovery
{
    public class Tries
    {
        public int remainingTries;

        public Tries(int maxTries)
        {
            remainingTries = maxTries;
        }

        public bool UseTry()
        {
            remainingTries--;
            return remainingTries > 0;
        }
    }
}