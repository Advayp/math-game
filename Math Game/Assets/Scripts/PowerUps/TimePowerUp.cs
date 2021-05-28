namespace MathGame.PowerUps
{
    [System.Serializable]
    public class TimePowerUp : IPowerUp
    {

        private readonly int _timeAdded;

        public TimePowerUp(int timeAdded)
        {
            _timeAdded = timeAdded;
        }

        public void Use(ref int amount)
        {
            amount += _timeAdded;
        }
    }
}