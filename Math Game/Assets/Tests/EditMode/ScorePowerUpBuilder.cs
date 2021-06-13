using Discovery.PowerUps;

namespace Tests.EditMode
{
    public class ScorePowerUpBuilder
    {
        private int _scoreToAdd;

        public ScorePowerUpBuilder WithAddedValue(int amount)
        {
            _scoreToAdd = amount;
            return this;
        }

        private ScorePowerUp Build()
        {
            return new ScorePowerUp(_scoreToAdd);
        }

        public static implicit operator ScorePowerUp(ScorePowerUpBuilder builder)
        {
            return builder.Build();
        }
    }
}