namespace Discovery.PowerUps
{
    [System.Serializable]
    public class TimePowerUp : IPowerUp<float>
    {
        private readonly int _timeAdded;

        public TimePowerUp(int timeAdded)
        {
            _timeAdded = timeAdded;
        }

        public void Use(ref float amount)
        {
            amount += _timeAdded;
        }

        public int GetInfo()
        {
            return _timeAdded;
        }
    }
}