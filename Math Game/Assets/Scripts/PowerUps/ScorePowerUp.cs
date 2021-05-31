namespace MathGame.PowerUps
{
    [System.Serializable]
    public class ScorePowerUp : IPowerUp<int>
    {
        private readonly int _scoreMultiplier;

        public ScorePowerUp(int scoreMultiplier)
        {
            _scoreMultiplier = scoreMultiplier;
        }


        public void Use(ref int amount)
        {
            amount *= _scoreMultiplier;
        }

        public int GetInfo()
        {
            return _scoreMultiplier;
        }
    }
}