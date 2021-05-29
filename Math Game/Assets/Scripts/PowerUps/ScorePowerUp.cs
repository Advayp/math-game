namespace MathGame.PowerUps
{
    [System.Serializable]
    public class ScorePowerUp : IPowerUp<int>
    {
        private readonly int _scoreAdded;

        public ScorePowerUp(int scoreAdded)
        {
            _scoreAdded = scoreAdded;
        }


        public void Use(ref int amount)
        {
            amount += _scoreAdded;
        }
    }
}