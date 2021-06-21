namespace Discovery
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
            
            if (RemainingTries > 0)
            {
                return true;
            }

            RemainingTries = 0;
            return false;
        }
    }
}